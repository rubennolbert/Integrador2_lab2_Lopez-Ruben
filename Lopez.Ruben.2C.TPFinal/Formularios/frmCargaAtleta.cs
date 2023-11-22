using Entidades.Excepciones;
using Entidades.Extesiones;
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
    public partial class frmCargaAtleta : Form
    {
        private BoxCrossfit box;

        public frmCargaAtleta(BoxCrossfit box)
        {
            InitializeComponent();
            this.box = box;
        }

        private void frmCargaAtleta_Load(object sender, EventArgs e)
        {
            this.cbmEnum1.DataSource = Enum.GetValues(typeof(Atleta.EPase));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarCampos();
                this.ValidarDniExistente(int.Parse(this.txtDni.Text));

                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                int dni = int.Parse(this.txtDni.Text);
                DateTime fechaNacimiento = this.dtpFechaNacimiento.Value;
                Atleta.EPase pase = (Atleta.EPase)this.cbmEnum1.SelectedItem;

                Atleta atleta = new Atleta(nombre, apellido, dni, fechaNacimiento, pase);
                string mensaje = string.Empty;

                if (this.IngresarSocio(this.box, atleta))
                {
                    GestorSQL.AltaAtleta(atleta);
                    MessageBox.Show("Socio agreado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
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
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtDni.Text == string.Empty)
            {
                throw new CampoVacioException("Todos los campos deben estar completos");
            }
            else if (!int.TryParse(this.txtDni.Text, out int dni))
            {
                throw new DniInvalidoException("El DNI debe ser un número");
            }
            else if (int.Parse(this.txtDni.Text) <= 0 || int.Parse(this.txtDni.Text) >= 99999999)
            {
                throw new DniInvalidoException("El DNI debe ser un número entre 0 y 99.999.999");
            }
            else if (int.Parse(this.txtDni.Text).CantidadDeDigitos() < 7 || int.Parse(this.txtDni.Text).CantidadDeDigitos() > 8)
            {
                throw new CantidadDeDigitosException("El DNI debe tener 7 u 8 dígitos");
            }
            else if (this.dtpFechaNacimiento.Value >= DateTime.Now)
            {
                throw new FechaNacimientoInvalidaException("La Fecha de nacimiento debe ser menor a la fecha actual");
            }
            return true;
        }

        private bool ValidarDniExistente(int dni)
        {
            foreach (Atleta atleta in this.box.ListaAtletas)
            {
                if (atleta.Dni == dni)
                {
                    throw new DniInvalidoException("El DNI ya existe en la base de socios");
                }
            }
            return true;
        }


        private bool IngresarSocio(BoxCrossfit box, Atleta atleta)
        {
            if (!(this.box != atleta && box + atleta))
            {
                throw new IngresoAlClubException("No se pudo agregar el socio");
            }
            return true;
        }

        
    }
}
