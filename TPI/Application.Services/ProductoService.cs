using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IMarcaRepository marcaRepository;

        public ProductoService(IProductoRepository productoRepository, ICategoriaRepository categoriaRepository, IMarcaRepository marcaRepository)
        {
            this.productoRepository = productoRepository;
            this.categoriaRepository = categoriaRepository;
            this.marcaRepository = marcaRepository;
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

        private async Task ValidarMarcaAsync(int marcaId)
        {
            var marca = await marcaRepository.GetAsync(marcaId);

            if (marca == null || !marca.EsActivo)
            {
                throw new ArgumentException("La marca seleccionada no existe o no está activa.");
            }
        }

        private static string? MostrarEspecificaciones(Producto producto)
        {
            var activas = producto.Especificaciones.Where(e => e.EsActivo).ToList();
            if (!activas.Any())
                return null;

            return string.Join(" | ", activas.Select(e =>
                string.IsNullOrWhiteSpace(e.Unidad) ? $"{e.Clave}: {e.Valor}" : $"{e.Clave}: {e.Valor} {e.Unidad}"));
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
            await ValidarMarcaAsync(dto.MarcaId);

            var fechaAlta = DateTime.Now;
            Producto producto = new Producto(0, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.EsPreVenta, dto.CategoriaId, dto.MarcaId, fechaAlta, true);

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
                MarcaId = producto.MarcaId,
                Marca = producto.Marca?.Nombre,
                Especificaciones = MostrarEspecificaciones(producto),
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
                MarcaId = producto.MarcaId,
                Marca = producto.Marca?.Nombre,
                Especificaciones = MostrarEspecificaciones(producto),
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
            await ValidarMarcaAsync(dto.MarcaId);

            // Obtener el producto existente para preservar FechaAlta
            var existing = await productoRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Producto producto = new Producto(dto.Id, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.EsPreVenta, dto.CategoriaId, dto.MarcaId, existing.FechaAlta, dto.EsActivo);
            return await productoRepository.UpdateAsync(producto);
        }
    }
}
