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
    public partial class FormCrearAutor : Form
    {
        private readonly AutorService _autorService;

        private Autor _autorEnEdicion;

        public FormCrearAutor(AutorService autorService) //averiguar cual es la idea
        {
            InitializeComponent();
            _autorService = autorService;

            txtId_Autor.Enabled = false;
            txtId_Autor.Text = "0";

        }

        public FormCrearAutor(AutorService autorService, Autor autorEnEdicion = null) : this(autorService)
        {
            _autorEnEdicion = autorEnEdicion;

            txtId_Autor.Enabled = false;


            if (_autorEnEdicion != null)
            {
                // Deshabilitar el campo ID para evitar su modificación
                txtId_Autor.Enabled = false;

                // Cargar los datos del autor en los controles
                txtId_Autor.Text = _autorEnEdicion.Id.ToString();
                txtNombreAutor.Text = _autorEnEdicion.NombreAutor;
            }
        }


        private async void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtId_Autor.Text))
                {
                    MessageBox.Show("El ID es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreAutor.Text))
                {
                    MessageBox.Show("El nombre de autor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNombreAutor.Text.Length > 100)
                {
                    MessageBox.Show($"El nombre de autor no puede exceder los 100 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ///ver si este de idAutor está bueno o vale la pena, capaz que está mal
                if (!int.TryParse(txtId_Autor.Text, out int idAutor))
                {
                    MessageBox.Show("El ID debe ser un número entero válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var autor = new Autor
                {
                    Id = _autorEnEdicion?.Id ?? idAutor,
                    NombreAutor = txtNombreAutor.Text.Trim()
                };

                var confirmResult = MessageBox.Show("¿Desea guardar este autor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_autorEnEdicion == null) // Si no hay libro en edición, crear uno nuevo
                {
                    await _autorService.CrearAutorAsync(autor);
                    MessageBox.Show("Autor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Si hay libro en edición, modificarlo
                {
                    await _autorService.ModificarAutorAsync(autor);
                    MessageBox.Show("Autor modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el autor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCrearAutor_Load(object sender, EventArgs e)
        {

        }
    }
}
