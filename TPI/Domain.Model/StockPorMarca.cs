namespace Domain.Model
{
    public class StockPorMarca
    {
        public int MarcaId { get; set; }
        public string Marca { get; set; } = string.Empty;
        public int CantidadProductos { get; set; }
    }
}
