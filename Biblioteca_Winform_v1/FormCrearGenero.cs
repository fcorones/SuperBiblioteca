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
    public partial class FormCrearGenero : Form
    {
        private readonly GenerosService _generosService;
        private Genero _generoEnEdicion;

        public FormCrearGenero(GenerosService generosService, Genero generoEnEdicion = null)
        {
            InitializeComponent();
            _generosService = generosService;
            _generoEnEdicion = generoEnEdicion; //los services son stateless, su duplicacion no afecta

            txtId_Genero.Enabled = false;
            txtId_Genero.Text = "0";

            if (_generoEnEdicion != null)
            {
                txtId_Genero.Enabled = false;
                txtId_Genero.Text = _generoEnEdicion.Id.ToString();
                txtNombre_Genero.Text = _generoEnEdicion.NombreGenero;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre_Genero.Text))
                {
                    MessageBox.Show("El nombre del género es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNombre_Genero.Text.Length > 100)
                {
                    MessageBox.Show("El nombre del género no puede exceder los 100 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener todos los géneros y verificar si ya existe uno con el mismo nombre
                var generos = await _generosService.GetGenerosAsync();
                if (generos.Any(g => g.NombreGenero.Equals(txtNombre_Genero.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe un género con el mismo nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var genero = new Genero
                {
                    Id = _generoEnEdicion?.Id ?? 0,
                    NombreGenero = txtNombre_Genero.Text.Trim()
                };

                if (_generoEnEdicion == null)
                {
                    await _generosService.CrearGeneroAsync(genero);
                    MessageBox.Show("Género creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _generosService.ModificarGeneroAsync(genero);
                    MessageBox.Show("Género modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el género: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
