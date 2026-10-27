using Domain.Model;
using DTOs;

namespace Application.Services
{
    public interface IReporteService
    {
        Task<InformeVentasDTO> GetInformeVentasAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top);
        Task<byte[]> GenerarInformeVentasPdfAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top);
        Task<GraficosInformeDTO> GetGraficosInformeAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top);
        Task<InformeStockCriticoDTO> GetInformeStockCriticoAsync(int umbral, string? tipo, int? categoriaId = null, int? marcaId = null);
        Task<byte[]> GenerarInformeStockCriticoPdfAsync(int umbral, string? tipo, int? categoriaId = null, int? marcaId = null);
        Task<GraficosInformeStockDTO> GetGraficosInformeStockAsync(int umbral, string? tipo, int? categoriaId = null, int? marcaId = null);
    }
}
