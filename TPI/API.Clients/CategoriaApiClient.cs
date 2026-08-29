using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public static class CategoriaApiClient
    {
        public static async Task<List<CategoriaDTO>> GetAllAsync()
        {
            var response = await ApiClient.Http.GetAsync("categorias");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CategoriaDTO>>() ?? new List<CategoriaDTO>();
        }

        public static async Task<CategoriaDTO?> GetAsync(int id)
        {
            var response = await ApiClient.Http.GetAsync($"categorias/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CategoriaDTO>();
        }

        public static async Task<HttpResponseMessage> AddAsync(CategoriaDTO categoria)
        {
            return await ApiClient.Http.PostAsJsonAsync("categorias", categoria);
        }

        public static async Task<HttpResponseMessage> UpdateAsync(CategoriaDTO categoria)
        {
            return await ApiClient.Http.PutAsJsonAsync("categorias", categoria);
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await ApiClient.Http.DeleteAsync($"categorias/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
