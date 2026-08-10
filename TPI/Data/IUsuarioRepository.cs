using Domain.Model;

namespace Data
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<Usuario?> GetAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task<IEnumerable<Usuario>> GetByCriteriaAsync(UsuarioCriteria criteria);
    }
}
