using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string TituloEspaniol { get; set; } = string.Empty;
        public int? AnioDePublicacion { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string PortadaUrl { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool BoolPrestado { get; set; }
        public int NumeroEdicion { get; set; } = 1;
        public bool Eliminado { get; set; } = false;

        public string NombreAutor { get; set; } = string.Empty;

        public string NombreEditorial { get; set; } = string.Empty;

        
        public List<string> NombresGeneros { get; set; } = new List<string>();

        
        

    }

}
