namespace Formularios
{
    partial class frmPagarCuota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancelar = new Button();
            btnAceptar = new Button();
            cmbPase = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label4 = new Label();
            txtImporte = new TextBox();
            label5 = new Label();
            label7 = new Label();
            dtpFechaCuota = new DateTimePicker();
            cmbMetodoDePago = new ComboBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(139, 401);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 25;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(44, 401);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 24;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cmbPase
            // 
            cmbPase.FormattingEnabled = true;
            cmbPase.Location = new Point(45, 202);
            cmbPase.Name = "cmbPase";
            cmbPase.Size = new Size(169, 23);
            cmbPase.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 129);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 19;
            label3.Text = "DNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 78);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 18;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 26);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 17;
            label1.Text = "Nombre";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(45, 147);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(169, 23);
            txtDni.TabIndex = 16;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(45, 96);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(169, 23);
            txtApellido.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(45, 44);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(169, 23);
            txtNombre.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 184);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 21;
            label6.Text = "Pase";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 240);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 26;
            label4.Text = "Importe";
            // 
            // txtImporte
            // 
            txtImporte.Location = new Point(44, 258);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(169, 23);
            txtImporte.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 291);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 28;
            label5.Text = "Fecha";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 343);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 29;
            label7.Text = "Metodo de pago";
            // 
            // dtpFechaCuota
            // 
            dtpFechaCuota.Location = new Point(43, 309);
            dtpFechaCuota.Name = "dtpFechaCuota";
            dtpFechaCuota.Size = new Size(170, 23);
            dtpFechaCuota.TabIndex = 30;
            // 
            // cmbMetodoDePago
            // 
            cmbMetodoDePago.FormattingEnabled = true;
            cmbMetodoDePago.Location = new Point(43, 361);
            cmbMetodoDePago.Name = "cmbMetodoDePago";
            cmbMetodoDePago.Size = new Size(170, 23);
            cmbMetodoDePago.TabIndex = 31;
            // 
            // frmPagarCuota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 453);
            Controls.Add(cmbMetodoDePago);
            Controls.Add(dtpFechaCuota);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(txtImporte);
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbPase);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPagarCuota";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPagarCuota";
            Load += frmPagarCuota_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private ComboBox cmbPase;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDni;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label6;
        private Label label4;
        private TextBox txtImporte;
        private Label label5;
        private Label label7;
        private DateTimePicker dtpFechaCuota;
        private ComboBox cmbMetodoDePago;
    }
}