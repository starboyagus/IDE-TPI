using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TPIContext _context;

        public ProductoRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return false;

            producto.SetEsActivo(false);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Producto?> GetAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.EsActivo)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Producto producto)
        {
            var existing = await _context.Productos.FindAsync(producto.Id);
            if (existing == null)
                return false;

            existing.SetNombre(producto.Nombre);
            existing.SetDescripcion(producto.Descripcion);
            existing.SetPrecio(producto.Precio);
            existing.SetStock(producto.Stock);
            existing.SetEsPreVenta(producto.EsPreVenta);
            existing.SetCategoriaId(producto.CategoriaId);
            existing.SetEsActivo(producto.EsActivo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> NombreExistsAsync(string nombre, int? excludeId = null)
        {
            var query = _context.Productos.Where(p => p.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> DescExistsAsync(string desc, int? excludeId = null)
        {
            var query = _context.Productos.Where(p => p.Descripcion.ToLower() == desc.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

    }
}
