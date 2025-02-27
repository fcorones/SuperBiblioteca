using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public enum EstadoPrestamo
    {
        Reservado,      //ESTADO INICIAL. CREACIÓN DEL PRESTAMO
        Retirado,       //LIBRO RETIRADO
        Devuelto        //LIBRO DEVUELTO
    }
}
