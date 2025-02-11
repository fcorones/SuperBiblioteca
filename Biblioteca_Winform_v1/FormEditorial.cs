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
    public partial class FormEditorial : Form
    {

        private readonly EditorialService _editorialService;
        private bool _mostrarEliminados = false;

        public FormEditorial()
        {
            InitializeComponent();
            var authContext = new AuthContext();

            authContext.UserToken = AuthContext.GetGlobalToken();
            _editorialService = new EditorialService(authContext);
            btnActualizar_Editorial_Click(null, null);

        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLibros = new Form1();
            formLibros.Show();
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
            //ya estoy en editoriales
        }

        private void génerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormGeneros();
            form.Show();
            this.Hide();
        }

        private void dataGridViewEditoriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnActualizar_Editorial_Click(object sender, EventArgs e)
        {
            try
            {
                var editoriales = await _editorialService.GetEditorialesAsync();

                if (!_mostrarEliminados)
                {
                    editoriales = editoriales.Where(e => !e.Eliminado).ToList();
                }

                var editorialesParaMostrar = editoriales.Select(editorial => new
                {
                    editorial.Id,
                    Eliminado = editorial.Eliminado,
                    editorial.NombreEditorial
                }).OrderBy(a => a.Eliminado) // Agrupar eliminados al final
                .ThenBy(a => a.Id)
                .ToList();

                dataGridViewEditoriales.DataSource = editorialesParaMostrar;

                dataGridViewEditoriales.Columns["NombreEditorial"].HeaderText = "Nombre de la Editorial";
                dataGridViewEditoriales.Columns["Id"].Width = 30;
                dataGridViewEditoriales.Columns["NombreEditorial"].Width = 200;
                dataGridViewEditoriales.Columns["Eliminado"].Width = 30;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void buttonCREAR_Editorial_Click(object sender, EventArgs e)
        {
            var formCrearEditorial = new FormCrearEditorial(_editorialService);
            formCrearEditorial.ShowDialog();
        }

        private void buttonMODIFICAR_Editorial_Click(object sender, EventArgs e)
        {
            if (dataGridViewEditoriales.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewEditoriales.SelectedRows[0];
                var editorialSeleccionada = new Editorial
                {
                    Id = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value),
                    NombreEditorial = filaSeleccionada.Cells["NombreEditorial"].Value.ToString()
                };

                var formCrearEditorial = new FormCrearEditorial(_editorialService, editorialSeleccionada);
                formCrearEditorial.ShowDialog();

                btnActualizar_Editorial_Click(null, null);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una editorial para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonELIMINAR_Editorial_Click(object sender, EventArgs e)
        {
            if (dataGridViewEditoriales.SelectedRows.Count > 0)
            {
                try
                {
                    var filaSeleccionada = dataGridViewEditoriales.SelectedRows[0];
                    var editorialId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    var editorial = await _editorialService.GetEditorialByIdAsync(editorialId);
                    if (editorial == null)
                    {
                        MessageBox.Show("No se pudo encontrar la editorial seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    editorial.Eliminado = !editorial.Eliminado;
                    await _editorialService.ModificarEditorialAsync(editorial);

                    string accion = editorial.Eliminado ? "eliminada" : "restaurada";
                    MessageBox.Show($"La editorial ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnActualizar_Editorial_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el estado de la editorial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una editorial para eliminar o restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkMostrarEditorialEliminados_CheckedChanged(object sender, EventArgs e)
        {
            _mostrarEliminados = chkMostrarEditorialEliminados.Checked;
            btnActualizar_Editorial_Click(sender, e);
        }

        private void FormEditorial_Load(object sender, EventArgs e)
        {

        }

        private void FormEditorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void menúToolStripMenuItem_Click(object sender, EventArgs e)
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
