using Domain.Model;

namespace Data
{
    public interface IOrdenRepository
    {
        Task AddAsync(Orden orden);
        Task<bool> DeleteAsync(int id);
        Task<Orden?> GetAsync(int id);
        Task<IEnumerable<Orden>> GetAllAsync();
        Task<IEnumerable<Orden>> GetByUsuarioAsync(int usuarioId);
        Task<bool> UpdateAsync(Orden orden);
    }
}