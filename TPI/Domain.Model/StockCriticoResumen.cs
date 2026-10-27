namespace Domain.Model
{
    public class StockCriticoResumen
    {
        public int TotalAlertas { get; set; }
        public int CantidadSinStock { get; set; }
        public int CantidadStockBajo { get; set; }
        public int CantidadPreVenta { get; set; }
    }
}
