using Domain.Model;

namespace Data
{
    public interface IReporteRepository
    {
        Task<VentasResumen> GetResumenVentasAsync(ReporteCriteria criteria);
        Task<IEnumerable<VentasPorMes>> GetVentasPorMesAsync(ReporteCriteria criteria);
        Task<IEnumerable<ProductoVendido>> GetTopProductosAsync(ReporteCriteria criteria);
        Task<IEnumerable<FacturacionMarca>> GetFacturacionPorMarcaAsync(ReporteCriteria criteria);
    }
}
