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

            response.EnsureSuccessStatusCode();

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
