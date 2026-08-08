using Data;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TPIContext _context;

        public ClienteRepository(TPIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente?> GetAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(cliente.Id);
            if (existing == null)
                return false;

            existing.SetNombre(cliente.Nombre);
            existing.SetApellido(cliente.Apellido);
            existing.SetEmail(cliente.Email);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = _context.Clientes.Where(c => c.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Cliente>> GetByCriteriaAsync(ClienteCriteria criteria)
        {
            string searchTerm = criteria.Texto.ToLower();

            return await _context.Clientes.Where(c =>
                c.Nombre.ToLower().Contains(searchTerm) ||
                c.Apellido.ToLower().Contains(searchTerm) ||
                c.Email.ToLower().Contains(searchTerm)
            ).OrderBy(c => c.Nombre).ThenBy(c => c.Apellido).ToListAsync();
        }
    }
}
