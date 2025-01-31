using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using BibliotecaDeClasesWinformYBlazor.Models;
using Newtonsoft.Json;

namespace BibliotecaDeClasesWinformYBlazor.Servicios
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthContext _authContext;

        /*
        public UsuarioService()
        {
            // Usar el token JWT desde AuthContext
            _httpClient = HttpClientProvider.GetHttpClient(Program.UserToken);
        }
        */
        /*
        public UsuarioService()
        {
            // Obtenemos el token desde AuthContext y configuramos el HttpClient
            _authContext = new AuthContext(); // Se instancia según la implementación de la plataforma (WinForm o Blazor)
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }
        */

        public UsuarioService(IAuthContext authContext)
        {
            // Recibe el AuthContext desde el entorno (WinForm o Blazor)
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }


        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            List<Usuario> usuarios = new List<Usuario>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Usuarios");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            }
            //verificar que la clase Libro se corresponda con el jsonString retornado
            return usuarios;
        }

        public async Task<HttpResponseMessage> CrearUsuarioAsync(Usuario usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsJsonAsync("api/Usuarios", usuario);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el usuario: {response.StatusCode} - {errorMessage}");
            }

            return response;
        }

        public async Task ModificarUsuarioAsync(Usuario usuario)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Usuarios/{usuario.Id}", usuario);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al modificar el usuario: {response.StatusCode} - {errorMessage}");
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            try
            {
                // Realiza la solicitud GET a la API para obtener el usuario por ID
                var response = await _httpClient.GetAsync($"api/Usuarios/{id}");

                // Verifica si la respuesta fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Deserializa el contenido de la respuesta a un objeto Usuario
                    var usuarioJson = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
                    return usuario;
                }
                else
                {
                    // Maneja errores de la API
                    throw new Exception($"Error al obtener el usuario: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                throw new Exception($"Ocurrió un error al intentar obtener el usuario: {ex.Message}");
            }
        }

    }
}
