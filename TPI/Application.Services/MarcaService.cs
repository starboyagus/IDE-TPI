using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class MarcaService : IMarcaService
    {

        private readonly IMarcaRepository marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }
        

        public async Task<MarcaDTO> AddAsync(MarcaDTO dto)
        {
            if (await marcaRepository.NombreExistsAsync(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe una marca con el Nombre '{dto.Nombre}'.");
            }

            var fechaAlta = DateTime.Now;
            Marca marca = new Marca(0, dto.Nombre, dto.PaisOrigen, fechaAlta, true);

            await marcaRepository.AddAsync(marca);

            dto.Id = marca.Id;
            dto.FechaAlta = marca.FechaAlta;
            dto.EsActivo = marca.EsActivo;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await marcaRepository.DeleteAsync(id);
        }

        public async Task<MarcaDTO?> GetAsync(int id)
        {
            Marca? marca = await marcaRepository.GetAsync(id);

            if (marca == null)
                return null;

            return new MarcaDTO
            {
                Id = marca.Id,
                Nombre = marca.Nombre,
                PaisOrigen = marca.PaisOrigen,
                FechaAlta = marca.FechaAlta,
                EsActivo = marca.EsActivo
            };
        }

        public async Task<IEnumerable<MarcaDTO>> GetAllAsync()
        {
            var marcas = await marcaRepository.GetAllAsync();

            return marcas.Select(marca => new MarcaDTO
            {
                Id = marca.Id,
                Nombre = marca.Nombre,
                PaisOrigen = marca.PaisOrigen,
                FechaAlta = marca.FechaAlta,
                EsActivo = marca.EsActivo
            }).ToList();
        }

        public async Task<bool> UpdateAsync(MarcaDTO dto)
        {
            if (await marcaRepository.NombreExistsAsync(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe una marca con el Nombre '{dto.Nombre}'.");
            }

            // Obtener el producto existente para preservar FechaAlta
            var existing = await marcaRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Marca marca = new Marca(dto.Id, dto.Nombre, dto.PaisOrigen, existing.FechaAlta, dto.EsActivo);
            return await marcaRepository.UpdateAsync(marca);
        }
    }
}   
