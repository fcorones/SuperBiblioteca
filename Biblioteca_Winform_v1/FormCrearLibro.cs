using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using Newtonsoft.Json;
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
    public partial class FormCrearLibro : Form
    {
        private readonly LibroService _libroService;
        private readonly AutorService _autorService;
        private readonly EditorialService _editorialService;
        private readonly GenerosService _generosService;

        private readonly ListBox _listBoxSugerencias;



        //Constructor 1: Crear un libro
        public FormCrearLibro(
       LibroService libroService,
       AutorService autorService,
       EditorialService editorialService,
       GenerosService generosService)
        {
            InitializeComponent();
            _libroService = libroService;
            _autorService = autorService;
            _editorialService = editorialService;
            _generosService = generosService;

            txtId.Enabled = false; //Deshabilitamos el ingreso de Id. Forzamos id a 0
            txtId.Text = "0";
            CargarDatosIniciales(); // Cargar datos al iniciar
        }

        private async void CargarDatosIniciales()
        {
            await CargarAutores();
            await CargarEditoriales();
            await CargarGeneros();
        }

        private async Task CargarGeneros()
        {
            var generos = await _generosService.GetGenerosAsync(); //GET de Generos
            clbGeneros.DataSource = generos;         // Asigna "generos" como fuente de datos del checklist
            clbGeneros.DisplayMember = "NombreGenero";  //La propiedad que se muestra en cada objeto
            clbGeneros.ValueMember = "Id";  //Propiedad (id) de cada objeto usada como valor de cada elemento

            if (_libroEnEdicion != null && clbGeneros.Items.Count > 0)
            {
                //Recorremos todos los ítems del CheckedListBox
                for (int i = 0; i < clbGeneros.Items.Count; i++)
                {
                    var genero = (Genero)clbGeneros.Items[i];  //Asumimos que clbGeneros contiene objetos de tipo Genero
                                                               //Comprobamos si el género está en la lista de géneros del libro en edición
                    if (_libroEnEdicion.NombresGeneros.Contains(genero.NombreGenero))
                    {
                        //Si el género está en la lista, lo marcamos como seleccionado
                        clbGeneros.SetItemChecked(i, true);
                    }
                    else
                    {
                        //Si no está en la lista, lo dejamos sin seleccionar
                        clbGeneros.SetItemChecked(i, false);
                    }
                }
            }
        }


        private async Task CargarAutores()
        {
            var autores = await _autorService.GetAutoresAsync();
            cmbAutor.DataSource = autores;
            cmbAutor.DisplayMember = "NombreAutor";
            cmbAutor.ValueMember = "Id";

            if (_libroEnEdicion != null && autores != null && autores.Any())
            {
                string nombreAutorSeleccionado = _libroEnEdicion.NombreAutor;
                var autorSeleccionado = autores.FirstOrDefault(a => a.NombreAutor == nombreAutorSeleccionado);

                if (autorSeleccionado != null)
                {
                    cmbAutor.SelectedItem = autorSeleccionado;
                }
                else
                {
                    MessageBox.Show("No se encontró el autor.");
                }
            }
        }


        private async Task CargarEditoriales()
        {
            var editoriales = await _editorialService.GetEditorialesAsync();
            cmbEditorial.DataSource = editoriales;
            cmbEditorial.DisplayMember = "NombreEditorial";
            cmbEditorial.ValueMember = "Id";

            if (_libroEnEdicion != null && editoriales != null && editoriales.Any())
            {
                string nombreEditorialSeleccionada = _libroEnEdicion.NombreEditorial;
                var editorialSeleccionada = editoriales.FirstOrDefault(e => e.NombreEditorial == nombreEditorialSeleccionada);

                if (editorialSeleccionada != null)
                {
                    cmbEditorial.SelectedItem = editorialSeleccionada;
                }
                else
                {
                    MessageBox.Show("No se encontró la editorial.");
                }
            }
        }

        
        private Libro _libroEnEdicion;

        //Constructor 2: Edición
        //Constructor sobrecargado. Si se recibe algo en "libroEnEdicion" quiere decir que se abrió en modo EDICIÓN
        public FormCrearLibro(LibroService libroService, AutorService autorService, EditorialService editorialService, GenerosService generosService, Libro libroEnEdicion = null) : this(libroService, autorService, editorialService, generosService)
        {
            _libroEnEdicion = libroEnEdicion;

            if (_libroEnEdicion != null)
            {
                txtId.Enabled = false;
                // Rellenar los campos con los datos del libro en edición
                txtId.Text = _libroEnEdicion.Id.ToString();
                txtTitulo.Text = _libroEnEdicion.Titulo;
                txtTituloEspaniol.Text = _libroEnEdicion.TituloEspaniol;
                txtAnio.Text = _libroEnEdicion.AnioDePublicacion?.ToString();
                txtISBN.Text = _libroEnEdicion.ISBN;
                txtEdicion.Text = _libroEnEdicion.NumeroEdicion.ToString();
                txtPortadaUrl.Text = _libroEnEdicion.PortadaUrl;
                txtDescripcion_v1.Text = _libroEnEdicion.Descripcion;
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    MessageBox.Show("El título es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar campos obligatorios
                if (cmbAutor.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un autor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbEditorial.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona una editorial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (clbGeneros.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona al menos un género.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar el número de edición
                if (!int.TryParse(txtEdicion.Text, out int numeroEdicion) || numeroEdicion <= 0)
                {
                    MessageBox.Show("El número de edición debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Validar el año de publicación
                int? anioDePublicacion = null;
                if (!string.IsNullOrWhiteSpace(txtAnio.Text))
                {
                    if (!int.TryParse(txtAnio.Text, out int anio))
                    {
                        MessageBox.Show("El año de publicación debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        anioDePublicacion = anio;
                    }
                }

                if (txtISBN.Text.Trim().Length > 10)
                {
                    MessageBox.Show("El ISBN debe tener al menos 10 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtenemos valores seleccionados
                var autorSeleccionado = (Autor)cmbAutor.SelectedItem;
                var editorialSeleccionada = (Editorial)cmbEditorial.SelectedItem;
                var generosSeleccionados = clbGeneros.CheckedItems.Cast<Genero>().ToList();

                // Asignar valores a los campos del modelo
                var libro = new Libro
                {
                    Id = _libroEnEdicion?.Id ?? 0, // Usar el ID del libro en edición o 0 si es un nuevo libro
                    Titulo = txtTitulo.Text.Trim(),
                    TituloEspaniol = txtTituloEspaniol.Text.Trim(),
                    AnioDePublicacion = anioDePublicacion,
                    ISBN = txtISBN.Text.Trim(),
                    NumeroEdicion = numeroEdicion,
                    NombreAutor = autorSeleccionado.NombreAutor, //datos de los combobox
                    NombreEditorial = editorialSeleccionada.NombreEditorial,
                    PortadaUrl = string.IsNullOrWhiteSpace(txtPortadaUrl.Text) ? string.Empty : txtPortadaUrl.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion_v1.Text) ? string.Empty : txtDescripcion_v1.Text.Trim(),
                    NombresGeneros = generosSeleccionados.Select(g => g.NombreGenero).ToList() //datos del checklist
                };

                // Confirmar la acción
                var confirmResult = MessageBox.Show("¿Desea guardar este libro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                // Determinar si se debe crear o modificar el libro
                if (_libroEnEdicion == null) // Si no hay libro en edición, crear uno nuevo
                {
                    await _libroService.CrearLibroAsync(libro);
                    MessageBox.Show("Libro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Si hay libro en edición, modificarlo
                {
                    await _libroService.ModificarLibroAsync(libro);
                    MessageBox.Show("Libro modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cerrar el formulario con resultado OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el libro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEditorial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdicion_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_v1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
