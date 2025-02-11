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
    public partial class FormGeneros : Form
    {
        private readonly GenerosService _generosService;
        private bool _mostrarEliminados = false;

        public FormGeneros()
        {
            InitializeComponent();
            var authContext = new AuthContext();

            authContext.UserToken = AuthContext.GetGlobalToken();
            _generosService = new GenerosService(authContext);
            btnActualizar_Click(null, null);
        }

        private void buttonCREAR_Genero_Click(object sender, EventArgs e)
        {
            var formCrearGenero = new FormCrearGenero(_generosService);
            formCrearGenero.ShowDialog();
        }

        private void buttonMODIFICAR_Genero_Click(object sender, EventArgs e)
        {
            if (dataGridViewGeneros.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewGeneros.SelectedRows[0];

                var generoSeleccionado = new Genero
                {
                    Id = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value),
                    NombreGenero = filaSeleccionada.Cells["NombreGenero"].Value.ToString()
                };

                var formCrearGenero = new FormCrearGenero(_generosService, generoSeleccionado);
                formCrearGenero.ShowDialog();

                btnActualizar_Click(null, null);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un género para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonELIMINAR_Genero_Click(object sender, EventArgs e)
        {
            if (dataGridViewGeneros.SelectedRows.Count > 0)
            {
                try
                {
                    var filaSeleccionada = dataGridViewGeneros.SelectedRows[0];
                    var generoId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    var genero = await _generosService.GetGeneroByIdAsync(generoId);
                    if (genero == null)
                    {
                        MessageBox.Show("No se pudo encontrar el género seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    genero.Eliminado = !genero.Eliminado;
                    await _generosService.ModificarGeneroAsync(genero);

                    string accion = genero.Eliminado ? "eliminado" : "restaurado";
                    MessageBox.Show($"El género ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnActualizar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el estado del género: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un género para eliminar o restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkMostrarEliminados_CheckedChanged(object sender, EventArgs e)
        {
            _mostrarEliminados = chkMostrarEliminados.Checked;
            btnActualizar_Click(sender, e);
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var generos = await _generosService.GetGenerosAsync();

                if (!_mostrarEliminados)
                {
                    generos = generos.Where(g => !g.Eliminado).ToList();
                }

                var generosParaMostrar = generos.Select(genero => new
                {
                    genero.Id,
                    Eliminado = genero.Eliminado,
                    genero.NombreGenero,
                    //Eliminado = genero.Eliminado ? "Sí" : "No"
                }).OrderBy(a => a.Eliminado) // Agrupar eliminados al final
                .ThenBy(a => a.Id)
                .ToList();

                dataGridViewGeneros.DataSource = generosParaMostrar;

                dataGridViewGeneros.Columns["NombreGenero"].HeaderText = "Nombre del género";
                dataGridViewGeneros.Columns["Id"].Width = 30;
                dataGridViewGeneros.Columns["NombreGenero"].Width = 200;
                dataGridViewGeneros.Columns["Eliminado"].Width = 30;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void FormGeneros_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            var form = new FormPedidos();
            form.Show();
            this.Hide();
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
            //ya estoy en generos
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
