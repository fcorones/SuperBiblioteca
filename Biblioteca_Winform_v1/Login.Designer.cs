namespace Biblioteca_Winform_v1
{
    partial class Login
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
            label2 = new Label();
            label3 = new Label();
            txtUsuarioEmail = new TextBox();
            txtContraseña = new TextBox();
            btnIniciar = new Button();
            panelCargando = new Panel();
            label4 = new Label();
            panelCargando.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(292, 56);
            label1.Name = "label1";
            label1.Size = new Size(199, 37);
            label1.TabIndex = 0;
            label1.Text = "Inicio de sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 17F);
            label2.Location = new Point(163, 131);
            label2.Name = "label2";
            label2.Size = new Size(70, 31);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F);
            label3.Location = new Point(126, 238);
            label3.Name = "label3";
            label3.Size = new Size(129, 31);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // txtUsuarioEmail
            // 
            txtUsuarioEmail.Font = new Font("Segoe UI", 15F);
            txtUsuarioEmail.Location = new Point(292, 130);
            txtUsuarioEmail.Name = "txtUsuarioEmail";
            txtUsuarioEmail.Size = new Size(209, 34);
            txtUsuarioEmail.TabIndex = 3;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 15F);
            txtContraseña.Location = new Point(292, 237);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(209, 34);
            txtContraseña.TabIndex = 4;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // btnIniciar
            // 
            btnIniciar.Font = new Font("Segoe UI", 20F);
            btnIniciar.Location = new Point(272, 337);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(247, 46);
            btnIniciar.TabIndex = 5;
            btnIniciar.Text = "INICIAR SESIÓN";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // panelCargando
            // 
            panelCargando.BorderStyle = BorderStyle.FixedSingle;
            panelCargando.Controls.Add(label4);
            panelCargando.Location = new Point(41, 28);
            panelCargando.Name = "panelCargando";
            panelCargando.Size = new Size(648, 376);
            panelCargando.TabIndex = 6;
            panelCargando.Visible = false;
            panelCargando.Paint += panelCargando_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(204, 164);
            label4.Name = "label4";
            label4.Size = new Size(207, 32);
            label4.TabIndex = 0;
            label4.Text = "Iniciando sesión ...";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 450);
            Controls.Add(panelCargando);
            Controls.Add(btnIniciar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuarioEmail);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            FormClosing += Login_FormClosing;
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            panelCargando.ResumeLayout(false);
            panelCargando.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsuarioEmail;
        private TextBox txtContraseña;
        private Button btnIniciar;
        private Panel panelCargando;
        private Label label4;
    }
}