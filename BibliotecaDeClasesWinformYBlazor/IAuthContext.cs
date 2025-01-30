using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor
{
    public interface IAuthContext
    {
        string UserToken { get; set; }
    }
}
