using DTOs;

namespace Application.Services
{
    public interface IProductoService
    {
        Task<ProductoDTO> AddAsync(ProductoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<ProductoDTO?> GetAsync(int id);
        Task<IEnumerable<ProductoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ProductoDTO dto);
    }
}