namespace Formularios
{
    partial class frmModificarAtleta
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
            cbmEnum1 = new ComboBox();
            dtpFechaNacimiento = new DateTimePicker();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(152, 345);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 25;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(57, 345);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 24;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cbmEnum1
            // 
            cbmEnum1.FormattingEnabled = true;
            cbmEnum1.Location = new Point(58, 285);
            cbmEnum1.Name = "cbmEnum1";
            cbmEnum1.Size = new Size(169, 23);
            cbmEnum1.TabIndex = 23;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(57, 221);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(170, 23);
            dtpFechaNacimiento.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 267);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 21;
            label6.Text = "Pase";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 203);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 20;
            label4.Text = "Fecha de nacimiento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 146);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 19;
            label3.Text = "DNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 89);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 18;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 37);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 17;
            label1.Text = "Nombre";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(58, 164);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(169, 23);
            txtDni.TabIndex = 16;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(58, 107);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(169, 23);
            txtApellido.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(58, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(169, 23);
            txtNombre.TabIndex = 14;
            // 
            // frmModificarAtleta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 406);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cbmEnum1);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmModificarAtleta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Atleta";
            Load += frmModificarAtleta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private ComboBox cbmEnum1;
        private DateTimePicker dtpFechaNacimiento;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDni;
        private TextBox txtApellido;
        private TextBox txtNombre;
    }
}