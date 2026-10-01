using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public class OrdenApiClient
    {
        public static async Task<List<OrdenDTO>?> GetAllAsync()
        {
            var response = await ApiClient.Http.GetAsync("ordenes");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<OrdenDTO>>() ?? new List<OrdenDTO>();
        }

        public static async Task<OrdenDTO?> GetAsync(int id)
        {
            var response = await ApiClient.Http.GetAsync($"ordenes/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<OrdenDTO>();
        }

        public static async Task<HttpResponseMessage?> UpdateAsync(OrdenDTO orden)
        {
            return await ApiClient.Http.PutAsJsonAsync("ordenes", orden);
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await ApiClient.Http.DeleteAsync($"ordenes/{id}");

            return response.IsSuccessStatusCode;
        }

        public static async Task<HttpResponseMessage> AddAsync(OrdenDTO orden)
        {
            return await ApiClient.Http.PostAsJsonAsync("ordenes", orden);
        }
    }
}
