using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Servicios
{
    public class PrestamoService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthContext _authContext;

        public PrestamoService(IAuthContext authContext)
        {
            // Recibe el AuthContext desde el entorno (WinForm o Blazor)
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
            _httpClient = HttpClientProvider.GetHttpClient(_authContext.UserToken);
        }

        public async Task<List<Prestamo>> GetPrestamosAsync()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/Prestamos");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                prestamos = JsonConvert.DeserializeObject<List<Prestamo>>(jsonString);
            }
            return prestamos;
        }

        public async Task<Prestamo> GetPrestamoByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Prestamos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Prestamo>(jsonString);
            }
            return null;
        }

        public async Task CrearPrestamoAsync(Prestamo prestamo)
        {
            var json = JsonConvert.SerializeObject(prestamo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Prestamos", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la API: {errorMessage}");
            }
        }

        public async Task ModificarPrestamoAsync(Prestamo prestamo)
        {
            var json = JsonConvert.SerializeObject(prestamo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Prestamos/{prestamo.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la API: {errorMessage}");
            }

            // Actualizar el estado del libro correspondiente
            var libroService = new LibroService(_authContext);
            var libro = await libroService.GetLibroByIdAsync(prestamo.LibroId);

            if (libro != null)
            {
                libro.BoolPrestado = prestamo.Activo; // Si el préstamo está activo, el libro está prestado
                await libroService.ModificarLibroAsync(libro);
            }
        }




    }
}
