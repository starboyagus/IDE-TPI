using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly TPIContext _context;

        public OrdenRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Orden orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
                return false;

            orden.SetEsActivo(false);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Orden?> GetAsync(int id)
        {
            return await _context.Ordenes
                .Include(o => o.Items)
                .ThenInclude(i => i.Producto)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Orden>> GetAllAsync()
        {
            return await _context.Ordenes
                .Include(o => o.Items)
                .ThenInclude(i => i.Producto)
                .Include(o => o.Usuario)
                .Where(o => o.EsActivo)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Orden orden)
        {
            var existing = await _context.Ordenes.FindAsync(orden.Id);
            if (existing == null)
                return false;

            existing.SetEstado(orden.Estado);
            existing.SetTotal(orden.Total);
            existing.SetDireccionEnvio(orden.DireccionEnvio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
