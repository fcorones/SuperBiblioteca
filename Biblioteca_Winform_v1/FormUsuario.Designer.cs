namespace Biblioteca_Winform_v1
{
    partial class FormUsuario
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
            dataGridViewUsuarios = new DataGridView();
            buttonCREAR_Usuario = new Button();
            buttonMODIFICAR_Usuario = new Button();
            buttonELIMINAR_Usuario = new Button();
            btnActualizar_Usuario = new Button();
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
            btnVerReservasUsuario = new Button();
            checkUsrPedidos = new CheckBox();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(12, 47);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.Size = new Size(1320, 479);
            dataGridViewUsuarios.TabIndex = 1;
            dataGridViewUsuarios.CellContentClick += dataGridViewUsuarios_CellContentClick;
            // 
            // buttonCREAR_Usuario
            // 
            buttonCREAR_Usuario.Location = new Point(420, 560);
            buttonCREAR_Usuario.Name = "buttonCREAR_Usuario";
            buttonCREAR_Usuario.Size = new Size(143, 67);
            buttonCREAR_Usuario.TabIndex = 3;
            buttonCREAR_Usuario.Text = "CREAR";
            buttonCREAR_Usuario.UseVisualStyleBackColor = true;
            buttonCREAR_Usuario.Click += buttonCREAR_Usuario_Click;
            // 
            // buttonMODIFICAR_Usuario
            // 
            buttonMODIFICAR_Usuario.Location = new Point(590, 560);
            buttonMODIFICAR_Usuario.Name = "buttonMODIFICAR_Usuario";
            buttonMODIFICAR_Usuario.Size = new Size(143, 67);
            buttonMODIFICAR_Usuario.TabIndex = 4;
            buttonMODIFICAR_Usuario.Text = "MODIFICAR";
            buttonMODIFICAR_Usuario.UseVisualStyleBackColor = true;
            buttonMODIFICAR_Usuario.Click += buttonMODIFICAR_Usuario_ClickAsync;
            // 
            // buttonELIMINAR_Usuario
            // 
            buttonELIMINAR_Usuario.Location = new Point(760, 560);
            buttonELIMINAR_Usuario.Name = "buttonELIMINAR_Usuario";
            buttonELIMINAR_Usuario.Size = new Size(143, 67);
            buttonELIMINAR_Usuario.TabIndex = 5;
            buttonELIMINAR_Usuario.Text = "ELIMINAR/RESTAURAR";
            buttonELIMINAR_Usuario.UseVisualStyleBackColor = true;
            buttonELIMINAR_Usuario.Click += buttonELIMINAR_Usuario_Click;
            // 
            // btnActualizar_Usuario
            // 
            btnActualizar_Usuario.Location = new Point(203, 560);
            btnActualizar_Usuario.Name = "btnActualizar_Usuario";
            btnActualizar_Usuario.Size = new Size(108, 51);
            btnActualizar_Usuario.TabIndex = 6;
            btnActualizar_Usuario.Text = "Actualizar";
            btnActualizar_Usuario.UseVisualStyleBackColor = true;
            btnActualizar_Usuario.Click += btnActualizar_Usuario_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menúToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 29);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            menúToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { librosToolStripMenuItem, usuariosToolStripMenuItem, pedidosToolStripMenuItem, autoresToolStripMenuItem, editorialesToolStripMenuItem, génerosToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menúToolStripMenuItem.Font = new Font("Segoe UI", 12F);
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
            usuariosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            génerosToolStripMenuItem.Name = "génerosToolStripMenuItem";
            génerosToolStripMenuItem.Size = new Size(180, 26);
            génerosToolStripMenuItem.Text = "Géneros";
            génerosToolStripMenuItem.Click += génerosToolStripMenuItem_Click;
            // 
            // chkMostrarEliminados
            // 
            chkMostrarEliminados.AutoSize = true;
            chkMostrarEliminados.Location = new Point(933, 592);
            chkMostrarEliminados.Name = "chkMostrarEliminados";
            chkMostrarEliminados.Size = new Size(175, 19);
            chkMostrarEliminados.TabIndex = 8;
            chkMostrarEliminados.Text = "Mostrar usuarios eliminados";
            chkMostrarEliminados.UseVisualStyleBackColor = true;
            chkMostrarEliminados.CheckedChanged += chkMostrarEliminados_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(619, 5);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 13;
            label1.Text = "Usuarios";
            // 
            // btnVerReservasUsuario
            // 
            btnVerReservasUsuario.Location = new Point(72, 559);
            btnVerReservasUsuario.Name = "btnVerReservasUsuario";
            btnVerReservasUsuario.Size = new Size(108, 51);
            btnVerReservasUsuario.TabIndex = 14;
            btnVerReservasUsuario.Text = "Ver reservas del usuario";
            btnVerReservasUsuario.UseVisualStyleBackColor = true;
            btnVerReservasUsuario.Click += btn_VerReservaUsuario_Click;
            // 
            // checkUsrPedidos
            // 
            checkUsrPedidos.AutoSize = true;
            checkUsrPedidos.Location = new Point(1114, 592);
            checkUsrPedidos.Name = "checkUsrPedidos";
            checkUsrPedidos.Size = new Size(182, 19);
            checkUsrPedidos.TabIndex = 15;
            checkUsrPedidos.Text = "Mostrar usuarios con pedidos";
            checkUsrPedidos.UseVisualStyleBackColor = true;
            checkUsrPedidos.CheckedChanged += checkUsrPedidos_CheckedChanged;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 661);
            Controls.Add(checkUsrPedidos);
            Controls.Add(btnVerReservasUsuario);
            Controls.Add(label1);
            Controls.Add(chkMostrarEliminados);
            Controls.Add(btnActualizar_Usuario);
            Controls.Add(buttonELIMINAR_Usuario);
            Controls.Add(buttonMODIFICAR_Usuario);
            Controls.Add(buttonCREAR_Usuario);
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            FormClosing += FormUsuario_FormClosing;
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUsuarios;
        private Button buttonCREAR_Usuario;
        private Button buttonMODIFICAR_Usuario;
        private Button buttonELIMINAR_Usuario;
        private Button btnActualizar_Usuario;
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
        private Button btnVerReservasUsuario;
        private CheckBox checkUsrPedidos;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}