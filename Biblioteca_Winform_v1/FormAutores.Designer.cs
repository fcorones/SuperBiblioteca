namespace Biblioteca_Winform_v1
{
    partial class FormAutores
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
            dataGridViewAutores = new DataGridView();
            buttonCREAR_Autor = new Button();
            buttonMODIFICAR_Autor = new Button();
            buttonELIMINAR_Autor = new Button();
            btnActualizar_Autor = new Button();
            menuStrip1 = new MenuStrip();
            menúToolStripMenuItem = new ToolStripMenuItem();
            librosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            autoresToolStripMenuItem = new ToolStripMenuItem();
            editorialesToolStripMenuItem = new ToolStripMenuItem();
            génerosToolStripMenuItem = new ToolStripMenuItem();
            chkMostrarEliminados = new CheckBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutores).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewAutores
            // 
            dataGridViewAutores.AllowUserToAddRows = false;
            dataGridViewAutores.AllowUserToDeleteRows = false;
            dataGridViewAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAutores.Location = new Point(12, 47);
            dataGridViewAutores.Name = "dataGridViewAutores";
            dataGridViewAutores.ReadOnly = true;
            dataGridViewAutores.Size = new Size(1320, 479);
            dataGridViewAutores.TabIndex = 2;
            // 
            // buttonCREAR_Autor
            // 
            buttonCREAR_Autor.Location = new Point(420, 560);
            buttonCREAR_Autor.Name = "buttonCREAR_Autor";
            buttonCREAR_Autor.Size = new Size(143, 67);
            buttonCREAR_Autor.TabIndex = 4;
            buttonCREAR_Autor.Text = "CREAR";
            buttonCREAR_Autor.UseVisualStyleBackColor = true;
            buttonCREAR_Autor.Click += buttonCREAR_Autor_Click;
            // 
            // buttonMODIFICAR_Autor
            // 
            buttonMODIFICAR_Autor.Location = new Point(590, 560);
            buttonMODIFICAR_Autor.Name = "buttonMODIFICAR_Autor";
            buttonMODIFICAR_Autor.Size = new Size(143, 67);
            buttonMODIFICAR_Autor.TabIndex = 5;
            buttonMODIFICAR_Autor.Text = "MODIFICAR";
            buttonMODIFICAR_Autor.UseVisualStyleBackColor = true;
            buttonMODIFICAR_Autor.Click += buttonMODIFICAR_Autor_Click;
            // 
            // buttonELIMINAR_Autor
            // 
            buttonELIMINAR_Autor.Location = new Point(760, 560);
            buttonELIMINAR_Autor.Name = "buttonELIMINAR_Autor";
            buttonELIMINAR_Autor.Size = new Size(143, 67);
            buttonELIMINAR_Autor.TabIndex = 6;
            buttonELIMINAR_Autor.Text = "ELIMINAR/RESTAURAR";
            buttonELIMINAR_Autor.UseVisualStyleBackColor = true;
            buttonELIMINAR_Autor.Click += buttonELIMINAR_Autor_Click;
            // 
            // btnActualizar_Autor
            // 
            btnActualizar_Autor.Location = new Point(203, 560);
            btnActualizar_Autor.Name = "btnActualizar_Autor";
            btnActualizar_Autor.Size = new Size(108, 51);
            btnActualizar_Autor.TabIndex = 7;
            btnActualizar_Autor.Text = "Actualizar";
            btnActualizar_Autor.UseVisualStyleBackColor = true;
            btnActualizar_Autor.Click += btnActualizar_Autor_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menúToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 29);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            menúToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { librosToolStripMenuItem, usuariosToolStripMenuItem, pedidosToolStripMenuItem, autoresToolStripMenuItem, editorialesToolStripMenuItem, génerosToolStripMenuItem });
            menúToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            menúToolStripMenuItem.Size = new Size(62, 25);
            menúToolStripMenuItem.Text = "Menú";
            // 
            // librosToolStripMenuItem
            // 
            librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            librosToolStripMenuItem.Size = new Size(152, 26);
            librosToolStripMenuItem.Text = "Libros";
            librosToolStripMenuItem.Click += librosToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(152, 26);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(152, 26);
            pedidosToolStripMenuItem.Text = "Pedidos";
            pedidosToolStripMenuItem.Click += pedidosToolStripMenuItem_Click;
            // 
            // autoresToolStripMenuItem
            // 
            autoresToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            autoresToolStripMenuItem.Size = new Size(152, 26);
            autoresToolStripMenuItem.Text = "Autores";
            autoresToolStripMenuItem.Click += autoresToolStripMenuItem_Click;
            // 
            // editorialesToolStripMenuItem
            // 
            editorialesToolStripMenuItem.Name = "editorialesToolStripMenuItem";
            editorialesToolStripMenuItem.Size = new Size(152, 26);
            editorialesToolStripMenuItem.Text = "Editoriales";
            editorialesToolStripMenuItem.Click += editorialesToolStripMenuItem_Click;
            // 
            // génerosToolStripMenuItem
            // 
            génerosToolStripMenuItem.Name = "génerosToolStripMenuItem";
            génerosToolStripMenuItem.Size = new Size(152, 26);
            génerosToolStripMenuItem.Text = "Géneros";
            génerosToolStripMenuItem.Click += génerosToolStripMenuItem_Click;
            // 
            // chkMostrarEliminados
            // 
            chkMostrarEliminados.AutoSize = true;
            chkMostrarEliminados.Location = new Point(952, 591);
            chkMostrarEliminados.Name = "chkMostrarEliminados";
            chkMostrarEliminados.Size = new Size(170, 19);
            chkMostrarEliminados.TabIndex = 9;
            chkMostrarEliminados.Text = "Mostrar autores eliminados";
            chkMostrarEliminados.UseVisualStyleBackColor = true;
            chkMostrarEliminados.CheckedChanged += chkMostrarEliminados_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(619, 5);
            label1.Name = "label1";
            label1.Size = new Size(99, 32);
            label1.TabIndex = 11;
            label1.Text = "Autores";
            // 
            // FormAutores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 661);
            Controls.Add(label1);
            Controls.Add(chkMostrarEliminados);
            Controls.Add(btnActualizar_Autor);
            Controls.Add(buttonELIMINAR_Autor);
            Controls.Add(buttonMODIFICAR_Autor);
            Controls.Add(buttonCREAR_Autor);
            Controls.Add(dataGridViewAutores);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormAutores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAutores";
            FormClosing += FormAutores_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutores).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewAutores;
        private Button buttonCREAR_Autor;
        private Button buttonMODIFICAR_Autor;
        private Button buttonELIMINAR_Autor;
        private Button btnActualizar_Autor;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menúToolStripMenuItem;
        private ToolStripMenuItem librosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem autoresToolStripMenuItem;
        private CheckBox chkMostrarEliminados;
        private ToolStripMenuItem editorialesToolStripMenuItem;
        private ToolStripMenuItem génerosToolStripMenuItem;
        private Label label1;
    }
}