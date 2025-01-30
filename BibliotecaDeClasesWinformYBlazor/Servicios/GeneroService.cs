using BibliotecaDeClasesWinformYBlazor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Servicios
{
    public class GenerosService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthContext _authContext;

        public GenerosService(IAuthContext authContext)
        {
            // Recibe el AuthContext desde el entorno (WinForm o Blazor)
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }

        public async Task<List<Genero>> GetGenerosAsync()
        {
            List<Genero> generos = new List<Genero>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Generos");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                generos = System.Text.Json.JsonSerializer.Deserialize<List<Genero>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return generos;
        }

        public async Task<Genero> GetGeneroByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Generos/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var generoJson = await response.Content.ReadAsStringAsync();
                    var genero = JsonConvert.DeserializeObject<Genero>(generoJson);
                    return genero;
                }
                else
                {
                    throw new Exception($"Error al obtener el género: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al intentar obtener el género: {ex.Message}");
            }
        }

        public async Task CrearGeneroAsync(Genero genero)
        {
            var json = JsonConvert.SerializeObject(genero);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Generos", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el género: {response.StatusCode} - {errorMessage}");
            }
        }

        public async Task ModificarGeneroAsync(Genero genero)
        {
            var json = JsonConvert.SerializeObject(genero);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Generos/{genero.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al modificar el género: {response.StatusCode} - {errorMessage}");
            }
        }
    }
}
