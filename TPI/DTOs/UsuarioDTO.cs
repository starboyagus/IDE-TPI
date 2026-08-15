using Domain.Model;

namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        // Solo se usa para mandar una contraseña nueva (alta, o cambio en la edición).
        // En Update, dejarla vacía significa "no cambiar la contraseña". La API nunca la devuelve en las respuestas de GET.
        public string? Contrasenia { get; set; }
        public RolUsuario Rol { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsActivo { get; set; }
    }
}
