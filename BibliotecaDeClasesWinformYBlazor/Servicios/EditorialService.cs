using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor;
using Newtonsoft.Json;

namespace BibliotecaDeClasesWinformYBlazor.Servicios
{
    public class EditorialService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthContext _authContext;


        public EditorialService(IAuthContext authContext)
        {
            // Recibe el AuthContext desde el entorno (WinForm o Blazor)
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }



        // Método para obtener todas las editoriales
        public async Task<List<Editorial>> GetEditorialesAsync()
        {
            List<Editorial> editoriales = new List<Editorial>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Editorials");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                editoriales = System.Text.Json.JsonSerializer.Deserialize<List<Editorial>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return editoriales;
        }

        // Método para crear una nueva editorial
        public async Task CrearEditorialAsync(Editorial editorial)
        {
            var json = JsonConvert.SerializeObject(editorial);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsJsonAsync("api/Editorials", editorial);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear la editorial: {response.StatusCode} - {errorMessage}");
            }
        }

        // Método para modificar una editorial existente
        public async Task ModificarEditorialAsync(Editorial editorial)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Editorials/{editorial.Id}", editorial);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al modificar la editorial: {response.StatusCode} - {errorMessage}");
            }
        }

        // Método para obtener una editorial por su ID
        public async Task<Editorial> GetEditorialByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Editorials/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var editorialJson = await response.Content.ReadAsStringAsync();
                    var editorial = JsonConvert.DeserializeObject<Editorial>(editorialJson);
                    return editorial;
                }
                else
                {
                    throw new Exception($"Error al obtener la editorial: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al intentar obtener la editorial: {ex.Message}");
            }
        }
    }
}
