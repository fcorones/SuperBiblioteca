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
    public class AutorService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthContext _authContext;


        public AutorService(IAuthContext authContext)
        {
            // Recibe el AuthContext desde el entorno (WinForm o Blazor)
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }


        public async Task<List<Autor>> GetAutoresAsync()
        {
            List<Autor> autores = new List<Autor>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Autors");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                autores = System.Text.Json.JsonSerializer.Deserialize<List<Autor>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            }
            //verificar que la clase Libro se corresponda con el jsonString retornado
            return autores;
        }
        /*
        public async Task CrearAutorAsync(Autor autor)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Autors", autor);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el autor: {response.StatusCode} - {errorMessage}");
            }
        }
        */

        public async Task CrearAutorAsync(Autor autor)
        {
            var json = JsonConvert.SerializeObject(autor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsJsonAsync("api/Autors", autor);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el autor: {response.StatusCode} - {errorMessage}");
            }
        }

        public async Task ModificarAutorAsync(Autor autor)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Autors/{autor.Id}", autor);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al modificar el autor: {response.StatusCode} - {errorMessage}");
            }
        }

        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            try
            {
                // Realiza la solicitud GET a la API para obtener el autor por ID
                var response = await _httpClient.GetAsync($"api/Autors/{id}");

                // Verifica si la respuesta fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Deserializa el contenido de la respuesta a un objeto Autor
                    var autorJson = await response.Content.ReadAsStringAsync();
                    var autor = JsonConvert.DeserializeObject<Autor>(autorJson);
                    return autor;
                }
                else
                {
                    // Maneja errores de la API
                    throw new Exception($"Error al obtener el autor: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                throw new Exception($"Ocurrió un error al intentar obtener el autor: {ex.Message}");
            }
        }


    }
}
