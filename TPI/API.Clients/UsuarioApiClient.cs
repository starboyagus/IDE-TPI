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
    }
}
