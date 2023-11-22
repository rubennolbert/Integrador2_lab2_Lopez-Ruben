using Entidades.Archivos_Serializacion;
using Entidades.Excepciones;
using Entidades.Modelos;
using Entidades.SQL_BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class frmEstadoDeCuenta : Form
    {
        private Atleta atleta;
        public frmEstadoDeCuenta(Atleta atleta)
        {
            InitializeComponent();
            this.atleta = atleta;
        }

        private void frmEstadoDeCuenta_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtNombre.Text = atleta.Nombre;
                this.txtApellido.Text = atleta.Apellido;
                this.txtDni.Text = atleta.Dni.ToString();
                atleta.HistorialDePagos = GestorSQL.LeerCuotasDeAtleta(this.atleta);
                atleta.HistorialDePagos.Sort((Cuota c1, Cuota c2) => string.Compare(c1.MesCuota, c2.MesCuota));
                this.lstHistorialDePagos.DataSource = atleta.HistorialDePagos;

                if (atleta.VerificacionPagoAlDia())
                {
                    this.lblEstaAlDia.ForeColor = Color.Green;
                    this.lblEstaAlDia.Text = "Esta al día";
                }
                else
                {
                    this.lblEstaAlDia.ForeColor = Color.Red;
                    this.lblEstaAlDia.Text = "Debe";
                }
            }
            catch (ExceptionSQL ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar las cuotas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar las cuotas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivoTXT archivo = new ArchivoTXT();
                string nombreDeArchivo;
                archivo.Escribir($"{atleta.Nombre}{atleta.Apellido}.txt", atleta.Imprimir());
                nombreDeArchivo = $"{archivo.PathEscritura()}{atleta.Nombre}{atleta.Apellido}.txt";
                ProcessStartInfo proceso = new ProcessStartInfo
                {
                    FileName = nombreDeArchivo,
                    UseShellExecute = true
                };
                Process.Start(proceso);
                MessageBox.Show($"Impresión exitosa.\nRecibo en: {archivo.PathEscritura()}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArchivoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Error al escribir el archivo de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al escribir el archivo de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
