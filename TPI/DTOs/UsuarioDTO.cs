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
        public RolUsuario Rol { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsActivo { get; set; }
    }
}
