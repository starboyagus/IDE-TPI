using Domain.Model;

namespace DTOs
{
    public class UsuarioAuthDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }
    }

    public class AuthResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public UsuarioAuthDTO Usuario { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}