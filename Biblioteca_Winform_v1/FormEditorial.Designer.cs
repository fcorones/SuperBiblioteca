namespace Biblioteca_Winform_v1
{
    partial class FormEditorial
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
            dataGridViewEditoriales = new DataGridView();
            menuStrip1 = new MenuStrip();
            menúToolStripMenuItem = new ToolStripMenuItem();
            librosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            autoresToolStripMenuItem = new ToolStripMenuItem();
            editorialesToolStripMenuItem = new ToolStripMenuItem();
            génerosToolStripMenuItem = new ToolStripMenuItem();
            buttonCREAR_Editorial = new Button();
            buttonMODIFICAR_Editorial = new Button();
            buttonELIMINAR_Editorial = new Button();
            chkMostrarEditorialEliminados = new CheckBox();
            btnActualizar_Editorial = new Button();
            label1 = new Label();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEditoriales).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEditoriales
            // 
            dataGridViewEditoriales.AllowUserToAddRows = false;
            dataGridViewEditoriales.AllowUserToDeleteRows = false;
            dataGridViewEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEditoriales.Location = new Point(12, 47);
            dataGridViewEditoriales.Name = "dataGridViewEditoriales";
            dataGridViewEditoriales.ReadOnly = true;
            dataGridViewEditoriales.Size = new Size(1320, 479);
            dataGridViewEditoriales.TabIndex = 2;
            dataGridViewEditoriales.CellContentClick += dataGridViewEditoriales_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menúToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 29);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            menúToolStripMenuItem.Checked = true;
            menúToolStripMenuItem.CheckState = CheckState.Checked;
            menúToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { librosToolStripMenuItem, usuariosToolStripMenuItem, pedidosToolStripMenuItem, autoresToolStripMenuItem, editorialesToolStripMenuItem, génerosToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menúToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menúToolStripMenuItem.ForeColor = SystemColors.ControlText;
            menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            menúToolStripMenuItem.Size = new Size(62, 25);
            menúToolStripMenuItem.Text = "Menú";
            menúToolStripMenuItem.Click += menúToolStripMenuItem_Click;
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
            editorialesToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editorialesToolStripMenuItem.Name = "editorialesToolStripMenuItem";
            editorialesToolStripMenuItem.Size = new Size(180, 26);
            editorialesToolStripMenuItem.Text = "Editoriales";
            editorialesToolStripMenuItem.Click += editorialesToolStripMenuItem_Click;
            // 
            // génerosToolStripMenuItem
            // 
            génerosToolStripMenuItem.Name = "génerosToolStripMenuItem";
            génerosToolStripMenuItem.Size = new Size(180, 26);
            génerosToolStripMenuItem.Text = "Géneros";
            génerosToolStripMenuItem.Click += génerosToolStripMenuItem_Click;
            // 
            // buttonCREAR_Editorial
            // 
            buttonCREAR_Editorial.Location = new Point(420, 560);
            buttonCREAR_Editorial.Name = "buttonCREAR_Editorial";
            buttonCREAR_Editorial.Size = new Size(143, 67);
            buttonCREAR_Editorial.TabIndex = 4;
            buttonCREAR_Editorial.Text = "CREAR";
            buttonCREAR_Editorial.UseVisualStyleBackColor = true;
            buttonCREAR_Editorial.Click += buttonCREAR_Editorial_Click;
            // 
            // buttonMODIFICAR_Editorial
            // 
            buttonMODIFICAR_Editorial.Location = new Point(590, 560);
            buttonMODIFICAR_Editorial.Name = "buttonMODIFICAR_Editorial";
            buttonMODIFICAR_Editorial.Size = new Size(143, 67);
            buttonMODIFICAR_Editorial.TabIndex = 5;
            buttonMODIFICAR_Editorial.Text = "MODIFICAR";
            buttonMODIFICAR_Editorial.UseVisualStyleBackColor = true;
            buttonMODIFICAR_Editorial.Click += buttonMODIFICAR_Editorial_Click;
            // 
            // buttonELIMINAR_Editorial
            // 
            buttonELIMINAR_Editorial.Location = new Point(760, 560);
            buttonELIMINAR_Editorial.Name = "buttonELIMINAR_Editorial";
            buttonELIMINAR_Editorial.Size = new Size(143, 67);
            buttonELIMINAR_Editorial.TabIndex = 6;
            buttonELIMINAR_Editorial.Text = "ELIMINAR/RESTAURAR";
            buttonELIMINAR_Editorial.UseVisualStyleBackColor = true;
            buttonELIMINAR_Editorial.Click += buttonELIMINAR_Editorial_Click;
            // 
            // chkMostrarEditorialEliminados
            // 
            chkMostrarEditorialEliminados.AutoSize = true;
            chkMostrarEditorialEliminados.Location = new Point(952, 591);
            chkMostrarEditorialEliminados.Name = "chkMostrarEditorialEliminados";
            chkMostrarEditorialEliminados.Size = new Size(184, 19);
            chkMostrarEditorialEliminados.TabIndex = 9;
            chkMostrarEditorialEliminados.Text = "Mostrar editoriales eliminadas";
            chkMostrarEditorialEliminados.UseVisualStyleBackColor = true;
            chkMostrarEditorialEliminados.CheckedChanged += chkMostrarEditorialEliminados_CheckedChanged;
            // 
            // btnActualizar_Editorial
            // 
            btnActualizar_Editorial.Location = new Point(203, 560);
            btnActualizar_Editorial.Name = "btnActualizar_Editorial";
            btnActualizar_Editorial.Size = new Size(108, 51);
            btnActualizar_Editorial.TabIndex = 10;
            btnActualizar_Editorial.Text = "Actualizar";
            btnActualizar_Editorial.UseVisualStyleBackColor = true;
            btnActualizar_Editorial.Click += btnActualizar_Editorial_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(619, 5);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 12;
            label1.Text = "Editoriales";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // FormEditorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1344, 661);
            Controls.Add(label1);
            Controls.Add(btnActualizar_Editorial);
            Controls.Add(chkMostrarEditorialEliminados);
            Controls.Add(buttonELIMINAR_Editorial);
            Controls.Add(buttonMODIFICAR_Editorial);
            Controls.Add(buttonCREAR_Editorial);
            Controls.Add(dataGridViewEditoriales);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormEditorial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editoriales ";
            FormClosing += FormEditorial_FormClosing;
            Load += FormEditorial_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEditoriales).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewEditoriales;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menúToolStripMenuItem;
        private ToolStripMenuItem librosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem autoresToolStripMenuItem;
        private ToolStripMenuItem editorialesToolStripMenuItem;
        private ToolStripMenuItem génerosToolStripMenuItem;
        private Button buttonCREAR_Editorial;
        private Button buttonMODIFICAR_Editorial;
        private Button buttonELIMINAR_Editorial;
        private CheckBox chkMostrarEditorialEliminados;
        private Button btnActualizar_Editorial;
        private Label label1;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}