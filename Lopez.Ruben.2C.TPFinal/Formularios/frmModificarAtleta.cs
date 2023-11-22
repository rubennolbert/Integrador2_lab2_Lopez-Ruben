using Entidades.Excepciones;
using Entidades.Modelos;
using Entidades.SQL_BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class frmModificarAtleta : Form
    {
        private BoxCrossfit box;
        private Atleta atleta;

        public frmModificarAtleta(BoxCrossfit box, Atleta atleta)
        {
            InitializeComponent();
            this.box = box;
            this.atleta = atleta;
        }

        private void frmModificarAtleta_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = atleta.Nombre;
            this.txtApellido.Text = atleta.Apellido;
            this.txtDni.Text = atleta.Dni.ToString();
            this.txtDni.Enabled = false;
            this.dtpFechaNacimiento.Value = atleta.FechaNacimiento;
            this.cbmEnum1.DataSource = Enum.GetValues(typeof(Atleta.EPase));
            this.cbmEnum1.SelectedItem = atleta.Pase;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarCampos();

                this.atleta.Nombre = this.txtNombre.Text;
                this.atleta.Apellido = this.txtApellido.Text;
                this.atleta.FechaNacimiento = this.dtpFechaNacimiento.Value;
                this.atleta.Pase = (Atleta.EPase)this.cbmEnum1.SelectedItem;
                GestorSQL.ModificarAtleta(this.atleta, this.atleta.Dni);

                MessageBox.Show("Socio editado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (DniInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IngresoAlClubException ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool ValidarCampos()
        {
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty)
            {
                throw new CampoVacioException("Todos los campos deben estar completos");
            }
            else if (this.dtpFechaNacimiento.Value >= DateTime.Now)
            {
                throw new FechaNacimientoInvalidaException("La Fecha de nacimiento debe ser menor a la fecha actual");
            }
            return true;
        }


    }
}
