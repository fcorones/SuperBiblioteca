namespace Biblioteca_Winform_v1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewLibros = new DataGridView();
            btnActualizar = new Button();
            buttonCREAR = new Button();
            buttonMODIFICAR = new Button();
            buttonELIMINAR = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            librosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            autoresToolStripMenuItem = new ToolStripMenuItem();
            editorialesToolStripMenuItem = new ToolStripMenuItem();
            génerosToolStripMenuItem = new ToolStripMenuItem();
            chkMostrarEliminadosLibros = new CheckBox();
            label1 = new Label();
            chkMostrarPrestados = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibros).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewLibros
            // 
            dataGridViewLibros.AllowUserToAddRows = false;
            dataGridViewLibros.AllowUserToDeleteRows = false;
            dataGridViewLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibros.Location = new Point(12, 47);
            dataGridViewLibros.Name = "dataGridViewLibros";
            dataGridViewLibros.ReadOnly = true;
            dataGridViewLibros.Size = new Size(1320, 479);
            dataGridViewLibros.TabIndex = 0;
            dataGridViewLibros.CellContentClick += dataGridViewLibros_CellContentClick;
            dataGridViewLibros.RowHeaderMouseClick += dataGridViewLibros_RowHeaderMouseClick;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(203, 560);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(108, 51);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += buttonACTUALIZAR_Click;
            // 
            // buttonCREAR
            // 
            buttonCREAR.Location = new Point(420, 560);
            buttonCREAR.Name = "buttonCREAR";
            buttonCREAR.Size = new Size(143, 67);
            buttonCREAR.TabIndex = 2;
            buttonCREAR.Text = "CREAR";
            buttonCREAR.UseVisualStyleBackColor = true;
            buttonCREAR.Click += buttonCREAR_Click;
            // 
            // buttonMODIFICAR
            // 
            buttonMODIFICAR.Location = new Point(590, 560);
            buttonMODIFICAR.Name = "buttonMODIFICAR";
            buttonMODIFICAR.Size = new Size(143, 67);
            buttonMODIFICAR.TabIndex = 3;
            buttonMODIFICAR.Text = "MODIFICAR";
            buttonMODIFICAR.UseVisualStyleBackColor = true;
            buttonMODIFICAR.Click += buttonMODIFICAR_Click;
            // 
            // buttonELIMINAR
            // 
            buttonELIMINAR.Location = new Point(761, 560);
            buttonELIMINAR.Name = "buttonELIMINAR";
            buttonELIMINAR.Size = new Size(143, 67);
            buttonELIMINAR.TabIndex = 4;
            buttonELIMINAR.Text = "ELIMINAR/RESTAURAR";
            buttonELIMINAR.UseVisualStyleBackColor = true;
            buttonELIMINAR.Click += buttonELIMINAR_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 29);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { librosToolStripMenuItem, usuariosToolStripMenuItem, pedidosToolStripMenuItem, autoresToolStripMenuItem, editorialesToolStripMenuItem, génerosToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(62, 25);
            toolStripMenuItem1.Text = "Menú";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // librosToolStripMenuItem
            // 
            librosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            librosToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
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
            // chkMostrarEliminadosLibros
            // 
            chkMostrarEliminadosLibros.AutoSize = true;
            chkMostrarEliminadosLibros.Location = new Point(952, 591);
            chkMostrarEliminadosLibros.Name = "chkMostrarEliminadosLibros";
            chkMostrarEliminadosLibros.Size = new Size(160, 19);
            chkMostrarEliminadosLibros.TabIndex = 9;
            chkMostrarEliminadosLibros.Text = "Mostrar libros eliminados";
            chkMostrarEliminadosLibros.UseVisualStyleBackColor = true;
            chkMostrarEliminadosLibros.CheckedChanged += chkMostrarEliminadosLibros_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(619, 5);
            label1.Name = "label1";
            label1.Size = new Size(79, 32);
            label1.TabIndex = 10;
            label1.Text = "Libros";
            label1.Click += label1_Click;
            // 
            // chkMostrarPrestados
            // 
            chkMostrarPrestados.AutoSize = true;
            chkMostrarPrestados.Checked = true;
            chkMostrarPrestados.CheckState = CheckState.Checked;
            chkMostrarPrestados.Location = new Point(1134, 591);
            chkMostrarPrestados.Name = "chkMostrarPrestados";
            chkMostrarPrestados.Size = new Size(157, 19);
            chkMostrarPrestados.TabIndex = 11;
            chkMostrarPrestados.Text = "Mostrar libros en alquiler";
            chkMostrarPrestados.UseVisualStyleBackColor = true;
            chkMostrarPrestados.CheckedChanged += chkMostrar_Prestados_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 661);
            Controls.Add(chkMostrarPrestados);
            Controls.Add(label1);
            Controls.Add(chkMostrarEliminadosLibros);
            Controls.Add(buttonELIMINAR);
            Controls.Add(buttonMODIFICAR);
            Controls.Add(buttonCREAR);
            Controls.Add(btnActualizar);
            Controls.Add(dataGridViewLibros);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Biblioteca";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibros).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewLibros;
        private Button btnActualizar;
        private Button buttonCREAR;
        private Button buttonMODIFICAR;
        private Button buttonELIMINAR;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem librosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem autoresToolStripMenuItem;
        private CheckBox chkMostrarEliminadosLibros;
        private ToolStripMenuItem editorialesToolStripMenuItem;
        private ToolStripMenuItem génerosToolStripMenuItem;
        private Label label1;
        private CheckBox chkMostrarPrestados;
    }
}
