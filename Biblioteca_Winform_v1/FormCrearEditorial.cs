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
    public partial class FormCrearEditorial : Form
    {
        private readonly EditorialService _editorialService;
        private Editorial _editorialEnEdicion;

        public FormCrearEditorial(EditorialService editorialService)
        {
            InitializeComponent();
            _editorialService = editorialService;

            txtId_Editorial.Enabled = false;
            txtId_Editorial.Text = "0";
        }

        public FormCrearEditorial(EditorialService editorialService, Editorial editorialEnEdicion = null) : this(editorialService)
        {
            _editorialEnEdicion = editorialEnEdicion;

            if (_editorialEnEdicion != null)
            {
                txtId_Editorial.Enabled = false;
                txtId_Editorial.Text = _editorialEnEdicion.Id.ToString();
                txtNombreEditorial.Text = _editorialEnEdicion.NombreEditorial;
            }
        }

        private async void btnGuardar_Editorial_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId_Editorial.Text))
                {
                    MessageBox.Show("El ID es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNombreEditorial.Text.Length > 100)
                {
                    MessageBox.Show("El nombre de la editorial no puede exceder los 100 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreEditorial.Text))
                {
                    MessageBox.Show("El nombre de la editorial es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtId_Editorial.Text, out int idEditorial))
                {
                    MessageBox.Show("El ID debe ser un número entero válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener todas las editoriales y verificar si ya existe una con el mismo nombre
                var editoriales = await _editorialService.GetEditorialesAsync();
                if (editoriales.Any(ed => ed.NombreEditorial.Equals(txtNombreEditorial.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe una editorial con el mismo nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var editorial = new Editorial
                {
                    Id = _editorialEnEdicion?.Id ?? idEditorial,
                    NombreEditorial = txtNombreEditorial.Text.Trim()
                };

                if (_editorialEnEdicion == null)
                {
                    await _editorialService.CrearEditorialAsync(editorial);
                    MessageBox.Show("Editorial creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _editorialService.ModificarEditorialAsync(editorial);
                    MessageBox.Show("Editorial modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la editorial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

