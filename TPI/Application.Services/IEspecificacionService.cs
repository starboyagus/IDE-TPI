using DTOs;

namespace Application.Services
{
    public interface IEspecificacionService
    {
        Task<EspecificacionDTO> AddAsync(EspecificacionDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<EspecificacionDTO?> GetAsync(int id);
        Task<IEnumerable<EspecificacionDTO>> GetAllAsync();
        Task<bool> UpdateAsync(EspecificacionDTO dto);
    }
}
