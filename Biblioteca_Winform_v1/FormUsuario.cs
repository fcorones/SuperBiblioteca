using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Winform_v1
{
    public partial class FormUsuario : Form
    {

        private readonly UsuarioService _usuarioService;
        private readonly PrestamoService _prestamoService;
        private readonly LibroService _libroService;
        private bool _mostrarEliminados = false;



        public FormUsuario()
        {
            InitializeComponent();
            var authContext = new AuthContext();

            authContext.UserToken = AuthContext.GetGlobalToken();

            _usuarioService = new UsuarioService(authContext);
            _prestamoService = new PrestamoService(authContext);
            _libroService = new LibroService(authContext);


            btnActualizar_Usuario_Click(null, null);
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }

        private void FormUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLibros = new Form1();
            formLibros.Show();
            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ya estoy en usuarios
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPedidos();
            form.Show();
            this.Hide();
        }

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAutores = new FormAutores();
            formAutores.Show();
            this.Hide();
        }

        private async void btnActualizar_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los usuarios y préstamos desde los servicios
                var usuarios = await _usuarioService.GetUsuariosAsync();
                var prestamos = await _prestamoService.GetPrestamosAsync();

                // Filtrar usuarios según la bandera
                if (!_mostrarEliminados)
                {
                    usuarios = usuarios.Where(u => !u.Eliminado).ToList(); // Excluir usuarios eliminados
                }

                if (checkUsrPedidos.Checked)
                {
                    // Filtrar usuarios con préstamos retirados
                    usuarios = usuarios.Where(u => prestamos.Any(p => p.UsuarioId == u.Id && p.Estado == EstadoPrestamo.Retirado)).ToList(); // Cambiar aquí
                }

                // Preparar los datos para mostrar
                var usuariosParaMostrar = usuarios.Select(usuario => new
                {
                    usuario.Id,
                    Eliminado = usuario.Eliminado,
                    usuario.Nombre,
                    usuario.Email,
                    usuario.Telefono,
                    usuario.Direccion,
                    usuario.RolNombre,
                    Pedido = prestamos.Any(p => p.UsuarioId == usuario.Id) // Verificar si tiene pedidos
                })
                .OrderBy(usuario => usuario.Eliminado) // Agrupar eliminados al final
                .ThenBy(usuario => usuario.Id)
                .ToList();

                // Asignar los datos al DataGridView
                dataGridViewUsuarios.DataSource = usuariosParaMostrar;

                // Configurar columnas
                dataGridViewUsuarios.Columns["Nombre"].HeaderText = "Nombre del usuario";
                dataGridViewUsuarios.Columns["Email"].HeaderText = "Correo electrónico";
                dataGridViewUsuarios.Columns["Id"].Width = 30;
                dataGridViewUsuarios.Columns["Nombre"].Width = 200;
                dataGridViewUsuarios.Columns["Email"].Width = 250;
                dataGridViewUsuarios.Columns["Eliminado"].HeaderText = "Eliminado";
                dataGridViewUsuarios.Columns["Pedido"].HeaderText = "Tiene Pedido"; // Encabezado para la nueva columna
                dataGridViewUsuarios.Columns["Pedido"].Width = 100; // Ajustar ancho de la columna
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonCREAR_Usuario_Click(object sender, EventArgs e)
        {
            var usuarioService = _usuarioService; //instancia del servicio
            var formCrearUsuario = new FormCrearUsuario(usuarioService); //se la pasamos al form 
            formCrearUsuario.ShowDialog();
        }

        private async void buttonMODIFICAR_Usuario_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewUsuarios.SelectedRows[0];
                var usuarioId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                // Obtener la contraseña hasheada desde la base de datos
                var usuarioCompleto = await _usuarioService.GetUsuarioByIdAsync(usuarioId);


                if (usuarioCompleto == null)
                {
                    MessageBox.Show("No se pudo cargar el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear un objeto Usuario con los datos del servicio
                var usuarioSeleccionado = new Usuario
                {
                    Id = usuarioCompleto.Id,
                    Nombre = usuarioCompleto.Nombre,
                    Email = usuarioCompleto.Email,
                    Telefono = usuarioCompleto.Telefono,
                    Direccion = usuarioCompleto.Direccion,
                    RolNombre = usuarioCompleto.RolNombre,
                    ContraseñaHasheada = usuarioCompleto.ContraseñaHasheada // Aquí está la contraseña hasheada
                };

                // Abrir el formulario de edición con los datos del usuario
                var formCrearUsuario = new FormCrearUsuario(_usuarioService, usuarioSeleccionado);
                formCrearUsuario.ShowDialog();

                // Refrescar la lista de usuarios después de modificar
                btnActualizar_Usuario_Click(null, null);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonELIMINAR_Usuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtener la fila seleccionada
                    var filaSeleccionada = dataGridViewUsuarios.SelectedRows[0];
                    var usuarioId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    // Obtener detalles del usuario
                    var usuario = await _usuarioService.GetUsuarioByIdAsync(usuarioId);

                    if (usuario == null)
                    {
                        MessageBox.Show("No se pudo encontrar el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Alternar el estado del campo Eliminado
                    usuario.Eliminado = !usuario.Eliminado; // Alternar estado


                    // Actualizar el usuario usando el método ModificarUsuarioAsync
                    await _usuarioService.ModificarUsuarioAsync(usuario);

                    // Mostrar mensaje de confirmación
                    string accion = usuario.Eliminado ? "eliminado" : "restaurado";

                    MessageBox.Show($"El usuario ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la tabla
                    btnActualizar_Usuario_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el estado del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar o restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void chkMostrarEliminados_CheckedChanged(object sender, EventArgs e)
        {
            _mostrarEliminados = chkMostrarEliminados.Checked; // Actualizar la bandera
            btnActualizar_Usuario_Click(sender, e); // Actualizar la lista
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

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btn_VerReservaUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtener el ID del usuario seleccionado
                    var filaSeleccionada = dataGridViewUsuarios.SelectedRows[0];
                    var usuarioId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

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
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para ver sus reservas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkUsrPedidos_CheckedChanged(object sender, EventArgs e)
        {
            btnActualizar_Usuario_Click(sender, e);
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
