using DTOs;

namespace Application.Services
{
    public interface IMarcaService
    {
        Task<MarcaDTO> AddAsync(MarcaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<MarcaDTO?> GetAsync(int id);
        Task<IEnumerable<MarcaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(MarcaDTO dto);
    }
}