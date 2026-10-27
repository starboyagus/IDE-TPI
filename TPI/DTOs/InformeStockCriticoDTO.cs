namespace DTOs
{
    public class InformeStockCriticoDTO
    {
        public int UmbralMinimo { get; set; }
        public string? TipoFiltro { get; set; }
        public StockCriticoResumenDTO Resumen { get; set; } = new();
        public List<ProductoStockCriticoDTO> Productos { get; set; } = new();
        public List<StockPorCategoriaDTO> PorCategoria { get; set; } = new();
        public List<StockPorMarcaDTO> PorMarca { get; set; } = new();

        public string TipoFiltroDescripcion => TipoFiltro switch
        {
            "SinStock" => "Solo sin stock (0)",
            "StockBajo" => "Solo stock bajo umbral",
            "PreVenta" => "Solo en pre-venta",
            _ => "Todos en alerta"
        };
    }
}
