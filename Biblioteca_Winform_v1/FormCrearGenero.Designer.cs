namespace Biblioteca_Winform_v1
{
    partial class FormCrearGenero
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
            txtId_Genero = new TextBox();
            label2 = new Label();
            txtNombre_Genero = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(132, 96);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // txtId_Genero
            // 
            txtId_Genero.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId_Genero.Location = new Point(203, 93);
            txtId_Genero.Name = "txtId_Genero";
            txtId_Genero.Size = new Size(214, 33);
            txtId_Genero.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(90, 169);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 5;
            label2.Text = "Nombre";
            // 
            // txtNombre_Genero
            // 
            txtNombre_Genero.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre_Genero.Location = new Point(203, 166);
            txtNombre_Genero.Name = "txtNombre_Genero";
            txtNombre_Genero.Size = new Size(214, 33);
            txtNombre_Genero.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(218, 241);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(181, 42);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "GUARDAR LIBRO";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormCrearGenero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 389);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre_Genero);
            Controls.Add(label2);
            Controls.Add(txtId_Genero);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormCrearGenero";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCrearGenero";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId_Genero;
        private Label label2;
        private TextBox txtNombre_Genero;
        private Button btnGuardar;
    }
}