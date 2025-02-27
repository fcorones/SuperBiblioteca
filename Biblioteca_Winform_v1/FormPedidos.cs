using BibliotecaDeClasesWinformYBlazor.Servicios;
using BibliotecaDeClasesWinformYBlazor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Biblioteca_Winform_v1
{
    public partial class FormPedidos : Form
    {

        private bool _mostrarEliminados = false;

        private readonly PrestamoService _prestamoService;
        private readonly UsuarioService _usuarioService;
        private readonly LibroService _libroService;

        public FormPedidos()
        {
            InitializeComponent();
             //Instancia de AuthContext para obtener el token.
            var authContext = new AuthContext();
            //Se toma el token del context.
            authContext.UserToken = AuthContext.GetGlobalToken();

            //Se pasa el context con el token a los services.
            //El HttpClientProvider del Service ahora puede inyectar el token en el encabezado HTTP
            _prestamoService = new PrestamoService(authContext);
            _usuarioService = new UsuarioService(authContext);
            _libroService = new LibroService(authContext);

            SincronizarEstadoLibrosAsync();

            btnActualizar_Pedido_Click(null, null);
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.Show();
            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUsuario();
            form.Show();
            this.Hide();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ya estoy en pedidos
        }

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormAutores();
            form.Show();
            this.Hide();
        }

        private void editorialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormEditorial();
            form.Show();
            this.Hide();
        }

        private void génerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormGeneros();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private async void btnActualizar_Pedido_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la lista de préstamos desde la API
                var prestamos = await _prestamoService.GetPrestamosAsync();

                // Filtrar eliminados
                if (!_mostrarEliminados)
                {
                    prestamos = prestamos.Where(p => !p.Eliminado).ToList();
                }

                // Filtrar por pedidos retirados si el CheckBox está marcado
                if (chkMostrarActivos.Checked)
                {
                    prestamos = prestamos.Where(p => p.Estado == EstadoPrestamo.Retirado).ToList(); // Cambiar aquí
                }

                // Obtener más info
                var usuarios = await _usuarioService.GetUsuariosAsync();
                var libros = await _libroService.GetLibrosAsync();

                // Transformar los datos para mostrarlos en el DataGridView
                var prestamosParaMostrar = prestamos.Select(prestamo => new
                {
                    prestamo.Id,
                    prestamo.Eliminado,
                    Estado = prestamo.Estado, // Cambiar aquí
                    LibroNombre = libros.FirstOrDefault(l => l.Id == prestamo.LibroId)?.Titulo ?? "Desconocido",
                    LibroNombreEspaniol = libros.FirstOrDefault(l => l.Id == prestamo.LibroId)?.TituloEspaniol ?? "N/A",
                    prestamo.LibroId,
                    NumeroEdicion = libros.FirstOrDefault(l => l.Id == prestamo.LibroId)?.NumeroEdicion ?? 0,
                    LibroEditorial = libros.FirstOrDefault(l => l.Id == prestamo.LibroId)?.NombreEditorial ?? "N/A",
                    UsuarioNombre = usuarios.FirstOrDefault(u => u.Id == prestamo.UsuarioId)?.Nombre ?? "Desconocido",
                    prestamo.UsuarioId,
                    prestamo.FechaPrestamo,
                    prestamo.FechaDevolucion
                })
                // Primero los no eliminados, luego los eliminados 
                .OrderBy(prestamo => prestamo.Eliminado)
                .ThenBy(prestamo => prestamo.Id)
                .ToList();

                // Asignar la lista transformada al DataGridView
                dataGridViewPedidos.DataSource = prestamosParaMostrar;

                // Personalizar encabezados de columnas
                dataGridViewPedidos.Columns["Id"].HeaderText = "ID";
                dataGridViewPedidos.Columns["FechaPrestamo"].HeaderText = "Fecha de Préstamo";
                dataGridViewPedidos.Columns["FechaDevolucion"].HeaderText = "Fecha de Devolución";
                dataGridViewPedidos.Columns["UsuarioNombre"].HeaderText = "Nombre del Usuario";
                dataGridViewPedidos.Columns["LibroNombre"].HeaderText = "Título del Libro";
                dataGridViewPedidos.Columns["LibroEditorial"].HeaderText = "Editorial";
                dataGridViewPedidos.Columns["NumeroEdicion"].HeaderText = "Edición";
                dataGridViewPedidos.Columns["LibroNombreEspaniol"].HeaderText = "Título del Libro";
                dataGridViewPedidos.Columns["LibroId"].HeaderText = "ID Libro";
                dataGridViewPedidos.Columns["UsuarioId"].HeaderText = "ID Usuario";

                dataGridViewPedidos.Columns["Id"].Width = 50;
                dataGridViewPedidos.Columns["Eliminado"].Width = 65;
                dataGridViewPedidos.Columns["Estado"].Width = 100; // Cambiar aquí
                dataGridViewPedidos.Columns["LibroId"].Width = 50;
                dataGridViewPedidos.Columns["NumeroEdicion"].Width = 50;
                dataGridViewPedidos.Columns["UsuarioId"].Width = 50;
                dataGridViewPedidos.Columns["LibroNombre"].Width = 220;
                dataGridViewPedidos.Columns["LibroNombreEspaniol"].Width = 220;

                // Configurar la columna Estado
                if (dataGridViewPedidos.Columns["Estado"] != null)
                {
                    var columnaEstado = dataGridViewPedidos.Columns["Estado"];
                    columnaEstado.HeaderText = "Estado";
                    columnaEstado.Visible = true;
                    columnaEstado.ReadOnly = true;

                    // Formatear el valor del estado como texto
                    columnaEstado.DefaultCellStyle.Format = "G"; // Mostrar el nombre del enum
                }

                if (dataGridViewPedidos.Columns["Separador1"] != null)
                    dataGridViewPedidos.Columns.Remove("Separador1");

                if (dataGridViewPedidos.Columns["Separador2"] != null)
                    dataGridViewPedidos.Columns.Remove("Separador2");

                dataGridViewPedidos.Columns.Insert(3, new DataGridViewTextBoxColumn { Name = "Separador1", HeaderText = "", ReadOnly = true, Width = 35 });
                dataGridViewPedidos.Columns.Insert(9, new DataGridViewTextBoxColumn { Name = "Separador2", HeaderText = "", ReadOnly = true, Width = 35 });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void buttonCREAR_Pedido_Click(object sender, EventArgs e)
        {
            var formCrearPedido = new FormCrearPedido();
            formCrearPedido.ShowDialog();
        }


        private async void buttonMODIFICAR_Pedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                try
                {
                    var filaSeleccionada = dataGridViewPedidos.SelectedRows[0];
                    var prestamoId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    var prestamo = await _prestamoService.GetPrestamoByIdAsync(prestamoId); // Obtener los datos del préstamo
                    if (prestamo == null)
                    {
                        MessageBox.Show("No se pudo encontrar el préstamo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cambiar el estado del préstamo
                    if (prestamo.Estado == EstadoPrestamo.Reservado)
                    {
                        prestamo.Estado = EstadoPrestamo.Retirado; // Cambiar a Retirado
                    }
                    else if (prestamo.Estado == EstadoPrestamo.Retirado)
                    {
                        prestamo.Estado = EstadoPrestamo.Devuelto; // Cambiar a Devuelto
                    }
                    else
                    {
                        prestamo.Estado = EstadoPrestamo.Reservado; // Cambiar a Reservado
                    }

                    await _prestamoService.ModificarPrestamoAsync(prestamo); // PUT de los cambios

                    MessageBox.Show($"El préstamo ha sido actualizado a {prestamo.Estado} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la lista de préstamos en el formulario
                    btnActualizar_Pedido_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un préstamo para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task SincronizarEstadoLibrosAsync()
        {
            var prestamos = await _prestamoService.GetPrestamosAsync();
            var libros = await _libroService.GetLibrosAsync();

            foreach (var prestamo in prestamos)
            {
                var libro = libros.FirstOrDefault(l => l.Id == prestamo.LibroId);
                if (libro != null)
                {
                    libro.BoolPrestado = prestamo.Estado == EstadoPrestamo.Retirado; 
                    await _libroService.ModificarLibroAsync(libro);
                }
            }
        }
        /* Por cada prestamo existente, busca el libro correspondiente al LibroId del prestamo en la lista de libros.
         * Si encuentra un libro con el mismo Id que hay en el prestamo, cambia BoolPrestado al valor de la variable
         */


        private async void buttonELIMINAR_Pedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                try
                {
                    var filaSeleccionada = dataGridViewPedidos.SelectedRows[0];
                    var prestamoId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    var prestamo = await _prestamoService.GetPrestamoByIdAsync(prestamoId); //Traemos los datos del libro seleccionado
                    if (prestamo == null)
                    {
                        MessageBox.Show("No se pudo encontrar el pedido seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    prestamo.Eliminado = !prestamo.Eliminado; // Alternar estado de eliminación
                    await _prestamoService.ModificarPrestamoAsync(prestamo); //PUT de los cambios

                    string accion = prestamo.Eliminado ? "eliminado" : "restaurado";
                    MessageBox.Show($"El pedido ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnActualizar_Pedido_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el estado del pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un pedido para eliminar o restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkMostrarEliminados_CheckedChanged(object sender, EventArgs e)
        {
            _mostrarEliminados = chkMostrarEliminados.Checked;
            btnActualizar_Pedido_Click(sender, e);
        }

        private void FormPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnActualizar_Pedido_Click(sender, e);
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthContext.ClearGlobalToken();
            var _authContext = new AuthContext();
            // Mostrar el formulario de inicio de sesión
            var loginForm = new Login(_authContext);
            loginForm.Show();
        }
    }
}
