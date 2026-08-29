using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class ProductoApiClient
    {
       

        public static async Task<List<ProductoDTO>?> GetAllAsync()
        {
            var response = await ApiClient.Http.GetAsync("productos");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ProductoDTO>>() ?? new List<ProductoDTO>();

        }

        public static async Task<ProductoDTO?> GetAsync(int id)
        {
            var response = await ApiClient.Http.GetAsync($"productos/{id}");

            // El producto ya no existe: se devuelve null para que el form muestre su propio mensaje.
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductoDTO>();
        }

        public static async Task<HttpResponseMessage?> UpdateAsync(ProductoDTO producto)
        {

            return await ApiClient.Http.PutAsJsonAsync("productos", producto);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<ProductoDTO>();
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await ApiClient.Http.DeleteAsync($"productos/{id}");

            return response.IsSuccessStatusCode;
        }

        public static async Task<HttpResponseMessage> AddAsync(ProductoDTO producto)
        {
            return await ApiClient.Http.PostAsJsonAsync("productos", producto);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<ProductoDTO>();
        }
    }
}
