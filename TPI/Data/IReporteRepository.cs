using Domain.Model;

namespace Data
{
    public interface IReporteRepository
    {
        Task<VentasResumen> GetResumenVentasAsync(ReporteCriteria criteria);
        Task<IEnumerable<VentasPorMes>> GetVentasPorMesAsync(ReporteCriteria criteria);
        Task<IEnumerable<ProductoVendido>> GetTopProductosAsync(ReporteCriteria criteria);
        Task<IEnumerable<FacturacionMarca>> GetFacturacionPorMarcaAsync(ReporteCriteria criteria);

        Task<IEnumerable<ProductoStockCritico>> GetProductosStockCriticoAsync(int umbralMinimo, string? tipoFiltro, int? categoriaId = null, int? marcaId = null);
        Task<StockCriticoResumen> GetResumenStockCriticoAsync(int umbralMinimo);
        Task<IEnumerable<StockPorCategoria>> GetStockCriticoPorCategoriaAsync(int umbralMinimo);
        Task<IEnumerable<StockPorMarca>> GetStockCriticoPorMarcaAsync(int umbralMinimo);
    }
}
