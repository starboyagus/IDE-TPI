using DTOs;
using Domain.Model;
using Data;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaDTO> AddAsync(CategoriaDTO dto)
        {
            if (await categoriaRepository.NombreExistsAsync(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe una categoria con el Nombre '{dto.Nombre}'.");
            }

            var fechaAlta = DateTime.Now;

            Categoria categoria = new Categoria(0, dto.Nombre, dto.Descripcion, fechaAlta, true);

            await categoriaRepository.AddAsync(categoria);

            dto.Id = categoria.Id;
            dto.FechaAlta = categoria.FechaAlta;
            dto.EsActivo = categoria.EsActivo;

            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await categoriaRepository.DeleteAsync(id);
        }
        public async Task<CategoriaDTO?> GetAsync(int id)
        {
            Categoria? categoria = await categoriaRepository.GetAsync(id);

            if (categoria == null)
                return null;

            return new CategoriaDTO {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                FechaAlta = categoria.FechaAlta,
                EsActivo = categoria.EsActivo
            };


        }
        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await categoriaRepository.GetAllAsync();

            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                FechaAlta = c.FechaAlta,
                EsActivo = c.EsActivo
            }).ToList();
        }
        public async Task<bool> UpdateAsync(CategoriaDTO dto)
        {
            if (await categoriaRepository.NombreExistsAsync(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe una categoria con el Nombre '{dto.Nombre}'.");
            }

            // Obtener la categoria existente para preservar FechaAlta
            var existing = await categoriaRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Categoria categoria = new Categoria(dto.Id, dto.Nombre, dto.Descripcion, existing.FechaAlta, dto.EsActivo);
            return await categoriaRepository.UpdateAsync(categoria);
        }
    }
}
