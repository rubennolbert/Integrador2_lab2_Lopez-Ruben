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

        /// <summary>
        /// Al cargar el formulario se busca si ya existe un archivo xml con datos de socios existentes, si lo encuentra se lee
        /// y se crea un box con esa lista de socios encontrada. Si no hay archivo de datos se crea un box de cero.
        /// Se actualiza la vista de la listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Instancia un formulario de carga de atletas enviandole el box creado en este formulario principal,
        /// y al volver actualiza la vista de la lista de atletas por si se agregó uno nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmCargaAtleta frmCarga = new frmCargaAtleta(this.Box);
            frmCarga.ShowDialog();
            this.ActualizaListaAtletas();
        }

        /// <summary>
        /// Checkea si la listabox quedó vacía y en ese caso inahbilita los botones de interaccion con atletas ya que no hay ninguno para interactuar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Si hay algun atleta seleccionado en la lista, instancia un formulario para modificar los datos del atleta seleccionado y al 
        /// regresar actualiza la lista de atletas en caso que se haya realizado alguna modificación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Atleta atleta;
            if (this.lstPersonas.SelectedIndex != -1)
            {
                atleta = (Atleta)this.lstPersonas.SelectedItem;
                frmModificarAtleta frm = new frmModificarAtleta(this.Box, atleta);
                frm.ShowDialog();
                this.ActualizaListaAtletas();
            }
            else
            {
                MessageBox.Show("No hay ningún atleta seleccionado", "Modificar atleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Si hay algun atleta seleccionado en la lista es eliminado de la lista de atletas del box previa confirmación,
        /// y actualiza la lista de atletas en caso que se haya confirmado la eliminación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        this.ActualizaListaAtletas();
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

        /// <summary>
        /// Si hay algun atleta seleccionado se instancia un formulario para agregar una cuota a la lista de cuotas del atleta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Si hay algun atleta seleccionado se instancia un formulario para ver el estado de cuenta del mismo, si esta
        /// al día con las cuotas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Exporta los datos de la lista de atletas a un archivo "dataAtletas.xml" en una carpeta llamada XML en el escritorio.
        /// Si el archivo ya existe lo sobreescribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Pide confirmación para cerrar el programa y avisa si quiere guardar los datos de la lista de atletas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// En un hilo paralelo lee la base de datos, trae la lista de atletas y la carga en el listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerBaseDeDatosSQL_Click(object sender, EventArgs e)
        {
            this.InformeCargando += CargandoBase;
            this.FinDeCarga += FinDeCargaBase;

            Task task = Task.Run(IniciarCarga);
        }


        /// <summary>
        /// Actualiza la listbox con los datos de la lista de atletas del box
        /// </summary>
        private void ActualizaListaAtletas()
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

        /// <summary>
        /// Metodo que invoca a los metodos que muestran el estado de la carga de la base de datos y del método
        /// que informa cuando la base de datos ya fue cargada
        /// </summary>
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

        /// <summary>
        /// Informa el estado de la carga de la base de datos.
        /// </summary>
        /// <param name="tiempo"></param>
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

        /// <summary>
        /// Informa cuando la base de datos ya fue cargada.
        /// </summary>
        private void FinDeCargaBase()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(FinDeCarga);
            }
            else
            {
                this.ActualizaListaAtletas();
                this.lblCargando.ForeColor = Color.Green;
                this.lblCargando.Text = "Base de datos cargada";
            }
        }


    }
}