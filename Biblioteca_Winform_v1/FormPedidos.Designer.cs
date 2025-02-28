namespace Biblioteca_Winform_v1
{
    partial class FormPedidos
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
            dataGridViewPedidos = new DataGridView();
            btnActualizar_Pedido = new Button();
            buttonCREAR_Pedido = new Button();
            buttonMODIFICAR_Pedido = new Button();
            buttonELIMINAR_Pedido = new Button();
            chkMostrarEliminados = new CheckBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            menúToolStripMenuItem = new ToolStripMenuItem();
            librosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            autoresToolStripMenuItem = new ToolStripMenuItem();
            editorialesToolStripMenuItem = new ToolStripMenuItem();
            génerosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            chkMostrarActivos = new CheckBox();
            comboBoxEstado = new ComboBox();
            buttonCambiarEstado = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AllowUserToAddRows = false;
            dataGridViewPedidos.AllowUserToDeleteRows = false;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(12, 47);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.Size = new Size(1320, 479);
            dataGridViewPedidos.TabIndex = 3;
            dataGridViewPedidos.CellContentClick += dataGridViewPedidos_CellContentClick;
            // 
            // btnActualizar_Pedido
            // 
            btnActualizar_Pedido.Location = new Point(203, 560);
            btnActualizar_Pedido.Name = "btnActualizar_Pedido";
            btnActualizar_Pedido.Size = new Size(108, 51);
            btnActualizar_Pedido.TabIndex = 8;
            btnActualizar_Pedido.Text = "Actualizar";
            btnActualizar_Pedido.UseVisualStyleBackColor = true;
            btnActualizar_Pedido.Click += btnActualizar_Pedido_Click;
            // 
            // buttonCREAR_Pedido
            // 
            buttonCREAR_Pedido.Location = new Point(420, 560);
            buttonCREAR_Pedido.Name = "buttonCREAR_Pedido";
            buttonCREAR_Pedido.Size = new Size(143, 67);
            buttonCREAR_Pedido.TabIndex = 9;
            buttonCREAR_Pedido.Text = "CREAR PEDIDO";
            buttonCREAR_Pedido.UseVisualStyleBackColor = true;
            buttonCREAR_Pedido.Click += buttonCREAR_Pedido_Click;
            // 
            // buttonMODIFICAR_Pedido
            // 
            buttonMODIFICAR_Pedido.Location = new Point(35, 588);
            buttonMODIFICAR_Pedido.Name = "buttonMODIFICAR_Pedido";
            buttonMODIFICAR_Pedido.Size = new Size(75, 44);
            buttonMODIFICAR_Pedido.TabIndex = 10;
            buttonMODIFICAR_Pedido.Text = "MARCAR \r\nRETIRADO / NO RETIRADO";
            buttonMODIFICAR_Pedido.UseVisualStyleBackColor = true;
            buttonMODIFICAR_Pedido.Click += buttonMODIFICAR_Pedido_Click;
            // 
            // buttonELIMINAR_Pedido
            // 
            buttonELIMINAR_Pedido.Location = new Point(591, 560);
            buttonELIMINAR_Pedido.Name = "buttonELIMINAR_Pedido";
            buttonELIMINAR_Pedido.Size = new Size(143, 67);
            buttonELIMINAR_Pedido.TabIndex = 11;
            buttonELIMINAR_Pedido.Text = "ELIMINAR/RESTAURAR\r\nPEDIDO\r\n";
            buttonELIMINAR_Pedido.UseVisualStyleBackColor = true;
            buttonELIMINAR_Pedido.Click += buttonELIMINAR_Pedido_Click;
            // 
            // chkMostrarEliminados
            // 
            chkMostrarEliminados.AutoSize = true;
            chkMostrarEliminados.Location = new Point(945, 585);
            chkMostrarEliminados.Name = "chkMostrarEliminados";
            chkMostrarEliminados.Size = new Size(173, 19);
            chkMostrarEliminados.TabIndex = 12;
            chkMostrarEliminados.Text = "Mostrar pedidos eliminados";
            chkMostrarEliminados.UseVisualStyleBackColor = true;
            chkMostrarEliminados.CheckedChanged += chkMostrarEliminados_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(619, 5);
            label1.Name = "label1";
            label1.Size = new Size(98, 32);
            label1.TabIndex = 13;
            label1.Text = "Pedidos";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menúToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 29);
            menuStrip1.TabIndex = 14;
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
            librosToolStripMenuItem.Size = new Size(174, 26);
            librosToolStripMenuItem.Text = "Libros";
            librosToolStripMenuItem.Click += librosToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(174, 26);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(174, 26);
            pedidosToolStripMenuItem.Text = "Pedidos";
            pedidosToolStripMenuItem.Click += pedidosToolStripMenuItem_Click;
            // 
            // autoresToolStripMenuItem
            // 
            autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            autoresToolStripMenuItem.Size = new Size(174, 26);
            autoresToolStripMenuItem.Text = "Autores";
            autoresToolStripMenuItem.Click += autoresToolStripMenuItem_Click;
            // 
            // editorialesToolStripMenuItem
            // 
            editorialesToolStripMenuItem.Name = "editorialesToolStripMenuItem";
            editorialesToolStripMenuItem.Size = new Size(174, 26);
            editorialesToolStripMenuItem.Text = "Editoriales";
            editorialesToolStripMenuItem.Click += editorialesToolStripMenuItem_Click;
            // 
            // génerosToolStripMenuItem
            // 
            génerosToolStripMenuItem.Name = "génerosToolStripMenuItem";
            génerosToolStripMenuItem.Size = new Size(174, 26);
            génerosToolStripMenuItem.Text = "Géneros";
            génerosToolStripMenuItem.Click += génerosToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(174, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // chkMostrarActivos
            // 
            chkMostrarActivos.AutoSize = true;
            chkMostrarActivos.Location = new Point(1135, 585);
            chkMostrarActivos.Name = "chkMostrarActivos";
            chkMostrarActivos.Size = new Size(161, 19);
            chkMostrarActivos.TabIndex = 15;
            chkMostrarActivos.Text = "Mostrar pedidos retirados";
            chkMostrarActivos.UseVisualStyleBackColor = true;
            chkMostrarActivos.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Items.AddRange(new object[] { "Reservado", "Retirado", "Devuelto" });
            comboBoxEstado.Location = new Point(762, 568);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(121, 23);
            comboBoxEstado.TabIndex = 16;
            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
            // 
            // buttonCambiarEstado
            // 
            buttonCambiarEstado.Location = new Point(762, 599);
            buttonCambiarEstado.Name = "buttonCambiarEstado";
            buttonCambiarEstado.Size = new Size(100, 23);
            buttonCambiarEstado.TabIndex = 17;
            buttonCambiarEstado.Text = "Cambiar Estado";
            buttonCambiarEstado.UseVisualStyleBackColor = true;
            buttonCambiarEstado.Click += buttonCambiarEstado_Click;
            // 
            // FormPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 661);
            Controls.Add(buttonCambiarEstado);
            Controls.Add(comboBoxEstado);
            Controls.Add(chkMostrarActivos);
            Controls.Add(label1);
            Controls.Add(chkMostrarEliminados);
            Controls.Add(buttonELIMINAR_Pedido);
            Controls.Add(buttonMODIFICAR_Pedido);
            Controls.Add(buttonCREAR_Pedido);
            Controls.Add(btnActualizar_Pedido);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormPedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos de los clientes";
            FormClosing += FormPedidos_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewPedidos;
        private Button btnActualizar_Pedido;
        private Button buttonCREAR_Pedido;
        private Button buttonMODIFICAR_Pedido;
        private Button buttonELIMINAR_Pedido;
        private CheckBox chkMostrarEliminados;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menúToolStripMenuItem;
        private ToolStripMenuItem librosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem autoresToolStripMenuItem;
        private ToolStripMenuItem editorialesToolStripMenuItem;
        private ToolStripMenuItem génerosToolStripMenuItem;
        private CheckBox checkBox1;
        private CheckBox chkMostrarActivos;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ComboBox comboBoxEstado;
        private Button buttonCambiarEstado;
    }
}