using Domain.Model;

namespace Data
{
    public interface IProductoRepository
    {
        Task AddAsync(Producto producto);
        Task<bool> DeleteAsync(int id);
        Task<Producto?> GetAsync(int id);
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<bool> UpdateAsync(Producto producto);
    }
}