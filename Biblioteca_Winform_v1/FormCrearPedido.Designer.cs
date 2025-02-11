namespace Biblioteca_Winform_v1
{
    partial class FormCrearPedido
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
            label1 = new Label();
            dataGridViewLibroAPedir = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            btnGuardarPEDIDO = new Button();
            txtId_Libro = new TextBox();
            txtId_Cliente = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnActualizar_Libro = new Button();
            btnActualizar_Cliente = new Button();
            dtpFecha_Retiro = new DateTimePicker();
            dtpFecha_Devolucion = new DateTimePicker();
            monthCalendarDisponibilidad = new MonthCalendar();
            lblEstadoPrestamo = new Label();
            btnVer_Reserva = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibroAPedir).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(12, 88);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.Size = new Size(748, 195);
            dataGridViewUsuarios.TabIndex = 0;
            dataGridViewUsuarios.CellClick += dataGridViewUsuarios_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(172, 25);
            label1.TabIndex = 1;
            label1.Text = "Seleccione su cliente";
            // 
            // dataGridViewLibroAPedir
            // 
            dataGridViewLibroAPedir.AllowUserToAddRows = false;
            dataGridViewLibroAPedir.AllowUserToDeleteRows = false;
            dataGridViewLibroAPedir.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibroAPedir.Location = new Point(12, 344);
            dataGridViewLibroAPedir.Name = "dataGridViewLibroAPedir";
            dataGridViewLibroAPedir.ReadOnly = true;
            dataGridViewLibroAPedir.Size = new Size(748, 212);
            dataGridViewLibroAPedir.TabIndex = 2;
            dataGridViewLibroAPedir.CellClick += dataGridViewLibroAPedir_CellClick;
            dataGridViewLibroAPedir.CellContentClick += dataGridViewLibroAPedir_CellContentClickAsync;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(12, 304);
            label2.Name = "label2";
            label2.Size = new Size(211, 25);
            label2.TabIndex = 3;
            label2.Text = "Seleccione libro a alquilar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(597, 16);
            label3.Name = "label3";
            label3.Size = new Size(146, 25);
            label3.TabIndex = 4;
            label3.Text = "CREAR PEDIDO";
            // 
            // btnGuardarPEDIDO
            // 
            btnGuardarPEDIDO.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarPEDIDO.Location = new Point(541, 610);
            btnGuardarPEDIDO.Name = "btnGuardarPEDIDO";
            btnGuardarPEDIDO.Size = new Size(181, 42);
            btnGuardarPEDIDO.TabIndex = 22;
            btnGuardarPEDIDO.Text = "GUARDAR ";
            btnGuardarPEDIDO.UseVisualStyleBackColor = true;
            btnGuardarPEDIDO.Click += btnGuardarPEDIDO_Click;
            // 
            // txtId_Libro
            // 
            txtId_Libro.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId_Libro.Location = new Point(971, 46);
            txtId_Libro.Name = "txtId_Libro";
            txtId_Libro.Size = new Size(214, 33);
            txtId_Libro.TabIndex = 23;
            // 
            // txtId_Cliente
            // 
            txtId_Cliente.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId_Cliente.Location = new Point(971, 110);
            txtId_Cliente.Name = "txtId_Cliente";
            txtId_Cliente.Size = new Size(214, 33);
            txtId_Cliente.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(870, 46);
            label4.Name = "label4";
            label4.Size = new Size(75, 25);
            label4.TabIndex = 27;
            label4.Text = "ID Libro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(857, 110);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 28;
            label5.Text = "ID Cliente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(825, 174);
            label6.Name = "label6";
            label6.Size = new Size(129, 25);
            label6.TabIndex = 29;
            label6.Text = "Fecha de retiro";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F);
            label7.Location = new Point(780, 237);
            label7.Name = "label7";
            label7.Size = new Size(174, 25);
            label7.TabIndex = 30;
            label7.Text = "Fecha de devolución";
            // 
            // btnActualizar_Libro
            // 
            btnActualizar_Libro.Location = new Point(685, 315);
            btnActualizar_Libro.Name = "btnActualizar_Libro";
            btnActualizar_Libro.Size = new Size(75, 23);
            btnActualizar_Libro.TabIndex = 31;
            btnActualizar_Libro.Text = "Actualizar";
            btnActualizar_Libro.UseVisualStyleBackColor = true;
            btnActualizar_Libro.Click += btnActualizar_Libro_Click_1;
            // 
            // btnActualizar_Cliente
            // 
            btnActualizar_Cliente.Location = new Point(685, 59);
            btnActualizar_Cliente.Name = "btnActualizar_Cliente";
            btnActualizar_Cliente.Size = new Size(75, 23);
            btnActualizar_Cliente.TabIndex = 32;
            btnActualizar_Cliente.Text = "Actualizar";
            btnActualizar_Cliente.UseVisualStyleBackColor = true;
            btnActualizar_Cliente.Click += btnActualizar_Cliente_Click_1;
            // 
            // dtpFecha_Retiro
            // 
            dtpFecha_Retiro.CustomFormat = "dd-MM-yyyy";
            dtpFecha_Retiro.Font = new Font("Segoe UI", 12F);
            dtpFecha_Retiro.Format = DateTimePickerFormat.Custom;
            dtpFecha_Retiro.Location = new Point(971, 175);
            dtpFecha_Retiro.Name = "dtpFecha_Retiro";
            dtpFecha_Retiro.Size = new Size(214, 29);
            dtpFecha_Retiro.TabIndex = 33;
            // 
            // dtpFecha_Devolucion
            // 
            dtpFecha_Devolucion.CustomFormat = "dd-MM-yyyy";
            dtpFecha_Devolucion.Font = new Font("Segoe UI", 12F);
            dtpFecha_Devolucion.Format = DateTimePickerFormat.Custom;
            dtpFecha_Devolucion.Location = new Point(971, 233);
            dtpFecha_Devolucion.Name = "dtpFecha_Devolucion";
            dtpFecha_Devolucion.Size = new Size(214, 29);
            dtpFecha_Devolucion.TabIndex = 34;
            // 
            // monthCalendarDisponibilidad
            // 
            monthCalendarDisponibilidad.CalendarDimensions = new Size(2, 2);
            monthCalendarDisponibilidad.Font = new Font("Segoe UI", 9F);
            monthCalendarDisponibilidad.Location = new Point(803, 343);
            monthCalendarDisponibilidad.Name = "monthCalendarDisponibilidad";
            monthCalendarDisponibilidad.TabIndex = 35;
            // 
            // lblEstadoPrestamo
            // 
            lblEstadoPrestamo.AutoSize = true;
            lblEstadoPrestamo.Font = new Font("Segoe UI", 13F);
            lblEstadoPrestamo.Location = new Point(803, 304);
            lblEstadoPrestamo.Name = "lblEstadoPrestamo";
            lblEstadoPrestamo.Size = new Size(0, 25);
            lblEstadoPrestamo.TabIndex = 36;
            // 
            // btnVer_Reserva
            // 
            btnVer_Reserva.Location = new Point(597, 59);
            btnVer_Reserva.Name = "btnVer_Reserva";
            btnVer_Reserva.Size = new Size(75, 23);
            btnVer_Reserva.TabIndex = 37;
            btnVer_Reserva.Text = "Ver reserva";
            btnVer_Reserva.UseVisualStyleBackColor = true;
            btnVer_Reserva.Click += btnVer_Reserva_Click;
            // 
            // FormCrearPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 680);
            Controls.Add(btnVer_Reserva);
            Controls.Add(lblEstadoPrestamo);
            Controls.Add(monthCalendarDisponibilidad);
            Controls.Add(dtpFecha_Devolucion);
            Controls.Add(dtpFecha_Retiro);
            Controls.Add(btnActualizar_Cliente);
            Controls.Add(btnActualizar_Libro);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtId_Cliente);
            Controls.Add(txtId_Libro);
            Controls.Add(btnGuardarPEDIDO);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewLibroAPedir);
            Controls.Add(label1);
            Controls.Add(dataGridViewUsuarios);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormCrearPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crear pedido";
            Load += FormCrearPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibroAPedir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUsuarios;
        private Label label1;
        private DataGridView dataGridViewLibroAPedir;
        private Label label2;
        private Label label3;
        private Button btnGuardarPEDIDO;
        private TextBox txtId_Libro;
        private TextBox txtId_Cliente;
        private TextBox txtFecha_Devolucion;
        private TextBox txtFecha_Retiro;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnActualizar_Libro;
        private Button btnActualizar_Cliente;
        private DateTimePicker dtpFecha_Retiro;
        private DateTimePicker dtpFecha_Devolucion;
        private MonthCalendar monthCalendarDisponibilidad;
        private Label lblEstadoPrestamo;
        private Button btnVer_Reserva;
    }
}