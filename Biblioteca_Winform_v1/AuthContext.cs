using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDeClasesWinformYBlazor;

namespace Biblioteca_Winform_v1
{
    public class AuthContext : IAuthContext
    {
        // Campo estático para almacenar el token
        private static string _userToken;

        // Implementación de la interfaz IAuthContext
        public string UserToken
        {
            get => _userToken; // Devuelve el token estático
            set => _userToken = value; // Asigna el token al campo estático
        }

        // Método estático opcional para establecer el token globalmente
        public static void SetGlobalToken(string token)
        {
            _userToken = token;
        }

        // Método estático opcional para obtener el token global
        public static string GetGlobalToken()
        {
            return _userToken;
        }

        public static void ClearGlobalToken()
        {
            _userToken = null;
        }
    }
}