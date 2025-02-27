using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteca_Winform_v1
{
    public partial class FormReserva : Form
    {
        public FormReserva(List<object> reservas)
        {
            InitializeComponent();
            CargarReservas(reservas);
        }

        private void CargarReservas(List<object> reservas)
        {
            try
            {
                // Asignar la lista de reservas al DataGridView
                dataGridViewReservas.DataSource = reservas;

                // Configurar encabezados de las columnas
                dataGridViewReservas.Columns["Id"].HeaderText = "ID Préstamo";
                dataGridViewReservas.Columns["FechaPrestamo"].HeaderText = "Fecha Préstamo";
                dataGridViewReservas.Columns["FechaDevolucion"].HeaderText = "Fecha Devolución";
                dataGridViewReservas.Columns["Eliminado"].HeaderText = "Eliminado";
                //dataGridViewReservas.Columns["Activo"].HeaderText = "Activo";
                dataGridViewReservas.Columns["UsuarioNombre"].HeaderText = "Usuario";
                dataGridViewReservas.Columns["LibroNombre"].HeaderText = "Libro (Original)";
                dataGridViewReservas.Columns["LibroNombreEspaniol"].HeaderText = "Libro (Español)";

                // Ajustar ancho de columnas
                dataGridViewReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
