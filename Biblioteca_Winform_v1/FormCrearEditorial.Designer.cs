namespace Biblioteca_Winform_v1
{
    partial class FormCrearEditorial
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
            txtId_Editorial = new TextBox();
            label2 = new Label();
            txtNombreEditorial = new TextBox();
            btnGuardar_Editorial = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(146, 93);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // txtId_Editorial
            // 
            txtId_Editorial.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId_Editorial.Location = new Point(203, 93);
            txtId_Editorial.Name = "txtId_Editorial";
            txtId_Editorial.Size = new Size(214, 33);
            txtId_Editorial.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(95, 166);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 5;
            label2.Text = "Nombre";
            // 
            // txtNombreEditorial
            // 
            txtNombreEditorial.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreEditorial.Location = new Point(203, 166);
            txtNombreEditorial.Name = "txtNombreEditorial";
            txtNombreEditorial.Size = new Size(214, 33);
            txtNombreEditorial.TabIndex = 6;
            // 
            // btnGuardar_Editorial
            // 
            btnGuardar_Editorial.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar_Editorial.Location = new Point(214, 239);
            btnGuardar_Editorial.Name = "btnGuardar_Editorial";
            btnGuardar_Editorial.Size = new Size(181, 42);
            btnGuardar_Editorial.TabIndex = 22;
            btnGuardar_Editorial.Text = "GUARDAR LIBRO";
            btnGuardar_Editorial.UseVisualStyleBackColor = true;
            btnGuardar_Editorial.Click += btnGuardar_Editorial_Click;
            // 
            // FormCrearEditorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 389);
            Controls.Add(btnGuardar_Editorial);
            Controls.Add(txtNombreEditorial);
            Controls.Add(label2);
            Controls.Add(txtId_Editorial);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormCrearEditorial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCrearEditorial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId_Editorial;
        private Label label2;
        private TextBox txtNombreEditorial;
        private Button btnGuardar_Editorial;
    }
}