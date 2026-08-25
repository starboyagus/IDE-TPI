using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly TPIContext _context;
        public CategoriaRepository (TPIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return false;
            try
            {
                categoria.SetEsActivo(false);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("No se puede eliminar la categoria porque tiene productos asociados.");
            }
            
        }
        public async Task<Categoria?> GetAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }
        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.Where(c => c.EsActivo).ToListAsync();
        }
        public async Task<bool> UpdateAsync(Categoria categoria)
        {
            var existing = await _context.Categorias.FindAsync(categoria.Id);
            if (existing == null)
                return false;

            existing.SetNombre(categoria.Nombre);
            existing.SetDescripcion(categoria.Descripcion);
            existing.SetEsActivo(categoria.EsActivo);

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> NombreExistsAsync(string nombre, int? excludeId = null)
        {
            var query = _context.Categorias.Where(c => c.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

    }
}
