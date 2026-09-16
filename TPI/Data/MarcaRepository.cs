using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly TPIContext _context;

        public MarcaRepository(TPIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
                return false;

            marca.SetEsActivo(false);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Marca?> GetAsync(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<IEnumerable<Marca>> GetAllAsync()
        {
            return await _context.Marcas.Where(u => u.EsActivo).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Marca marca)
        {
            var existing = await _context.Marcas.FindAsync(marca.Id);
            if (existing == null)
                return false;

            existing.SetNombre(marca.Nombre);
            existing.SetPaisOrigen(marca.PaisOrigen);
            existing.SetEsActivo(marca.EsActivo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> NombreExistsAsync(string nombre, int? excludeId = null)
        {
            var query = _context.Marcas.Where(u => u.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

    }
}
