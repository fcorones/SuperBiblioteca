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
    public partial class FormAutores : Form
    {

        private readonly AutorService _autorService;
        private bool _mostrarEliminados = false;

        public FormAutores()
        {
            InitializeComponent();
            var authContext = new AuthContext();

            authContext.UserToken = AuthContext.GetGlobalToken();

            _autorService = new AutorService(authContext);

            btnActualizar_Autor_Click(null, null);

        }



        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formlibros = new Form1();
            formlibros.Show();
            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formUsuario = new FormUsuario();
            formUsuario.Show();
            this.Hide();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPedidos();
            form.Show();
            this.Hide();
        }

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ya estoy en autores
        }

        private void FormAutores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void btnActualizar_Autor_Click(object sender, EventArgs e)
        {
            try
            {

                var autores = await _autorService.GetAutoresAsync();

                if (!_mostrarEliminados)
                {
                    autores = autores.Where(a => !a.Eliminado).ToList(); // Excluir eliminados
                }

                var autoresParaMostrar = autores.Select(autor => new
                {
                    autor.Id,
                    Eliminado = autor.Eliminado,
                    autor.NombreAutor
                }).OrderBy(a => a.Eliminado) // Agrupar eliminados al final
                .ThenBy(a => a.Id)
                .ToList();

                dataGridViewAutores.DataSource = autoresParaMostrar;

                dataGridViewAutores.Columns["NombreAutor"].HeaderText = "Nombre del autor";
                dataGridViewAutores.Columns["Id"].Width = 30;
                dataGridViewAutores.Columns["NombreAutor"].Width = 200;
                dataGridViewAutores.Columns["Eliminado"].Width = 30;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }

        }

        private void buttonCREAR_Autor_Click(object sender, EventArgs e)
        {
            var autorService = _autorService; //instancia del servicio
            var formCrearAutor = new FormCrearAutor(autorService); //se la pasamos al form 
            formCrearAutor.ShowDialog();
        }

        private void buttonMODIFICAR_Autor_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridViewAutores.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewAutores.SelectedRows[0];

                // Crear un objeto Autor con los datos seleccionados
                var autorSeleccionado = new Autor
                {
                    Id = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value),
                    NombreAutor = filaSeleccionada.Cells["NombreAutor"].Value.ToString()
                };

                // Abrir el formulario de creación/modificación con los datos del autor
                var formCrearAutor = new FormCrearAutor(_autorService, autorSeleccionado);
                formCrearAutor.ShowDialog();

                // Refrescar la lista de autores después de modificar
                btnActualizar_Autor_Click(null, null);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un autor para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonELIMINAR_Autor_Click(object sender, EventArgs e)
        {
            if (dataGridViewAutores.SelectedRows.Count > 0)
            {
                try
                {
                    var filaSeleccionada = dataGridViewAutores.SelectedRows[0];
                    var autorId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    var autor = await _autorService.GetAutorByIdAsync(autorId);
                    if (autor == null)
                    {
                        MessageBox.Show("No se pudo encontrar el autor seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    autor.Eliminado = !autor.Eliminado; // Alternar estado
                    await _autorService.ModificarAutorAsync(autor);

                    string accion = autor.Eliminado ? "eliminado" : "restaurado";
                    MessageBox.Show($"El autor ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnActualizar_Autor_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el estado del autor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un autor para eliminar o restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkMostrarEliminados_CheckedChanged(object sender, EventArgs e)
        {
            _mostrarEliminados = chkMostrarEliminados.Checked;
            btnActualizar_Autor_Click(sender, e);
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
