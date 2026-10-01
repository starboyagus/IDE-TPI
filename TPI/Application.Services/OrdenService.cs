using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenRepository ordenRepository;
        private readonly IProductoRepository productoRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public OrdenService(IOrdenRepository ordenRepository, IProductoRepository productoRepository, IUsuarioRepository usuarioRepository)
        {
            this.ordenRepository = ordenRepository;
            this.productoRepository = productoRepository;
            this.usuarioRepository = usuarioRepository;
            
        }

        private async Task ValidarUsuarioAsync(int usuarioId)
        {
            var usuario = await usuarioRepository.GetAsync(usuarioId);
            if (usuario==null || usuario.EsActivo == false)
            {
                throw new ArgumentException("El usuario no existe o no esta activo");
            }
        }

        private static void ValidarItems(List<OrdenItemDTO> items)
        {
            if(items == null || !items.Any())
            {
                throw new ArgumentException("La orden debe tener al menos un item");
            }
            if(items.Any(i=>i.Cantidad <= 0))
            {
                throw new ArgumentException("La cantidad de los productos debe ser distinta de 0");
            }
        }

        private async Task ValidarProductosAsync(List<OrdenItemDTO> items)
        {
            foreach (var i in items)
            {
                var producto = await productoRepository.GetAsync(i.ProductoId);
                if(producto == null || producto.EsActivo == false)
                {
                    throw new ArgumentException($"El producto {producto?.Nombre} no existe o no esta activo");
                }
                if (!producto.EsPreVenta)
                {
                    if (producto.Stock <= 0)
                    {
                        throw new ArgumentException($"El producto {producto.Nombre} se encuentra agotado.");
                    }
                    if (producto.Stock < i.Cantidad)
                    {
                        throw new ArgumentException($"El producto {producto.Nombre} no tiene stock suficiente. Quedan ({producto.Stock})");
                    }
                    
                }
            }
        }

        public async Task<OrdenDTO> AddAsync(OrdenDTO dto)
        {
            await ValidarUsuarioAsync(dto.UsuarioId);
            ValidarItems(dto.Items.ToList());
            await ValidarProductosAsync(dto.Items.ToList());

            var fechaAlta = DateTime.Now;
            Orden orden = new Orden(0, dto.Fecha, EstadoOrden.Procesando, 0, dto.UsuarioId, dto.DireccionEnvio, fechaAlta, true);
            dto.Total = 0;
            foreach (var i in dto.Items)
            {   
                var producto = await productoRepository.GetAsync(i.ProductoId);

                i.PrecioUnitario = producto!.Precio;
                dto.Total += producto.Precio * i.Cantidad;
                if (!producto.EsPreVenta)
                {
                    producto.SetStock(producto.Stock - i.Cantidad);
                    await productoRepository.UpdateAsync(producto);
                }
                orden.Items.Add(new OrdenItem(0, 0, i.ProductoId, i.Cantidad, i.PrecioUnitario));
            }


            orden.SetTotal(dto.Total);
            await ordenRepository.AddAsync(orden);

            dto.Id = orden.Id;
            dto.FechaAlta = orden.FechaAlta;
            dto.EsActivo = orden.EsActivo;
            dto.Estado = orden.Estado;

            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await ordenRepository.DeleteAsync(id);
        }
        public async Task<OrdenDTO?> GetAsync(int id)
        {
            Orden? orden = await ordenRepository.GetAsync(id);
            if(orden == null)
            {
                return null;
            }

            return new OrdenDTO
            {
                Id = orden.Id,
                Fecha = orden.Fecha,
                Estado = orden.Estado,
                Total = orden.Total,
                UsuarioId = orden.UsuarioId,
                Usuario = orden.Usuario != null ? $"{orden.Usuario.Nombre} {orden.Usuario.Apellido}" : null,
                DireccionEnvio = orden.DireccionEnvio,
                FechaAlta = orden.FechaAlta,
                EsActivo = orden.EsActivo,
                Items = orden.Items.Select(i => new OrdenItemDTO
                {
                    Id = i.Id,
                    OrdenId = i.OrdenId,
                    ProductoId = i.ProductoId,
                    Producto = i.Producto?.Nombre,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioUnitario
                }).ToList()
            };


        }
        public async Task<IEnumerable<OrdenDTO>> GetAllAsync()
        {
            var ordenes = await ordenRepository.GetAllAsync();

            return ordenes.Select(orden => new OrdenDTO
            {
                Id = orden.Id,
                Fecha = orden.Fecha,
                Estado = orden.Estado,
                Total = orden.Total,
                UsuarioId = orden.UsuarioId,
                Usuario = orden.Usuario != null ? $"{orden.Usuario.Nombre} {orden.Usuario.Apellido}" : null,
                DireccionEnvio = orden.DireccionEnvio,
                FechaAlta = orden.FechaAlta,
                EsActivo = orden.EsActivo,
                Items = orden.Items.Select(i => new OrdenItemDTO
                {
                    Id = i.Id,
                    OrdenId = i.OrdenId,
                    ProductoId = i.ProductoId,
                    Producto = i.Producto?.Nombre,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioUnitario
                }).ToList()
            }).ToList();
        }
        public async Task<bool> UpdateAsync(OrdenDTO dto)
        {
            await ValidarUsuarioAsync(dto.UsuarioId);
            var existing = await ordenRepository.GetAsync(dto.Id);
            if(existing == null)
            {
                return false;
            }

            Orden orden = new Orden(dto.Id, dto.Fecha, dto.Estado, dto.Total, dto.UsuarioId, dto.DireccionEnvio, existing.FechaAlta, existing.EsActivo);
            return await ordenRepository.UpdateAsync(orden);
        }
    }
}
