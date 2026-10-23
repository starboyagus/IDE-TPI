namespace DTOs
{
    public class ProductoVendidoDTO
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public int UnidadesVendidas { get; set; }
        public decimal Facturacion { get; set; }
    }
}
