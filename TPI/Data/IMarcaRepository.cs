using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IMarcaRepository
    {
        Task AddAsync(Marca marca);
        Task<bool> DeleteAsync(int id);
        Task<Marca?> GetAsync(int id);
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<bool> UpdateAsync(Marca marca);
        Task<bool> NombreExistsAsync(string nombre, int? excludeId = null);
    }
}
