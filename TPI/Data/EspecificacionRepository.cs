using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EspecificacionRepository : IEspecificacionRepository
    {
        private readonly TPIContext _context;

        public EspecificacionRepository(TPIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Especificacion especificacion)
        {
            _context.Especificaciones.Add(especificacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var marca = await _context.Especificaciones.FindAsync(id);
            if (marca == null)
                return false;

            marca.SetEsActivo(false);
            await _context.SaveChangesAsync();
            return true;

            //Revisar 
        }

        public async Task<Especificacion?> GetAsync(int id)
        {
            return await _context.Especificaciones
                .Include(e => e.Producto)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Especificacion>> GetAllAsync()
        {
            return await _context.Especificaciones
                .Include(e => e.Producto)
                .Where(e => e.EsActivo)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Especificacion especificacion)
        {
            var existing = await _context.Especificaciones.FindAsync(especificacion.Id);
            if (existing == null)
                return false;

            existing.SetClave(especificacion.Clave);
            existing.SetValor(especificacion.Valor);
            existing.SetUnidad(especificacion.Unidad);
            existing.SetProductoId(especificacion.ProductoId);
            existing.SetEsActivo(especificacion.EsActivo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClaveExistsEnProductoAsync(int productoId, string clave, int? excludeId = null)
        {
            var query = _context.Especificaciones
                .Where(e => e.ProductoId == productoId && e.Clave.ToLower() == clave.ToLower());

            if (excludeId.HasValue)
                query = query.Where(e => e.Id != excludeId.Value);

            return await query.AnyAsync();
        }

    }
}
