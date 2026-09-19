using System.Net;
using API.Clients;
using Domain.Model;
using DTOs;

namespace AuthService
{
    public static class AuthService
    {
        public static string? Token { get; private set; }
        public static UsuarioAuthDTO? UsuarioActual { get; private set; }
        public static DateTime? Expiration { get; private set; }

        public static bool IsAuthenticated => !string.IsNullOrEmpty(Token) && UsuarioActual != null;
        public static bool IsAdmin => UsuarioActual?.Rol == RolUsuario.Admin;

        public static event Action? SesionCambio;

        public static async Task<AuthResponseDTO?> LoginAsync(string email, string contrasenia)
        {
            var authResult = await UsuarioApiClient.LoginAsync(email, contrasenia);

            if (authResult != null && !string.IsNullOrEmpty(authResult.Token))
            {
                Token = authResult.Token;
                UsuarioActual = authResult.Usuario;
                Expiration = authResult.Expiration;
                ApiClient.SetAuthToken(authResult.Token);
                SesionCambio?.Invoke();
            }

            return authResult;
        }

        public static void Logout()
        {
            Token = null;
            UsuarioActual = null;
            Expiration = null;
            ApiClient.ClearAuthToken();
            SesionCambio?.Invoke();
        }
    }
}
