namespace Formularios
{
    partial class frmEstadoDeCuenta
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            groupBox1 = new GroupBox();
            lblEstaAlDia = new Label();
            btnImprimir = new Button();
            lstHistorialDePagos = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 143);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 11;
            label3.Text = "DNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 86);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 10;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 34);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 9;
            label1.Text = "Nombre";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(42, 161);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(169, 23);
            txtDni.TabIndex = 8;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(42, 104);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(169, 23);
            txtApellido.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(42, 52);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(169, 23);
            txtNombre.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblEstaAlDia);
            groupBox1.Location = new Point(42, 230);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(169, 78);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estado de cuenta";
            // 
            // lblEstaAlDia
            // 
            lblEstaAlDia.AutoSize = true;
            lblEstaAlDia.Location = new Point(50, 35);
            lblEstaAlDia.Name = "lblEstaAlDia";
            lblEstaAlDia.Size = new Size(38, 15);
            lblEstaAlDia.TabIndex = 0;
            lblEstaAlDia.Text = "label4";
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(41, 341);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(170, 23);
            btnImprimir.TabIndex = 13;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // lstHistorialDePagos
            // 
            lstHistorialDePagos.FormattingEnabled = true;
            lstHistorialDePagos.ItemHeight = 15;
            lstHistorialDePagos.Location = new Point(274, 52);
            lstHistorialDePagos.Name = "lstHistorialDePagos";
            lstHistorialDePagos.Size = new Size(357, 304);
            lstHistorialDePagos.TabIndex = 14;
            // 
            // frmEstadoDeCuenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 409);
            Controls.Add(lstHistorialDePagos);
            Controls.Add(btnImprimir);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEstadoDeCuenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estado de cuenta";
            Load += frmEstadoDeCuenta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDni;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private GroupBox groupBox1;
        private Label lblEstaAlDia;
        private Button btnImprimir;
        private ListBox lstHistorialDePagos;
    }
}