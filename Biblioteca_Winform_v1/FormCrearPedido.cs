using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Winform_v1
{
    public partial class FormCrearPedido : Form
    {
        private readonly UsuarioService _usuarioService;
        private readonly LibroService _libroService;
        private readonly PrestamoService _prestamoService;

        public FormCrearPedido()
        {
            var authContext = new AuthContext();

            authContext.UserToken = AuthContext.GetGlobalToken();
            _usuarioService = new UsuarioService(authContext);
            _libroService = new LibroService(authContext);
            _prestamoService = new PrestamoService(authContext);
            InitializeComponent();
            CargarUsuarios();
            CargarLibros();
        }



        private async void CargarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosAsync();
                var usuariosFiltrados = usuarios
                    .Where(usuario => !usuario.Eliminado) // Filtrar usuarios eliminados
                    .Select(usuario => new
                    {
                        usuario.Id,
                        usuario.Nombre,
                        usuario.Email,
                        usuario.Telefono,
                        usuario.Direccion
                    }).ToList();

                dataGridViewUsuarios.DataSource = usuariosFiltrados;
                dataGridViewUsuarios.Columns["Id"].HeaderText = "ID";
                dataGridViewUsuarios.Columns["Nombre"].HeaderText = "Nombre";
                dataGridViewUsuarios.Columns["Email"].HeaderText = "Correo electrónico";

                dataGridViewUsuarios.Columns["Id"].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarLibros()
        {
            try
            {
                var libros = await _libroService.GetLibrosAsync();
                var librosFiltrados = libros
                    .Where(libro => !libro.Eliminado) // Filtrar libros eliminados
                    .Select(libro => new
                    {
                        libro.Id,
                        libro.Titulo,
                        libro.TituloEspaniol,
                        libro.AnioDePublicacion,
                        libro.ISBN,
                        libro.NumeroEdicion,
                        NombreAutor = string.IsNullOrEmpty(libro.NombreAutor) ? "Sin Autor" : libro.NombreAutor,
                        NombreEditorial = string.IsNullOrEmpty(libro.NombreEditorial) ? "Sin Editorial" : libro.NombreEditorial,
                        NombreGeneros = libro.NombresGeneros.Count == 0 ? "Sin Géneros" : string.Join(", ", libro.NombresGeneros),
                    }).ToList();

                dataGridViewLibroAPedir.DataSource = librosFiltrados;
                dataGridViewLibroAPedir.Columns["Id"].HeaderText = "ID";
                dataGridViewLibroAPedir.Columns["Titulo"].HeaderText = "Título";
                dataGridViewLibroAPedir.Columns["NombreAutor"].HeaderText = "Autor";
                dataGridViewLibroAPedir.Columns["NombreEditorial"].HeaderText = "Editorial";
                dataGridViewLibroAPedir.Columns["AnioDepublicacion"].HeaderText = "Año de publicación";
                // dataGridViewLibroAPedir.Columns["NombresGeneros"].HeaderText = "Géneros";
                dataGridViewLibroAPedir.Columns["NombreAutor"].HeaderText = "Autor";
                dataGridViewLibroAPedir.Columns["NumeroEdicion"].HeaderText = "Número de Edición";

                dataGridViewLibroAPedir.Columns["Id"].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewUsuarios.Columns.Contains("Id"))
            {
                var filaSeleccionada = dataGridViewUsuarios.Rows[e.RowIndex];
                txtId_Cliente.Text = filaSeleccionada.Cells["Id"].Value?.ToString() ?? string.Empty;
            }
        }

        /*
        private void dataGridViewLibroAPedir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewLibroAPedir.Columns.Contains("Id"))
            {
                var filaSeleccionada = dataGridViewLibroAPedir.Rows[e.RowIndex];
                txtId_Libro.Text = filaSeleccionada.Cells["Id"].Value?.ToString() ?? string.Empty;
            }
        }
        */

        private async void dataGridViewLibroAPedir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewLibroAPedir.Columns.Contains("Id"))
            {
                var filaSeleccionada = dataGridViewLibroAPedir.Rows[e.RowIndex];
                txtId_Libro.Text = filaSeleccionada.Cells["Id"].Value?.ToString() ?? string.Empty;

                // Cargar disponibilidad del libro seleccionado en el calendario
                if (int.TryParse(txtId_Libro.Text, out int libroId))
                {
                    await MostrarDisponibilidadLibroEnCalendario(libroId);

                    // Mostrar el rango de fechas en el Label
                    MostrarEstadoPrestamoEnLabel(libroId);
                }
            }
        }

        private async void MostrarEstadoPrestamoEnLabel(int libroId)
        {
            try
            {
                // Obtener los préstamos asociados al libro
                var prestamos = await _prestamoService.GetPrestamosAsync();
                var prestamosLibro = prestamos
                    .Where(p => p.LibroId == libroId && !p.Eliminado)
                    .ToList();

                // Verificar si hay préstamos para el libro
                if (prestamosLibro.Any())
                {
                    // Buscar préstamos en estado "Retirado" (activos)
                    var prestamosRetirados = prestamosLibro
                        .Where(p => p.Estado == EstadoPrestamo.Retirado) // Cambiar aquí
                        .OrderBy(p => p.FechaPrestamo) // Ordenar por fecha de préstamo
                        .ToList();

                    if (prestamosRetirados.Any())
                    {
                        var prestamo = prestamosRetirados.First(); // Tomar el más reciente retirado
                        lblEstadoPrestamo.Text = $"En préstamo: {prestamo.FechaPrestamo:dd/MM/yyyy} hasta {prestamo.FechaDevolucion:dd/MM/yyyy}";
                    }
                    else
                    {
                        lblEstadoPrestamo.Text = "Este libro no está actualmente en préstamo";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el estado del préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnActualizar_Cliente_Click_1(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnActualizar_Libro_Click_1(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private async void btnGuardarPEDIDO_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtId_Cliente.Text))
                {
                    MessageBox.Show("Debe seleccionar un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtId_Libro.Text))
                {
                    MessageBox.Show("Debe seleccionar un libro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el ID del cliente sea un número entero no negativo
                if (!int.TryParse(txtId_Cliente.Text, out int usuarioId) || usuarioId <= 0)
                {
                    MessageBox.Show("ID de usuario inválido. Debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el ID del libro sea un número entero no negativo
                if (!int.TryParse(txtId_Libro.Text, out int libroId) || libroId <= 0)
                {
                    MessageBox.Show("ID de libro inválido. Debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar la fecha de retiro (no puede ser anterior a la fecha actual)
                if (dtpFecha_Retiro.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("La fecha de retiro no puede ser anterior a la fecha actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la fecha de devolución no sea anterior a la fecha de retiro
                if (dtpFecha_Devolucion.Value.Date < dtpFecha_Retiro.Value.Date)
                {
                    MessageBox.Show("La fecha de devolución no puede ser anterior a la fecha de retiro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos
                var fechaPrestamo = dtpFecha_Retiro.Value.Date;
                var fechaDevolucion = dtpFecha_Devolucion.Value.Date;

                // Verificar si las fechas se solapan con préstamos existentes
                var prestamos = await _prestamoService.GetPrestamosAsync();
                var prestamosLibro = prestamos
                    .Where(p => p.LibroId == libroId && !p.Eliminado)
                    .ToList();

                bool solapamiento = prestamosLibro.Any(p =>
             (fechaPrestamo >= p.FechaPrestamo && fechaPrestamo <= p.FechaDevolucion) || // Nueva fecha de retiro dentro de un préstamo existente
             (fechaDevolucion >= p.FechaPrestamo && fechaDevolucion <= p.FechaDevolucion) || // Nueva fecha de devolución dentro de un préstamo existente
             (fechaPrestamo <= p.FechaPrestamo && fechaDevolucion >= p.FechaDevolucion)); // Nueva reserva cubre completamente un préstamo existente

                if (solapamiento)
                {
                    MessageBox.Show("El libro ya está reservado en el rango de fechas seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear objeto de préstamo
                var nuevoPrestamo = new Prestamo
                {
                    FechaPrestamo = fechaPrestamo,
                    FechaDevolucion = fechaDevolucion,
                    UsuarioId = usuarioId,
                    LibroId = libroId,
                    Estado = EstadoPrestamo.Reservado,
                    Eliminado = false
                };

                // Confirmar acción
                var confirmResult = MessageBox.Show("¿Desea guardar este préstamo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                // Guardar en la base de datos a través del servicio
                await _prestamoService.CrearPrestamoAsync(nuevoPrestamo);

                MessageBox.Show("Préstamo creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: Limpiar campos o cerrar el formulario
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async Task MostrarDisponibilidadLibroEnCalendario(int libroId)
        {
            try
            {
                // Limpiar cualquier selección previa en el calendario
                monthCalendarDisponibilidad.RemoveAllBoldedDates();

                // Obtener los préstamos asociados al libro
                var prestamos = await _prestamoService.GetPrestamosAsync();
                var prestamosLibro = prestamos
                    .Where(p => p.LibroId == libroId && !p.Eliminado)
                    .ToList();

                // Resaltar las fechas de préstamo en el calendario
                foreach (var prestamo in prestamosLibro)
                {
                    for (var fecha = prestamo.FechaPrestamo; fecha <= prestamo.FechaDevolucion; fecha = fecha.AddDays(1))
                    {
                        monthCalendarDisponibilidad.AddBoldedDate(fecha);
                    }
                }

                // Actualizar el calendario para reflejar los cambios
                monthCalendarDisponibilidad.UpdateBoldedDates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar disponibilidad del libro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private async void dataGridViewLibroAPedir_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewLibroAPedir.Columns.Contains("Id"))
            {
                var filaSeleccionada = dataGridViewLibroAPedir.Rows[e.RowIndex];
                txtId_Libro.Text = filaSeleccionada.Cells["Id"].Value?.ToString() ?? string.Empty;

                // Cargar disponibilidad del libro seleccionado en el calendario
                if (int.TryParse(txtId_Libro.Text, out int libroId))
                {
                    await MostrarDisponibilidadLibroEnCalendario(libroId);

                    // Mostrar el rango de fechas en el Label (opcional)
                    MostrarEstadoPrestamoEnLabel(libroId);
                }
            }
        }

        private void FormCrearPedido_Load(object sender, EventArgs e)
        {
            // Limpiar el calendario al cargar el formulario
            monthCalendarDisponibilidad.RemoveAllBoldedDates();
            monthCalendarDisponibilidad.UpdateBoldedDates();
        }

        private async void btnVer_Reserva_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un usuario
                if (string.IsNullOrWhiteSpace(txtId_Cliente.Text) || !int.TryParse(txtId_Cliente.Text, out int usuarioId))
                {
                    MessageBox.Show("Seleccione un usuario válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos desde los servicios
                var prestamos = await _prestamoService.GetPrestamosAsync();
                var usuarios = await _usuarioService.GetUsuariosAsync();
                var libros = await _libroService.GetLibrosAsync();

                // Filtrar las reservas del usuario seleccionado
                var reservasUsuario = prestamos
                    .Where(p => p.UsuarioId == usuarioId)
                    .Select(prestamo => new
                    {
                        prestamo.Id,
                        prestamo.FechaPrestamo,
                        prestamo.FechaDevolucion,
                        prestamo.Eliminado,
                        prestamo.Estado,
                        UsuarioNombre = usuarios.FirstOrDefault(u => u.Id == prestamo.UsuarioId)?.Nombre ?? "Desconocido",
                        LibroNombre = libros.FirstOrDefault(l => l.Id == prestamo.LibroId)?.Titulo ?? "Desconocido",
                        LibroNombreEspaniol = libros.FirstOrDefault(l => l.Id == prestamo.LibroId)?.TituloEspaniol ?? "N/A"
                    })
                    .OrderBy(p => p.FechaPrestamo) // Opcional: Ordenar por fecha de préstamo
                    .ToList();

                // Verificar si hay reservas para mostrar
                if (!reservasUsuario.Any())
                {
                    MessageBox.Show("El usuario seleccionado no tiene reservas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar el formulario FormReserva como ventana emergente
                var formReserva = new FormReserva(reservasUsuario.Cast<object>().ToList());
                formReserva.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void monthCalendarDisponibilidad_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
