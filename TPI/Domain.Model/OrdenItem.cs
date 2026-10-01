using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class OrdenItem
    {
        public int Id { get; private set; }
        public int OrdenId { get; private set; }
        public Orden? Orden { get; private set; }
        public int ProductoId { get; private set; }
        public Producto? Producto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public OrdenItem(int id, int ordenId, int productoId, int cantidad, decimal precioUnitario)
        {
            SetId(id);
            SetOrdenId(ordenId);
            SetProductoId(productoId);
            SetCantidad(cantidad);
            SetPrecioUnitario(precioUnitario);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetOrdenId(int ordenId)
        {
            if (ordenId < 0)
                throw new ArgumentException("El Id de la orden debe ser mayor que 0.", nameof(ordenId));
            OrdenId = ordenId;
        }
        public void SetProductoId(int productoId)
        {
            if (productoId <= 0)
                throw new ArgumentException("El Id del producto debe ser mayor que 0.", nameof(productoId));
            ProductoId = productoId;
        }
        public void SetCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que 0.", nameof(cantidad));
            Cantidad = cantidad;
        }
        public void SetPrecioUnitario(decimal precioUnitario)
        {
            if (precioUnitario < 0)
                throw new ArgumentException("El precio unitario debe ser mayor o igual a 0.", nameof(precioUnitario));
            PrecioUnitario = precioUnitario;
        }
    }
}
