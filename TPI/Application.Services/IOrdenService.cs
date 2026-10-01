using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IOrdenService
    {
        Task<OrdenDTO> AddAsync(OrdenDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<OrdenDTO?> GetAsync(int id);
        Task<IEnumerable<OrdenDTO>> GetAllAsync();
        Task<bool> UpdateAsync(OrdenDTO dto);
    }
}
