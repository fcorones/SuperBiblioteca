namespace Biblioteca_Winform_v1
{
    partial class FormCrearUsuario
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
            label1 = new Label();
            txtId_Usuario = new TextBox();
            label2 = new Label();
            txtNombre_Usuario = new TextBox();
            label3 = new Label();
            txtEmail_Usuario = new TextBox();
            label4 = new Label();
            txtDireccion_Usuario = new TextBox();
            label5 = new Label();
            txtTelefono_Usuario = new TextBox();
            label6 = new Label();
            txtRol_Usuario = new TextBox();
            label7 = new Label();
            txtContraseña_Usuario = new TextBox();
            btnGuardar = new Button();
            chkCambiarContraseña = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(89, 54);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // txtId_Usuario
            // 
            txtId_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId_Usuario.Location = new Point(170, 54);
            txtId_Usuario.Name = "txtId_Usuario";
            txtId_Usuario.Size = new Size(214, 33);
            txtId_Usuario.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 105);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // txtNombre_Usuario
            // 
            txtNombre_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre_Usuario.Location = new Point(170, 105);
            txtNombre_Usuario.Name = "txtNombre_Usuario";
            txtNombre_Usuario.Size = new Size(214, 33);
            txtNombre_Usuario.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(61, 159);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // txtEmail_Usuario
            // 
            txtEmail_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail_Usuario.Location = new Point(170, 156);
            txtEmail_Usuario.Name = "txtEmail_Usuario";
            txtEmail_Usuario.Size = new Size(214, 33);
            txtEmail_Usuario.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 207);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 8;
            label4.Text = "Dirección";
            // 
            // txtDireccion_Usuario
            // 
            txtDireccion_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion_Usuario.Location = new Point(170, 207);
            txtDireccion_Usuario.Name = "txtDireccion_Usuario";
            txtDireccion_Usuario.Size = new Size(214, 33);
            txtDireccion_Usuario.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 256);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 10;
            label5.Text = "Telefono";
            // 
            // txtTelefono_Usuario
            // 
            txtTelefono_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono_Usuario.Location = new Point(170, 256);
            txtTelefono_Usuario.Name = "txtTelefono_Usuario";
            txtTelefono_Usuario.Size = new Size(214, 33);
            txtTelefono_Usuario.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(51, 302);
            label6.Name = "label6";
            label6.Size = new Size(38, 25);
            label6.TabIndex = 12;
            label6.Text = "Rol";
            // 
            // txtRol_Usuario
            // 
            txtRol_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRol_Usuario.Location = new Point(170, 302);
            txtRol_Usuario.Name = "txtRol_Usuario";
            txtRol_Usuario.Size = new Size(214, 33);
            txtRol_Usuario.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(27, 354);
            label7.Name = "label7";
            label7.Size = new Size(108, 25);
            label7.TabIndex = 14;
            label7.Text = "Contraseña";
            label7.Click += label7_Click;
            // 
            // txtContraseña_Usuario
            // 
            txtContraseña_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña_Usuario.Location = new Point(170, 351);
            txtContraseña_Usuario.Name = "txtContraseña_Usuario";
            txtContraseña_Usuario.Size = new Size(214, 33);
            txtContraseña_Usuario.TabIndex = 15;
            txtContraseña_Usuario.UseSystemPasswordChar = true;
            txtContraseña_Usuario.TextChanged += txtContraseña_Usuario_TextChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(170, 422);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(181, 42);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "GUARDAR LIBRO";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_ClickAsync;
            // 
            // chkCambiarContraseña
            // 
            chkCambiarContraseña.AutoSize = true;
            chkCambiarContraseña.Location = new Point(417, 363);
            chkCambiarContraseña.Name = "chkCambiarContraseña";
            chkCambiarContraseña.Size = new Size(117, 19);
            chkCambiarContraseña.TabIndex = 22;
            chkCambiarContraseña.Text = "Pisar contraseña?";
            chkCambiarContraseña.UseVisualStyleBackColor = true;
            chkCambiarContraseña.CheckedChanged += chkCambiarContraseña_CheckedChanged;
            // 
            // FormCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 514);
            Controls.Add(chkCambiarContraseña);
            Controls.Add(btnGuardar);
            Controls.Add(txtContraseña_Usuario);
            Controls.Add(label7);
            Controls.Add(txtRol_Usuario);
            Controls.Add(label6);
            Controls.Add(txtTelefono_Usuario);
            Controls.Add(label5);
            Controls.Add(txtDireccion_Usuario);
            Controls.Add(label4);
            Controls.Add(txtEmail_Usuario);
            Controls.Add(label3);
            Controls.Add(txtNombre_Usuario);
            Controls.Add(label2);
            Controls.Add(txtId_Usuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormCrearUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCrearUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId_Usuario;
        private Label label2;
        private TextBox txtNombre_Usuario;
        private Label label3;
        private TextBox txtEmail_Usuario;
        private Label label4;
        private TextBox txtDireccion_Usuario;
        private Label label5;
        private TextBox txtTelefono_Usuario;
        private Label label6;
        private TextBox txtRol_Usuario;
        private Label label7;
        private TextBox txtContraseña_Usuario;
        private Button btnGuardar;
        private CheckBox chkCambiarContraseña;
    }
}