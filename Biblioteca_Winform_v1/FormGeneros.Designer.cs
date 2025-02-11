namespace Biblioteca_Winform_v1
{
    partial class FormGeneros
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
            dataGridViewGeneros = new DataGridView();
            buttonCREAR_Genero = new Button();
            buttonMODIFICAR_Genero = new Button();
            buttonELIMINAR_Genero = new Button();
            btnActualizar_Generos = new Button();
            chkMostrarEliminados = new CheckBox();
            menuStrip1 = new MenuStrip();
            menúToolStripMenuItem = new ToolStripMenuItem();
            librosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            autoresToolStripMenuItem = new ToolStripMenuItem();
            editorialesToolStripMenuItem = new ToolStripMenuItem();
            génerosToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGeneros).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewGeneros
            // 
            dataGridViewGeneros.AllowUserToAddRows = false;
            dataGridViewGeneros.AllowUserToDeleteRows = false;
            dataGridViewGeneros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGeneros.Location = new Point(12, 47);
            dataGridViewGeneros.Name = "dataGridViewGeneros";
            dataGridViewGeneros.ReadOnly = true;
            dataGridViewGeneros.Size = new Size(1320, 479);
            dataGridViewGeneros.TabIndex = 3;
            // 
            // buttonCREAR_Genero
            // 
            buttonCREAR_Genero.Location = new Point(420, 560);
            buttonCREAR_Genero.Name = "buttonCREAR_Genero";
            buttonCREAR_Genero.Size = new Size(143, 67);
            buttonCREAR_Genero.TabIndex = 5;
            buttonCREAR_Genero.Text = "CREAR";
            buttonCREAR_Genero.UseVisualStyleBackColor = true;
            buttonCREAR_Genero.Click += buttonCREAR_Genero_Click;
            // 
            // buttonMODIFICAR_Genero
            // 
            buttonMODIFICAR_Genero.Location = new Point(590, 560);
            buttonMODIFICAR_Genero.Name = "buttonMODIFICAR_Genero";
            buttonMODIFICAR_Genero.Size = new Size(143, 67);
            buttonMODIFICAR_Genero.TabIndex = 6;
            buttonMODIFICAR_Genero.Text = "MODIFICAR";
            buttonMODIFICAR_Genero.UseVisualStyleBackColor = true;
            buttonMODIFICAR_Genero.Click += buttonMODIFICAR_Genero_Click;
            // 
            // buttonELIMINAR_Genero
            // 
            buttonELIMINAR_Genero.Location = new Point(760, 560);
            buttonELIMINAR_Genero.Name = "buttonELIMINAR_Genero";
            buttonELIMINAR_Genero.Size = new Size(143, 67);
            buttonELIMINAR_Genero.TabIndex = 7;
            buttonELIMINAR_Genero.Text = "ELIMINAR/RESTAURAR";
            buttonELIMINAR_Genero.UseVisualStyleBackColor = true;
            buttonELIMINAR_Genero.Click += buttonELIMINAR_Genero_Click;
            // 
            // btnActualizar_Generos
            // 
            btnActualizar_Generos.Location = new Point(203, 560);
            btnActualizar_Generos.Name = "btnActualizar_Generos";
            btnActualizar_Generos.Size = new Size(108, 51);
            btnActualizar_Generos.TabIndex = 8;
            btnActualizar_Generos.Text = "Actualizar";
            btnActualizar_Generos.UseVisualStyleBackColor = true;
            btnActualizar_Generos.Click += btnActualizar_Click;
            // 
            // chkMostrarEliminados
            // 
            chkMostrarEliminados.AutoSize = true;
            chkMostrarEliminados.Location = new Point(952, 591);
            chkMostrarEliminados.Name = "chkMostrarEliminados";
            chkMostrarEliminados.Size = new Size(173, 19);
            chkMostrarEliminados.TabIndex = 9;
            chkMostrarEliminados.Text = "Mostrar generos eliminados";
            chkMostrarEliminados.UseVisualStyleBackColor = true;
            chkMostrarEliminados.CheckedChanged += chkMostrarEliminados_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonFace;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menúToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 29);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            menúToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { librosToolStripMenuItem, usuariosToolStripMenuItem, pedidosToolStripMenuItem, autoresToolStripMenuItem, editorialesToolStripMenuItem, génerosToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menúToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            menúToolStripMenuItem.Size = new Size(62, 25);
            menúToolStripMenuItem.Text = "Menú";
            // 
            // librosToolStripMenuItem
            // 
            librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            librosToolStripMenuItem.Size = new Size(180, 26);
            librosToolStripMenuItem.Text = "Libros";
            librosToolStripMenuItem.Click += librosToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(180, 26);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(180, 26);
            pedidosToolStripMenuItem.Text = "Pedidos";
            pedidosToolStripMenuItem.Click += pedidosToolStripMenuItem_Click;
            // 
            // autoresToolStripMenuItem
            // 
            autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            autoresToolStripMenuItem.Size = new Size(180, 26);
            autoresToolStripMenuItem.Text = "Autores";
            autoresToolStripMenuItem.Click += autoresToolStripMenuItem_Click;
            // 
            // editorialesToolStripMenuItem
            // 
            editorialesToolStripMenuItem.Name = "editorialesToolStripMenuItem";
            editorialesToolStripMenuItem.Size = new Size(180, 26);
            editorialesToolStripMenuItem.Text = "Editoriales";
            editorialesToolStripMenuItem.Click += editorialesToolStripMenuItem_Click;
            // 
            // génerosToolStripMenuItem
            // 
            génerosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            génerosToolStripMenuItem.Name = "génerosToolStripMenuItem";
            génerosToolStripMenuItem.Size = new Size(180, 26);
            génerosToolStripMenuItem.Text = "Géneros";
            génerosToolStripMenuItem.Click += génerosToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(619, 5);
            label1.Name = "label1";
            label1.Size = new Size(104, 32);
            label1.TabIndex = 13;
            label1.Text = "Géneros";
            label1.Click += label1_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // FormGeneros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 661);
            Controls.Add(label1);
            Controls.Add(chkMostrarEliminados);
            Controls.Add(btnActualizar_Generos);
            Controls.Add(buttonELIMINAR_Genero);
            Controls.Add(buttonMODIFICAR_Genero);
            Controls.Add(buttonCREAR_Genero);
            Controls.Add(dataGridViewGeneros);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormGeneros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Géneros";
            FormClosing += FormGeneros_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewGeneros).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewGeneros;
        private Button buttonCREAR_Genero;
        private Button buttonMODIFICAR_Genero;
        private Button buttonELIMINAR_Genero;
        private Button btnActualizar_Generos;
        private CheckBox chkMostrarEliminados;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menúToolStripMenuItem;
        private ToolStripMenuItem librosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem autoresToolStripMenuItem;
        private ToolStripMenuItem editorialesToolStripMenuItem;
        private ToolStripMenuItem génerosToolStripMenuItem;
        private Label label1;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}