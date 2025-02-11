namespace Biblioteca_Winform_v1
{
    partial class FormCrearLibro
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
            txtId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtTitulo = new TextBox();
            label3 = new Label();
            txtTituloEspaniol = new TextBox();
            label4 = new Label();
            txtAnio = new TextBox();
            label5 = new Label();
            txtISBN = new TextBox();
            label7 = new Label();
            txtEdicion = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label9 = new Label();
            btnGuardar = new Button();
            label10 = new Label();
            txtPortadaUrl = new TextBox();
            txtDescripcion_v1 = new TextBox();
            txtDescripcion = new Label();
            cmbEditorial = new ComboBox();
            cmbAutor = new ComboBox();
            clbGeneros = new CheckedListBox();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(241, 40);
            txtId.Name = "txtId";
            txtId.Size = new Size(214, 33);
            txtId.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 43);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 1;
            label1.Text = "ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 3;
            label2.Text = "Título original";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitulo.Location = new Point(241, 94);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(214, 33);
            txtTitulo.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 148);
            label3.Name = "label3";
            label3.Size = new Size(157, 25);
            label3.TabIndex = 5;
            label3.Text = "Título en Español";
            label3.Click += label3_Click;
            // 
            // txtTituloEspaniol
            // 
            txtTituloEspaniol.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTituloEspaniol.Location = new Point(241, 148);
            txtTituloEspaniol.Name = "txtTituloEspaniol";
            txtTituloEspaniol.Size = new Size(214, 33);
            txtTituloEspaniol.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 199);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 7;
            label4.Text = "Año de publicación";
            // 
            // txtAnio
            // 
            txtAnio.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnio.Location = new Point(241, 199);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(214, 33);
            txtAnio.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 248);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 9;
            label5.Text = "ISBN (10)";
            // 
            // txtISBN
            // 
            txtISBN.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtISBN.Location = new Point(241, 248);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(214, 33);
            txtISBN.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 302);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 13;
            label7.Text = "Edición";
            // 
            // txtEdicion
            // 
            txtEdicion.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEdicion.Location = new Point(241, 297);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(214, 33);
            txtEdicion.TabIndex = 12;
            txtEdicion.TextChanged += txtEdicion_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(12, 354);
            label8.Name = "label8";
            label8.Size = new Size(59, 25);
            label8.TabIndex = 15;
            label8.Text = "Autor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(13, 404);
            label6.Name = "label6";
            label6.Size = new Size(82, 25);
            label6.TabIndex = 17;
            label6.Text = "Editorial";
            label6.Click += label6_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(13, 455);
            label9.Name = "label9";
            label9.Size = new Size(82, 25);
            label9.TabIndex = 19;
            label9.Text = "Generos";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(241, 725);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(181, 42);
            btnGuardar.TabIndex = 24;
            btnGuardar.Text = "GUARDAR LIBRO";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 518);
            label10.Name = "label10";
            label10.Size = new Size(142, 25);
            label10.TabIndex = 21;
            label10.Text = "URL de portada";
            // 
            // txtPortadaUrl
            // 
            txtPortadaUrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPortadaUrl.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPortadaUrl.Location = new Point(241, 518);
            txtPortadaUrl.Name = "txtPortadaUrl";
            txtPortadaUrl.Size = new Size(214, 33);
            txtPortadaUrl.TabIndex = 20;
            // 
            // txtDescripcion_v1
            // 
            txtDescripcion_v1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDescripcion_v1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcion_v1.Location = new Point(241, 580);
            txtDescripcion_v1.Multiline = true;
            txtDescripcion_v1.Name = "txtDescripcion_v1";
            txtDescripcion_v1.Size = new Size(403, 139);
            txtDescripcion_v1.TabIndex = 22;
            txtDescripcion_v1.TextChanged += txtDescripcion_v1_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.AutoSize = true;
            txtDescripcion.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcion.Location = new Point(12, 580);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(111, 25);
            txtDescripcion.TabIndex = 24;
            txtDescripcion.Text = "Descripción";
            // 
            // cmbEditorial
            // 
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(241, 404);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(214, 23);
            cmbEditorial.TabIndex = 25;
            // 
            // cmbAutor
            // 
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(241, 354);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(214, 23);
            cmbAutor.TabIndex = 26;
            // 
            // clbGeneros
            // 
            clbGeneros.FormattingEnabled = true;
            clbGeneros.Location = new Point(241, 433);
            clbGeneros.Name = "clbGeneros";
            clbGeneros.Size = new Size(214, 76);
            clbGeneros.TabIndex = 27;
            clbGeneros.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // FormCrearLibro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 779);
            Controls.Add(clbGeneros);
            Controls.Add(cmbAutor);
            Controls.Add(cmbEditorial);
            Controls.Add(txtDescripcion);
            Controls.Add(txtDescripcion_v1);
            Controls.Add(txtPortadaUrl);
            Controls.Add(label10);
            Controls.Add(btnGuardar);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtEdicion);
            Controls.Add(label5);
            Controls.Add(txtISBN);
            Controls.Add(label4);
            Controls.Add(txtAnio);
            Controls.Add(label3);
            Controls.Add(txtTituloEspaniol);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(label1);
            Controls.Add(txtId);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormCrearLibro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCrearLibro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label1;
        private Label label2;
        private TextBox txtTitulo;
        private Label label3;
        private TextBox txtTituloEspaniol;
        private Label label4;
        private TextBox txtAnio;
        private Label label5;
        private TextBox txtISBN;
        private Label label7;
        private TextBox txtEdicion;
        private Label label8;
        private Label label6;
        private Label label9;
        private Button btnGuardar;
        private Label label10;
        private TextBox txtPortadaUrl;
        private TextBox txtDescripcion_v1;
        private Label txtDescripcion;
        private ComboBox cmbEditorial;
        private ComboBox cmbAutor;
        private CheckedListBox clbGeneros;
    }
}