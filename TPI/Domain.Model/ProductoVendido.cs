// Domain.Model/ProductoVendido.cs
namespace Domain.Model
{
    public class ProductoVendido
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public int UnidadesVendidas { get; set; }
        public decimal Facturacion { get; set; }
    }
}
