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
            Producto producto = new Producto(0, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.esPreVenta, fechaAlta);

            await productoRepository.AddAsync(producto);

            dto.Id = producto.Id;
            dto.FechaAlta = producto.FechaAlta;

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
                esPreVenta = producto.EsPreVenta,
                FechaAlta = producto.FechaAlta
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
                esPreVenta = producto.EsPreVenta,
                FechaAlta = producto.FechaAlta
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ProductoDTO dto)
        {
            // Obtener el producto existente para preservar FechaAlta
            var existing = await productoRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Producto producto = new Producto(dto.Id, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.esPreVenta, existing.FechaAlta);
            return await productoRepository.UpdateAsync(producto);
        }
    }
}
