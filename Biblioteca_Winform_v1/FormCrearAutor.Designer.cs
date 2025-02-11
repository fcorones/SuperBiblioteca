namespace Biblioteca_Winform_v1
{
    partial class FormCrearAutor
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
            label_id = new Label();
            label1 = new Label();
            txtId_Autor = new TextBox();
            txtNombreAutor = new TextBox();
            btnGuardarAutor = new Button();
            SuspendLayout();
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_id.Location = new Point(210, 55);
            label_id.Name = "label_id";
            label_id.Size = new Size(30, 25);
            label_id.TabIndex = 0;
            label_id.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 117);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 1;
            label1.Text = "Nombre del autor";
            // 
            // txtId_Autor
            // 
            txtId_Autor.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId_Autor.Location = new Point(285, 55);
            txtId_Autor.Name = "txtId_Autor";
            txtId_Autor.Size = new Size(69, 33);
            txtId_Autor.TabIndex = 2;
            // 
            // txtNombreAutor
            // 
            txtNombreAutor.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreAutor.Location = new Point(285, 117);
            txtNombreAutor.Name = "txtNombreAutor";
            txtNombreAutor.Size = new Size(247, 33);
            txtNombreAutor.TabIndex = 3;
            // 
            // btnGuardarAutor
            // 
            btnGuardarAutor.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarAutor.Location = new Point(223, 227);
            btnGuardarAutor.Name = "btnGuardarAutor";
            btnGuardarAutor.Size = new Size(181, 42);
            btnGuardarAutor.TabIndex = 21;
            btnGuardarAutor.Text = "GUARDAR LIBRO";
            btnGuardarAutor.UseVisualStyleBackColor = true;
            btnGuardarAutor.Click += btnGuardarAutor_Click;
            // 
            // FormCrearAutor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 450);
            Controls.Add(btnGuardarAutor);
            Controls.Add(txtNombreAutor);
            Controls.Add(txtId_Autor);
            Controls.Add(label1);
            Controls.Add(label_id);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormCrearAutor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCrearAutor";
            Load += FormCrearAutor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_id;
        private Label label1;
        private TextBox txtId_Autor;
        private TextBox txtNombreAutor;
        private Button btnGuardarAutor;
    }
}