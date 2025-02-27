using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public bool Eliminado { get; set; } = false;
        public EstadoPrestamo Estado { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }

        //////////
        ///

        /*
        public string UsuarioNombre { get; set; }

        public string LibroNombre { get; set; }

        public int NumeroEdicion { get; set; }

        public string LibroNombreEspaniol  { get; set; }

        public string LibroEditorial { get; set; }
        */
    }
}
