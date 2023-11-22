namespace Formularios
{
    partial class frmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnCargar = new Button();
            btnModificar = new Button();
            btnExportar = new Button();
            btnEliminar = new Button();
            btnEstadoDeCuenta = new Button();
            btnPagarCuota = new Button();
            btnLeerBaaseDeDatosSQL = new Button();
            lstPersonas = new ListBox();
            lblCargando = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 122);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(12, 230);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 121);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(122, 89);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(231, 37);
            btnCargar.TabIndex = 2;
            btnCargar.Text = "Cargar Atleta";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(122, 132);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(231, 36);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar Atleta";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(122, 275);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(231, 35);
            btnExportar.TabIndex = 4;
            btnExportar.Text = "Exportar Informacion";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(122, 246);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(231, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar Menbresia";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEstadoDeCuenta
            // 
            btnEstadoDeCuenta.Location = new Point(245, 174);
            btnEstadoDeCuenta.Name = "btnEstadoDeCuenta";
            btnEstadoDeCuenta.Size = new Size(108, 58);
            btnEstadoDeCuenta.TabIndex = 6;
            btnEstadoDeCuenta.Text = "Estado\r\n de cuenta";
            btnEstadoDeCuenta.UseVisualStyleBackColor = true;
            btnEstadoDeCuenta.Click += btnEstadoDeCuenta_Click;
            // 
            // btnPagarCuota
            // 
            btnPagarCuota.Location = new Point(122, 174);
            btnPagarCuota.Name = "btnPagarCuota";
            btnPagarCuota.Size = new Size(108, 58);
            btnPagarCuota.TabIndex = 7;
            btnPagarCuota.Text = "Pago\r\nCuota";
            btnPagarCuota.UseVisualStyleBackColor = true;
            btnPagarCuota.Click += btnPagarCuota_Click;
            // 
            // btnLeerBaaseDeDatosSQL
            // 
            btnLeerBaaseDeDatosSQL.Location = new Point(122, 316);
            btnLeerBaaseDeDatosSQL.Name = "btnLeerBaaseDeDatosSQL";
            btnLeerBaaseDeDatosSQL.Size = new Size(231, 35);
            btnLeerBaaseDeDatosSQL.TabIndex = 8;
            btnLeerBaaseDeDatosSQL.Text = "Cargar Base de Datos (sql)";
            btnLeerBaaseDeDatosSQL.UseVisualStyleBackColor = true;
            btnLeerBaaseDeDatosSQL.Click += btnLeerBaaseDeDatosSQL_Click;
            // 
            // lstPersonas
            // 
            lstPersonas.FormattingEnabled = true;
            lstPersonas.ItemHeight = 15;
            lstPersonas.Location = new Point(359, 89);
            lstPersonas.Name = "lstPersonas";
            lstPersonas.Size = new Size(565, 259);
            lstPersonas.TabIndex = 9;
            lstPersonas.SelectedIndexChanged += lstPersonas_SelectedIndexChanged;
            // 
            // lblCargando
            // 
            lblCargando.AutoSize = true;
            lblCargando.Location = new Point(170, 364);
            lblCargando.Name = "lblCargando";
            lblCargando.Size = new Size(38, 15);
            lblCargando.TabIndex = 10;
            lblCargando.Text = "label1";
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 450);
            Controls.Add(lblCargando);
            Controls.Add(lstPersonas);
            Controls.Add(btnLeerBaaseDeDatosSQL);
            Controls.Add(btnPagarCuota);
            Controls.Add(btnEstadoDeCuenta);
            Controls.Add(btnEliminar);
            Controls.Add(btnExportar);
            Controls.Add(btnModificar);
            Controls.Add(btnCargar);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chronos Crossfit";
            Load += frmInicio_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnCargar;
        private Button btnModificar;
        private Button btnExportar;
        private Button btnEliminar;
        private Button btnEstadoDeCuenta;
        private Button btnPagarCuota;
        private Button btnLeerBaaseDeDatosSQL;
        private ListBox lstPersonas;
        private Label lblCargando;
    }
}