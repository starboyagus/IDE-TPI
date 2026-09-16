using Domain.Model;

namespace Data
{
    public interface IEspecificacionRepository
    {
        Task AddAsync(Especificacion especificacion);
        Task<bool> DeleteAsync(int id);
        Task<Especificacion?> GetAsync(int id);
        Task<IEnumerable<Especificacion>> GetAllAsync();
        Task<bool> UpdateAsync(Especificacion especificacion);
        Task<bool> ClaveExistsEnProductoAsync(int productoId, string clave, int? excludeId = null);
    }
}
