using DTOs;

namespace Application.Services
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> AddAsync(CategoriaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<CategoriaDTO?> GetAsync(int id);
        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(CategoriaDTO dto);

    }
}
