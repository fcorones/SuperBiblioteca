﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor
{
    public static class HttpClientProvider
    {
        private static HttpClient _httpClient;

        /// <summary>
        /// Inicializa o devuelve una instancia de HttpClient preconfigurada.
        /// </summary>
        /// <param name="jwtToken">El token JWT (puede ser null si no se requiere autorización).</param>
        /// <returns>Instancia configurada de HttpClient.</returns>
        public static HttpClient GetHttpClient(string jwtToken = null)
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7128/") // URL base de tu API
                };
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            // Configurar el token JWT si está disponible
            if (!string.IsNullOrEmpty(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            return _httpClient;
        }
    }
}
