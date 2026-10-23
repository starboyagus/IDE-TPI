using System.Net.Http.Json;
using Domain.Model;
using DTOs;

namespace API.Clients
{
    public static class ReporteApiClient
    {
        private static string Filtros(DateTime desde, DateTime hasta, EstadoOrden? estado, int top) =>
            $"desde={desde:yyyy-MM-dd}&hasta={hasta:yyyy-MM-dd}&top={top}"
            + (estado.HasValue ? $"&estado={(int)estado.Value}" : "");

        public static async Task<InformeVentasDTO?> GetInformeVentasAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            var response = await ApiClient.Http.GetAsync($"reportes/ventas?{Filtros(desde, hasta, estado, top)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<InformeVentasDTO>();
        }

        public static async Task<byte[]> GetInformeVentasPdfAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            var response = await ApiClient.Http.GetAsync($"reportes/ventas/pdf?{Filtros(desde, hasta, estado, top)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        public static async Task<GraficosInformeDTO?> GetGraficosInformeAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            var response = await ApiClient.Http.GetAsync($"reportes/ventas/graficos?{Filtros(desde, hasta, estado, top)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GraficosInformeDTO>();
        }

    }
}
