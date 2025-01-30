using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public class Rol
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
