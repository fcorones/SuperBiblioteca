using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Servicios
{
    public interface IGeorefService
    {
        Task<List<Provincia>> ObtenerProvincias();
        Task<List<Ciudad>> ObtenerCiudadesPorProvincia(string provinciaNombre);
    }

    // Servicios/GeorefService.cs
    public class GeorefService : IGeorefService
    {
        private readonly HttpClient _httpClient;

        public GeorefService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://apis.datos.gob.ar/georef/api/");
        }

        public async Task<List<Provincia>> ObtenerProvincias()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponseProvincia>("provincias?campos=id,nombre&max=100");
            return response?.Provincias ?? new List<Provincia>();
        }
        public async Task<List<Ciudad>> ObtenerCiudadesPorProvincia(string provinciaNombre)
        {
            var url = $"localidades?provincia={Uri.EscapeDataString(provinciaNombre)}&campos=id,nombre&max=1000";
            Console.WriteLine($"URL de la solicitud: {url}");

            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponseCiudad>(url);
                var ciudades = response?.Localidades ?? new List<Ciudad>();

                var ciudadesUnicas = ciudades
                    .GroupBy(c => c.Nombre) 
                    .Select(g => g.First())
                    .ToList();
           

                return ciudadesUnicas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener ciudades: {ex.Message}");
                return new List<Ciudad>();
            }
        }

        // Clases para deserialización
        public class ApiResponseProvincia
        {
            public List<Provincia> Provincias { get; set; }
        }

        public class ApiResponseCiudad
        {
            public List<Ciudad> Localidades { get; set; }
        }
    }

    public class Provincia
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Ciudad
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
