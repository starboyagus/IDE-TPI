using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class EspecificacionApiClient
    {

        public static async Task<List<EspecificacionDTO>?> GetAllAsync()
        {
            var response = await ApiClient.Http.GetAsync("especificaciones");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<EspecificacionDTO>>() ?? new List<EspecificacionDTO>();

        }

        public static async Task<EspecificacionDTO?> GetAsync(int id)
        {
            var response = await ApiClient.Http.GetAsync($"especificaciones/{id}");

            // La especificacion ya no existe: se devuelve null para que el form muestre su propio mensaje.
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<EspecificacionDTO>();
        }

        public static async Task<HttpResponseMessage?> UpdateAsync(EspecificacionDTO especificacion)
        {

            return await ApiClient.Http.PutAsJsonAsync("especificaciones", especificacion);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<EspecificacionDTO>();
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await ApiClient.Http.DeleteAsync($"especificaciones/{id}");

            return response.IsSuccessStatusCode;
        }

        public static async Task<HttpResponseMessage> AddAsync(EspecificacionDTO especificacion)
        {
            return await ApiClient.Http.PostAsJsonAsync("especificaciones", especificacion);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<EspecificacionDTO>();
        }

        public static async Task<List<EspecificacionDTO>?> GetByProductoAsync(int productoId)
        {
            var response = await ApiClient.Http.GetAsync($"especificaciones/producto/{productoId}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<EspecificacionDTO>>() ?? new List<EspecificacionDTO>();
        }
    }
}
