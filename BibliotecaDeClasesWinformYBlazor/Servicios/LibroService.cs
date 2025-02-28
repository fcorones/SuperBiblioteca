using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Servicios
{
    public class LibroService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthContext _authContext;


        public LibroService(IAuthContext authContext)
        {
            // Recibe el AuthContext desde el entorno (WinForm o Blazor)
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }


        public async Task<List<Libro>> GetLibrosPaginadosAsync(int pagina, int tamañoPagina)
{
    try
    {
        var response = await _httpClient.GetAsync($"api/Libros?pagina={pagina}&tamañoPagina={tamañoPagina}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<List<Libro>>(jsonString, 
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Libro>();
        }
        else
        {
            return new List<Libro>();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error obteniendo libros: {ex.Message}");
        return new List<Libro>();
    }
}


        public async Task<List<Libro>> GetLibrosAsync()
        {
            List<Libro> libros = new List<Libro>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Libros");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                libros = System.Text.Json.JsonSerializer.Deserialize<List<Libro>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            }
            //verificar que la clase Libro se corresponda con el jsonString retornado
            return libros;
        }
       
        
        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Libros/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Libro>(jsonResponse);
            }
            return null;
        }
        

        public async Task CrearLibroAsync(Libro libro)
        {
            var json = JsonConvert.SerializeObject(libro); // Serialización a JSON
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsJsonAsync("api/libros", libro);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($" {errorMessage}");
            }
        }

        public async Task ModificarLibroAsync(Libro libro)
        {
            var json = JsonConvert.SerializeObject(libro); // Serializar a JSON
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/libros/{libro.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($" {errorMessage}");
            }
        }

    }
}



