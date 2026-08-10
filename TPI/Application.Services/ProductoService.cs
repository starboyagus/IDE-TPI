using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public async Task<ProductoDTO> AddAsync(ProductoDTO dto)
        {

            var fechaAlta = DateTime.Now;
            Producto producto = new Producto(0, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.EsPreVenta, fechaAlta, true);

            await productoRepository.AddAsync(producto);

            dto.Id = producto.Id;
            dto.FechaAlta = producto.FechaAlta;
            dto.EsActivo = producto.EsActivo;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await productoRepository.DeleteAsync(id);
        }

        public async Task<ProductoDTO?> GetAsync(int id)
        {
            Producto? producto = await productoRepository.GetAsync(id);

            if (producto == null)
                return null;

            return new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                EsPreVenta = producto.EsPreVenta,
                FechaAlta = producto.FechaAlta,
                EsActivo = producto.EsActivo
            };
        }

        public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
        {
            var productos = await productoRepository.GetAllAsync();

            return productos.Select(producto => new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                EsPreVenta = producto.EsPreVenta,
                FechaAlta = producto.FechaAlta,
                EsActivo = producto.EsActivo
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ProductoDTO dto)
        {
            // Obtener el producto existente para preservar FechaAlta
            var existing = await productoRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Producto producto = new Producto(dto.Id, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.EsPreVenta, existing.FechaAlta, dto.EsActivo);
            return await productoRepository.UpdateAsync(producto);
        }
    }
}
