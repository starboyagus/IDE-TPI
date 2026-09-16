using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class MarcaApiClient
    {

        public static async Task<List<MarcaDTO>?> GetAllAsync()
        {
            var response = await ApiClient.Http.GetAsync("marcas");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MarcaDTO>>() ?? new List<MarcaDTO>();

        }

        public static async Task<MarcaDTO?> GetAsync(int id)
        {
            var response = await ApiClient.Http.GetAsync($"marcas/{id}");

            // La marca ya no existe: se devuelve null para que el form muestre su propio mensaje.
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MarcaDTO>();
        }

        public static async Task<HttpResponseMessage?> UpdateAsync(MarcaDTO marca)
        {

            return await ApiClient.Http.PutAsJsonAsync("marcas", marca);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<MarcaDTO>();
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await ApiClient.Http.DeleteAsync($"marcas/{id}");

            return response.IsSuccessStatusCode;
        }

        public static async Task<HttpResponseMessage> AddAsync(MarcaDTO marca)
        {
            return await ApiClient.Http.PostAsJsonAsync("marcas", marca);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<MarcaDTO>();
        }
    }
}
