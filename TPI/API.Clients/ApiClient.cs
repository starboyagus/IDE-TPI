using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace API.Clients
{
    public static class ApiClient
    {
        public static HttpClient Http { get; private set; } = null!;

        public static void Configurar(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("La URL de la API no está configurada.", nameof(baseUrl));

            Http = new HttpClient(new SesionExpiradaHandler { InnerHandler = new HttpClientHandler() })
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public static bool SesionVencida { get; private set; }

        public static event Action? SesionExpirada;
        internal static void MarcarSesionVencida()
        {
            if (SesionVencida)
                return;

            SesionVencida = true;
            SesionExpirada?.Invoke();
        }

        public static void SetAuthToken(string token)
        {
            SesionVencida = false;
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static void ClearAuthToken()
        {
            Http.DefaultRequestHeaders.Authorization = null;
        }
    }


}
