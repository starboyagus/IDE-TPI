using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class EspecificacionService : IEspecificacionService
    {
        private readonly IEspecificacionRepository especificacionRepository;
        private readonly IProductoRepository productoRepository;


        public EspecificacionService(IEspecificacionRepository especificacionRepository, IProductoRepository productoRepository)
        {
            this.especificacionRepository = especificacionRepository;
            this.productoRepository = productoRepository;
        }

        // Evita que llegue a la base un ProductoId inexistente o dado de baja (sería un error de clave foránea).
        private async Task ValidarProductoAsync(int productoId)
        {
            var producto = await productoRepository.GetAsync(productoId);

            if (producto == null || !producto.EsActivo)
            {
                throw new ArgumentException("El producto seleccionado no existe o no está activo.");
            }
        }

        public async Task<EspecificacionDTO> AddAsync(EspecificacionDTO dto)
        {
            if (await especificacionRepository.ClaveExistsEnProductoAsync(dto.ProductoId, dto.Clave))
            {
                throw new ArgumentException($"El producto ya tiene una especificación con la clave '{dto.Clave}'.");
            }

            await ValidarProductoAsync(dto.ProductoId);

            var fechaAlta = DateTime.Now;
            Especificacion especificacion= new Especificacion(0, dto.Clave, dto.Valor, dto.Unidad, dto.ProductoId, fechaAlta, true);

            await especificacionRepository.AddAsync(especificacion);

            dto.Id = especificacion.Id;
            dto.FechaAlta = especificacion.FechaAlta;
            dto.EsActivo = especificacion.EsActivo;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await especificacionRepository.DeleteAsync(id);
        }

        public async Task<EspecificacionDTO?> GetAsync(int id)
        {
            Especificacion? especificacion = await especificacionRepository.GetAsync(id);

            if (especificacion == null)
                return null;

            return new EspecificacionDTO
            {
                Id = especificacion.Id,
                Clave = especificacion.Clave,
                Valor = especificacion.Valor,
                Unidad = especificacion.Unidad,
                ProductoId = especificacion.ProductoId,
                Producto = especificacion.Producto?.Nombre,
                FechaAlta = especificacion.FechaAlta,
                EsActivo = especificacion.EsActivo
            };
        }

        public async Task<IEnumerable<EspecificacionDTO>> GetAllAsync()
        {
            var especificaciones = await especificacionRepository.GetAllAsync();

            return especificaciones.Select(especificacion => new EspecificacionDTO
            {
                Id = especificacion.Id,
                Clave = especificacion.Clave,
                Valor = especificacion.Valor,
                Unidad = especificacion.Unidad,
                ProductoId = especificacion.ProductoId,
                Producto = especificacion.Producto?.Nombre,
                FechaAlta = especificacion.FechaAlta,
                EsActivo = especificacion.EsActivo
            }).ToList();
        }

        public async Task<bool> UpdateAsync(EspecificacionDTO dto)
        {
           
            // Obtener la especificacion existente para preservar FechaAlta y ProductoId
            var existing = await especificacionRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            if (await especificacionRepository.ClaveExistsEnProductoAsync(existing.ProductoId, dto.Clave, dto.Id))
            {
                throw new ArgumentException($"El producto ya tiene una especificación con la clave '{dto.Clave}'.");
            }

            Especificacion especificacion = new Especificacion(dto.Id, dto.Clave, dto.Valor, dto.Unidad, existing.ProductoId, existing.FechaAlta, dto.EsActivo);
            return await especificacionRepository.UpdateAsync(especificacion);
        }

        public async Task<IEnumerable<EspecificacionDTO>> GetByProductoAsync(int productoId)
        {
            var especificaciones = await especificacionRepository.GetByProductoAsync(productoId);

            return especificaciones.Select(especificacion => new EspecificacionDTO
            {
                Id = especificacion.Id,
                Clave = especificacion.Clave,
                Valor = especificacion.Valor,
                Unidad = especificacion.Unidad,
                ProductoId = especificacion.ProductoId,
                Producto = especificacion.Producto?.Nombre,
                FechaAlta = especificacion.FechaAlta,
                EsActivo = especificacion.EsActivo
            }).ToList();
        }
    }
}
