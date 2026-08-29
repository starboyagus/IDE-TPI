using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public static class UsuarioApiClient
    {
        public static async Task<UsuarioDTO?> LoginAsync(string email, string contrasenia)
        {
            var credenciales = new LoginDTO { Email = email, Contrasenia = contrasenia };

            var response = await ApiClient.Http.PostAsJsonAsync("usuarios/login", credenciales);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public static async Task<List<UsuarioDTO>?> GetAllAsync()
        {
            var response = await ApiClient.Http.GetAsync("usuarios");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>() ?? new List<UsuarioDTO>();

        }

        public static async Task<UsuarioDTO?> GetAsync(int id)
        {
            var response = await ApiClient.Http.GetAsync($"usuarios/{id}");

            // El usuario ya no existe: se devuelve null para que el form muestre su propio mensaje.
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public static async Task<HttpResponseMessage?> UpdateAsync(UsuarioDTO usuario)
        {

            return await ApiClient.Http.PutAsJsonAsync("usuarios", usuario);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            var response = await ApiClient.Http.DeleteAsync($"usuarios/{id}");

            return response.IsSuccessStatusCode;
        }

        public static async Task<HttpResponseMessage> AddAsync(UsuarioDTO usuario)
        {
            return await ApiClient.Http.PostAsJsonAsync("usuarios", usuario);

            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }
    }
}
