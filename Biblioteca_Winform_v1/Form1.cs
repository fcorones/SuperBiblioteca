using BibliotecaDeClasesWinformYBlazor;
using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
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
        private bool _mostrarPrestados = true; //Por defecto mostrar libros prestados y descartar eliminados


        public Form1()
        {
            InitializeComponent();
            //Instancia de AuthContext para obtener el token.
            var authContext = new AuthContext();

            //Se toma el token del context. 
            authContext.UserToken = AuthContext.GetGlobalToken();

            //Pasaje de la instancia de AuthContext (con el token) a los Services.
            //El HttpClientProvider del Service ahora puede agregar el token en el encabezado HTTP
            _libroService = new LibroService(authContext);
            _prestamoService = new PrestamoService(authContext);
            _autorService = new AutorService(authContext);
            _editorialService = new EditorialService(authContext);
            _generosService = new GenerosService(authContext);
            buttonACTUALIZAR_Click(null, null); //Refrescamos al iniciar
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void buttonACTUALIZAR_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtenemos todos los préstamos activos
                var prestamos = await _prestamoService.GetPrestamosAsync();

                // Obtenemos todos los libros
                var libros = await _libroService.GetLibrosAsync();

                // Actualizamos el estado prestado de los libros según los préstamos
                foreach (var prestamo in prestamos)
                {
                    var libro = libros.FirstOrDefault(l => l.Id == prestamo.LibroId);
                    if (libro != null)
                    {
                        // Recorremos todos los libros de los prestamos.
                        // Actualizamos el bool "Prestado" de cada libro en base a los prestamos existentes
                        var nuevoEstado = prestamo.Activo;
                        if (libro.BoolPrestado != nuevoEstado)
                        {
                            libro.BoolPrestado = nuevoEstado;
                            await _libroService.ModificarLibroAsync(libro);
                        }
                    }
                }

                // Filtramos los libros eliminados si corresponde
                if (!_mostrarEliminados)
                {
                    libros = libros.Where(l => !l.Eliminado).ToList();
                }

                if (!_mostrarPrestados)
                {
                    libros = libros.Where(l => !l.BoolPrestado).ToList();
                }

                // Transformar los datos para mostrarlos en el DataGridView
                //Genera variable a la cual se le carga la informacion. esta luego se carga en el DGV
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
                  .ThenBy(libro => libro.Id)    //Ordena según eliminado, y si coinciden, por ID
                  .ToList();

                //Actualizamos el DataGridView con los datos transformados
                dataGridViewLibros.DataSource = librosParaMostrar;

                //Configuramos encabezados

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
            //Instanciamos el Form FormCrearLibro y le pasamos los Services
            var formCrearLibro = new FormCrearLibro(_libroService, _autorService, _editorialService, _generosService);
            formCrearLibro.ShowDialog();
            buttonACTUALIZAR_Click(null, null);
        }


        private async void buttonMODIFICAR_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewLibros.SelectedRows[0];
                var libroId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                // Obtenemos el libro completo desde la base de datos
                var libroCompleto = await _libroService.GetLibroByIdAsync(libroId);

                if (libroCompleto == null)
                {
                    MessageBox.Show("No se pudo cargar el libro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Creamos un objeto Libro con los datos del servicio
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

                // Abrimos el formulario de edición con los datos del libro
                /*
                 Al incluir libroSeleccionado, FormCrearLibro va a saber que se trata de una modificación y no una creación.
                 */
                var formCrearLibro = new FormCrearLibro(_libroService, _autorService, _editorialService, _generosService, libroSeleccionado);
                formCrearLibro.ShowDialog();

                // Refrescamos la lista de libros después de modificar
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
                    // Obtenemos la fila seleccionada. Se extrae el Id del seleccionado.
                    var filaSeleccionada = dataGridViewLibros.SelectedRows[0];
                    var libroId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                    // Obtenemos detalles del libro seleccionado
                    var libro = await _libroService.GetLibroByIdAsync(libroId);

                    if (libro == null)
                    {
                        MessageBox.Show("No se pudo encontrar el libro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Alternamos la variable eliminado
                    libro.Eliminado = !libro.Eliminado; 

                    // Actualizamos el libro usando ModificarLibroAsync
                    await _libroService.ModificarLibroAsync(libro);

                    // Mostrar mensaje de confirmación
                    string accion = libro.Eliminado ? "eliminado" : "restaurado";

                    MessageBox.Show($"El libro ha sido {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizamois la tabla
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
            // Ya estamos en libros, no hace nada
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
            _mostrarEliminados = chkMostrarEliminadosLibros.Checked; // Actualizar la flag
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
