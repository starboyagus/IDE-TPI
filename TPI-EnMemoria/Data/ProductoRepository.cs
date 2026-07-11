using Domain.Model;

namespace Data
{
    public class ProductoRepository : IProductoRepository
    {
        private static readonly List<Producto> productos = new List<Producto>();
        private static int nextId = 1;

        public Task AddAsync(Producto producto)
        {
            // Simular auto-increment de ID
            producto.SetId(nextId);
            nextId++;
            productos.Add(producto);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                productos.Remove(producto);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Producto?> GetAsync(int id)
        {
            return Task.FromResult(productos.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Producto>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Producto>>(productos.ToList());
        }

        public Task<bool> UpdateAsync(Producto producto)
        {
            var existing = productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existing != null)
            {
                existing.SetNombre(producto.Nombre);
                existing.SetDescripcion(producto.Descripcion);
                existing.SetPrecio(producto.Precio);
                existing.SetStock(producto.Stock);
                existing.SetEsPreVenta(producto.EsPreVenta);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

    }
}
