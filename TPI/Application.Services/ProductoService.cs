using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;
        private readonly ICategoriaRepository categoriaRepository;

        public ProductoService(IProductoRepository productoRepository, ICategoriaRepository categoriaRepository)
        {
            this.productoRepository = productoRepository;
            this.categoriaRepository = categoriaRepository;
        }

        // Evita que llegue a la base una CategoriaId inexistente o dada de baja (sería un error de clave foránea).
        private async Task ValidarCategoriaAsync(int categoriaId)
        {
            var categoria = await categoriaRepository.GetAsync(categoriaId);

            if (categoria == null || !categoria.EsActivo)
            {
                throw new ArgumentException("La categoría seleccionada no existe o no está activa.");
            }
        }

        public async Task<ProductoDTO> AddAsync(ProductoDTO dto)
        {
            if (await productoRepository.NombreExistsAsync(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe un producto con el Nombre '{dto.Nombre}'.");
            }

            if (await productoRepository.DescExistsAsync(dto.Descripcion))
            {
                throw new ArgumentException($"Ya existe un producto con la Descripcion '{dto.Descripcion}'.");
            }

            await ValidarCategoriaAsync(dto.CategoriaId);

            var fechaAlta = DateTime.Now;
            Producto producto = new Producto(0, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.EsPreVenta, dto.CategoriaId, fechaAlta, true);

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
                CategoriaId = producto.CategoriaId,
                Categoria = producto.Categoria?.Nombre,
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
                CategoriaId = producto.CategoriaId,
                Categoria = producto.Categoria?.Nombre, 
                FechaAlta = producto.FechaAlta,
                EsActivo = producto.EsActivo
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ProductoDTO dto)
        {
            if (await productoRepository.NombreExistsAsync(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe un producto con el Nombre '{dto.Nombre}'.");
            }

            if (await productoRepository.DescExistsAsync(dto.Descripcion, dto.Id))
            {
                throw new ArgumentException($"Ya existe un producto con la Descripcion '{dto.Descripcion}'.");
            }

            await ValidarCategoriaAsync(dto.CategoriaId);

            // Obtener el producto existente para preservar FechaAlta
            var existing = await productoRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Producto producto = new Producto(dto.Id, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.EsPreVenta, dto.CategoriaId, existing.FechaAlta, dto.EsActivo);
            return await productoRepository.UpdateAsync(producto);
        }
    }
}
