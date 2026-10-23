using Domain.Model;
using DTOs;

namespace Application.Services
{
    public interface IReporteService
    {
        Task<InformeVentasDTO> GetInformeVentasAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top);
        Task<byte[]> GenerarInformeVentasPdfAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top);
        Task<GraficosInformeDTO> GetGraficosInformeAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top);

    }
}
