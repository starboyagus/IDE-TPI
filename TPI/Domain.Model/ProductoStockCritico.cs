namespace Domain.Model
{
    public class ProductoStockCritico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool EsPreVenta { get; set; }
        public string Criticidad { get; set; } = string.Empty;
        public int PrioridadCriticidad { get; set; }
    }
}
