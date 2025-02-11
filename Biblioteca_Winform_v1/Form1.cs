using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace Biblioteca_Winform_v1
{
    public partial class Form1 : Form
    {

        private readonly LibroService _libroService;
        private readonly PrestamoService _prestamoService;
        private readonly AutorService _autorService;
        private readonly EditorialService _editorialService;
        private readonly GenerosService _generosService;


        private bool _mostrarEliminados = false;
        private bool _mostrarPrestados = true; // Por defecto, mostrar libros prestados


        public Form1()
        {
            InitializeComponent();
            var authContext = new AuthContext(); 

            authContext.UserToken = AuthContext.GetGlobalToken();

            _libroService = new LibroService(authContext);
            _prestamoService = new PrestamoService(authContext);
            _autorService = new AutorService(authContext);
            _editorialService = new EditorialService(authContext);
            _generosService = new GenerosService(authContext);
            buttonACTUALIZAR_Click(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     
        private async void buttonACTUALIZAR_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los préstamos activos
                var prestamos = await _prestamoService.GetPrestamosAsync();

                // Obtener todos los libros
                var libros = await _libroService.GetLibrosAsync();

                // Actualizar el estado prestado de los libros según los préstamos
                foreach (var prestamo in prestamos)
                {
                    var libro = libros.FirstOrDefault(l => l.Id == prestamo.LibroId);
                    if (libro != null)
                    {
                        // Actualizar solo si hay un cambio en el estado
                        var nuevoEstado = prestamo.Activo;
                        if (libro.BoolPrestado != nuevoEstado)
                        {
                            libro.BoolPrestado = nuevoEstado;
                            await _libroService.ModificarLibroAsync(libro);
                        }
                    }
                }

                // Filtrar los libros eliminados si corresponde
                if (!_mostrarEliminados)
                {
                    libros = libros.Where(l => !l.Eliminado).ToList();
                }

                if (!_mostrarPrestados)
                {
                    libros = libros.Where(l => !l.BoolPrestado).ToList();
                }

                // Transformar los datos para mostrarlos en el DataGridView
                var librosParaMostrar = libros.Select(libro => new
                {
                    libro.Id,
                    Eliminado = libro.Eliminado,
                    libro.BoolPrestado,
                    libro.Titulo,
                    libro.TituloEspaniol,
                    libro.AnioDePublicacion,
                    libro.ISBN,
                    libro.NumeroEdicion,
                    NombreAutor = string.IsNullOrEmpty(libro.NombreAutor) ? "Sin Autor" : libro.NombreAutor,
                    NombreEditorial = string.IsNullOrEmpty(libro.NombreEditorial) ? "Sin Editorial" : libro.NombreEditorial,
                    NombreGeneros = libro.NombresGeneros.Count == 0 ? "Sin Géneros" : string.Join(", ", libro.NombresGeneros),
                    libro.PortadaUrl,
                    libro.Descripcion
                }).OrderBy(libro => libro.Eliminado)
                  .ThenBy(libro => libro.Id)
                  .ToList();

                // Actualizar el DataGridView con los datos transformados
                dataGridViewLibros.DataSource = librosParaMostrar;

                // Configurar encabezados

                dataGridViewLibros.Columns["Titulo"].HeaderText = "Título";
                dataGridViewLibros.Columns["TituloEspaniol"].HeaderText = "Título en Español";
                dataGridViewLibros.Columns["AnioDePublicacion"].HeaderText = "Año de Publicación";
                dataGridViewLibros.Columns["ISBN"].HeaderText = "ISBN";
                dataGridViewLibros.Columns["PortadaUrl"].HeaderText = "URL de la Portada";
                dataGridViewLibros.Columns["Descripcion"].HeaderText = "Descripción";
                dataGridViewLibros.Columns["BoolPrestado"].HeaderText = "Prestado";
                dataGridViewLibros.Columns["NumeroEdicion"].HeaderText = "Número de Edición";
                dataGridViewLibros.Columns["NombreAutor"].HeaderText = "Autor";
                dataGridViewLibros.Columns["NombreEditorial"].HeaderText = "Editorial";
                dataGridViewLibros.Columns["NombreGeneros"].HeaderText = "Generos";

                dataGridViewLibros.Columns["Id"].Width = 50;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        ///
        private void buttonCREAR_Click(object sender, EventArgs e)
        {
            
            var formCrearLibro = new FormCrearLibro(_libroService,_autorService,_editorialService,_generosService);
            formCrearLibro.ShowDialog();
            buttonACTUALIZAR_Click(null, null);
        }


        private async void buttonMODIFICAR_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewLibros.SelectedRows[0];
                var libroId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                // Obtener el libro completo desde la base de datos
                var libroCompleto = await _libroService.GetLibroByIdAsync(libroId);

                if (libroCompleto == null)
                {
                    MessageBox.Show("No se pudo cargar el libro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear un objeto Libro con los datos del servicio
                var libroSeleccionado = new Libro
                {
                    Id = libroCompleto.Id,
                    Titulo = libroCompleto.Titulo,
                    TituloEspaniol = libroCompleto.TituloEspaniol,
                    AnioDePublicacion = libroCompleto.AnioDePublicacion,
                    ISBN = libroCompleto.ISBN,
                    NumeroEdicion = libroCompleto.NumeroEdicion,
                    NombreAutor = libroCompleto.NombreAutor,
                    NombreEditorial = libroCompleto.NombreEditorial,
                    NombresGeneros = libroCompleto.NombresGeneros,
                    Descripcion = libroCompleto.Descripcion,
                    PortadaUrl = libroCompleto.PortadaUrl
                };

                // Abrir el formulario de edición con los datos del libro
                var formCrearLibro = new FormCrearLibro(_libroService, _autorService, _editorialService, _generosService,libroSeleccionado);
                formCrearLibro.ShowDialog();

                // Refrescar la lista de libros después de modificar
                buttonACTUALIZAR_Click(null, null);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un libro para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }







        private async void buttonELIMINAR_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtener la fila seleccionada
                    var filaSeleccionada = dataGridViewLibros.SelectedRows[0];
                    var libroId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    // Obtener detalles del libro
                    var libro = await _libroService.GetLibroByIdAsync(libroId);

                    if (libro == null)
                    {
                        MessageBox.Show("No se pudo encontrar el libro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Alternar el estado del campo Eliminado
                    libro.Eliminado = !libro.Eliminado; // Alternar estado

                    // Actualizar el libro usando el método ModificarLibroAsync
                    await _libroService.ModificarLibroAsync(libro);

                    // Mostrar mensaje de confirmación
                    string accion = libro.Eliminado ? "eliminado" : "restaurado";

                    MessageBox.Show($"El libro ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la tabla
                    buttonACTUALIZAR_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el estado del libro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un libro para eliminar o restaurar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void dataGridViewLibros_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ya estamos en libros, no hace nada
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
            var formAutores = new FormAutores();
            formAutores.Show();
            this.Hide();
        }

        private void chkMostrarEliminadosLibros_CheckedChanged(object sender, EventArgs e)
        {
            _mostrarEliminados = chkMostrarEliminadosLibros.Checked; // Actualizar la bandera
            buttonACTUALIZAR_Click(sender, e); // Actualizar la lista
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkMostrar_Prestados_CheckedChanged(object sender, EventArgs e)
        {
            // Actualizar la flag según el estado del checkbox
            _mostrarPrestados = chkMostrarPrestados.Checked;

            // Llamar al método de actualización
            buttonACTUALIZAR_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
