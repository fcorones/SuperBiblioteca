using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        public string NombreEditorial { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;
    }
}
