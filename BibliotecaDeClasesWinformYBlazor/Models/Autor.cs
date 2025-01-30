using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string NombreAutor { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;

    }
}
