using System.Net;
using System.Net.Http.Json;
using DTOs;

namespace API.Clients
{
    public static class UsuarioApiClient
    {
        /// <summary>
        /// Valida las credenciales contra la API.
        /// Devuelve el usuario si son correctas, o null si el email/contraseña no coinciden.
        /// Lanza excepción si no se pudo contactar a la API.
        /// </summary>
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
