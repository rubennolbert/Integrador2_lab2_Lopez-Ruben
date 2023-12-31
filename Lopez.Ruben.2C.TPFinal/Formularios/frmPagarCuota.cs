﻿using Entidades.Excepciones;
using Entidades;
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
    public partial class frmPagarCuota : Form
    {
        private Atleta atleta;

        public frmPagarCuota(Atleta atleta)
        {
            InitializeComponent();
            this.atleta = atleta;
        }

        /// <summary>
        /// Carga los datos del atleta que vino como parámetro en la instancia del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPagarCuota_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = atleta.Nombre;
            this.txtApellido.Text = atleta.Apellido;
            this.txtDni.Text = atleta.Dni.ToString();
            this.cmbPase.DataSource = Enum.GetValues(typeof(Atleta.EPase));
            this.cmbMetodoDePago.DataSource = Enum.GetValues(typeof(Cuota.EMetodoDePago));
        }

        /// <summary>
        /// Valida los campos, si estan ok genero una nueva cuota con los datos ingresados y con el metodo RegistrarPago() de atleta
        /// agrego esta cuota a la lista de cuotas del atleta, si esta todo ok se cierra el form y se vuelve al principal.
        /// Si algo salió mal se arrojara la exception que corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarCampos();
                Cuota cuota;
                Cuota.EMetodoDePago metodoDePago = (Cuota.EMetodoDePago)this.cmbMetodoDePago.SelectedItem;
                int importe = int.Parse(this.txtImporte.Text);
                Atleta.EPase actividad = (Atleta.EPase)this.cmbPase.SelectedItem;
                DateTime fechaCuota = this.dtpFechaCuota.Value;
                int dniAtleta = atleta.Dni;

                cuota = new Cuota(metodoDePago, importe, actividad, fechaCuota, dniAtleta);

                Atleta.RegistroPago(this.atleta, cuota);
                GestorSQL.AltaCuota(this.atleta, cuota);
                this.Close();
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ImporteInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (RegistroPagoCuotaException ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar el pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancela la instancia del formulario de modificar cerrandolo y volviendo al form principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Verifica que el importe sea un numero positivo, en caso contrario arrojará las exceptions correspondientes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CampoVacioException"></exception>
        /// <exception cref="ImporteInvalidoException"></exception>
        private bool ValidarCampos()
        {
            if (this.txtImporte.Text == string.Empty)
            {
                throw new CampoVacioException("EL importe no puede estar vacío");
            }
            else if (!int.TryParse(this.txtImporte.Text, out int importe))
            {
                throw new ImporteInvalidoException("El importe debe ser un número");
            }
            else if (int.Parse(this.txtImporte.Text) <= 0)
            {
                throw new ImporteInvalidoException("El importe debe ser mayor a cero");
            }
            return true;
        }


    }
}
