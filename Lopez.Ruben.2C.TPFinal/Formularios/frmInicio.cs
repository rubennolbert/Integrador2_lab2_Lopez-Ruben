using Entidades.Archivos_Serializacion;
using Entidades.Excepciones;
using Entidades.Modelos;
using Entidades.SQL_BaseDeDatos;

namespace Formularios
{
    public partial class frmInicio : Form
    {
        private BoxCrossfit Box;
        private Serializacion<List<Atleta>> serializar = new Serializacion<List<Atleta>>(GestionArchivos.ETipo.XML);

        public delegate void CargandoBaseDeDatos(int tiempo);
        public delegate void FinCargarBaseDeDatos();

        public event CargandoBaseDeDatos InformeCargando;
        public event FinCargarBaseDeDatos FinDeCarga;


        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

            this.lblCargando.Text = "";
            this.btnCargar.Enabled = false;
            this.btnModificar.Enabled = false;
            this.btnEstadoDeCuenta.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnPagarCuota.Enabled = false;
            this.btnExportar.Enabled = false;

            this.Box = new BoxCrossfit("ChronosCF");


        }



        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmCargaAtleta frmCarga = new frmCargaAtleta(this.Box);
            frmCarga.ShowDialog();
            this.ActualizaListaSocios();
        }


        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPersonas.SelectedIndex == -1)
            {
                this.btnCargar.Enabled = false;
                this.btnModificar.Enabled = false;
                this.btnEstadoDeCuenta.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnPagarCuota.Enabled = false;
            }
            else
            {
                this.btnCargar.Enabled = true;
                this.btnModificar.Enabled = true;
                this.btnEstadoDeCuenta.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.btnPagarCuota.Enabled = true;
                this.btnExportar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Atleta atleta;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                atleta = (Atleta)this.lstPersonas.SelectedItem;
                frmModificarAtleta frm = new frmModificarAtleta(this.Box, atleta);
                frm.ShowDialog();
                this.ActualizaListaSocios();
            }
            else
            {
                MessageBox.Show("No hay ningún atleta seleccionado", "Modificar atleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Atleta atleta;
            try
            {
                if (this.lstPersonas.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar al atleta?", "Eliminar atleta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        atleta = (Atleta)this.lstPersonas.SelectedItem;
                        MessageBox.Show(this.Box.ElimiarAtleta(atleta), "Eliminar atleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GestorSQL.EliminarAtleta(atleta.Dni);
                        this.ActualizaListaSocios();
                    }
                    else
                    {
                    }
                }
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar el atleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar el atleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            Atleta atleta;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                atleta = (Atleta)this.lstPersonas.SelectedItem;
                frmPagarCuota frm = new frmPagarCuota(atleta);
                frm.ShowDialog();
            }
        }

        private void btnEstadoDeCuenta_Click(object sender, EventArgs e)
        {
            Atleta atleta;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                atleta = (Atleta)this.lstPersonas.SelectedItem;
                frmEstadoDeCuenta frm = new frmEstadoDeCuenta(atleta);
                frm.ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorSQL.LeerDatosBoxCrossfit(this.Box);
                this.serializar.Escribir("dataAtletas.xml", this.Box.ListaAtletas);
                MessageBox.Show($"Datos exportados con éxito.\nEl archivo dataAtletas.xml se encuentra en: {this.serializar.RutaDeEscritura()}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArchivoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al escribir el archivo de datos de atletas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?\nExporte la los datos de la lista antes de salir.", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnLeerBaaseDeDatosSQL_Click(object sender, EventArgs e)
        {
            this.InformeCargando += CargandoBase;
            this.FinDeCarga += FinDeCargaBase;

            Task task = Task.Run(IniciarCarga);
        }



        private void ActualizaListaSocios()
        {
            try
            {
                this.Box.ListaAtletas = GestorSQL.LeerDatosAtleta();
                this.Box.ListaAtletas.Sort((Atleta a1, Atleta a2) => string.Compare(a1.Nombre, a2.Nombre));
                this.lstPersonas.DataSource = null;
                this.lstPersonas.DataSource = Box.ListaAtletas;
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al la base de datos SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void IniciarCarga()
        {
            int contador = 5000;
            while (contador > 0)
            {
                contador -= 1000;
                if (this.InformeCargando is not null)
                {
                    this.InformeCargando.Invoke(contador);
                    Thread.Sleep(1000);
                }
            }
            if (this.FinDeCarga is not null)
            {
                this.FinDeCarga.Invoke();
            }
        }

        private void CargandoBase(int tiempo)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(InformeCargando, new Object[] { tiempo });
            }
            else
            {
                this.lblCargando.ForeColor = Color.Red;
                this.lblCargando.Text = "Cargando base de datos en " + tiempo / 1000 + " segundos";
            }
        }

        private void FinDeCargaBase()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(FinDeCarga);
            }
            else
            {
                this.ActualizaListaSocios();
                this.lblCargando.ForeColor = Color.Green;
                this.lblCargando.Text = "Base de datos cargada";
            }
        }


    }
}