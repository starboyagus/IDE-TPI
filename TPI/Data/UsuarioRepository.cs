using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TPIContext _context;

        public UsuarioRepository(TPIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            usuario.SetEsActivo(false);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> GetAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.Where(u => u.EsActivo).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            var existing = await _context.Usuarios.FindAsync(usuario.Id);
            if (existing == null)
                return false;

            existing.SetNombre(usuario.Nombre);
            existing.SetApellido(usuario.Apellido);
            existing.SetEmail(usuario.Email);
            existing.SetTelefono(usuario.Telefono);
            existing.SetContrasenia(usuario.Contrasenia);
            existing.SetRol(usuario.Rol);
            existing.SetEsActivo(usuario.EsActivo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = _context.Usuarios.Where(u => u.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByCriteriaAsync(UsuarioCriteria criteria)
        {
            string searchTerm = criteria.Texto.ToLower();

            return await _context.Usuarios.Where(u =>
                u.EsActivo && (
                    u.Nombre.ToLower().Contains(searchTerm) ||
                    u.Apellido.ToLower().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm)
                )
            ).OrderBy(u => u.Nombre).ThenBy(u => u.Apellido).ToListAsync();
        }
    }
}
