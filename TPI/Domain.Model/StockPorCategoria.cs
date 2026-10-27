namespace Domain.Model
{
    public class StockPorCategoria
    {
        public int CategoriaId { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int CantidadProductos { get; set; }
    }
}
