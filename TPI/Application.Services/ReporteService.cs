using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository reporteRepository;

        public ReporteService(IReporteRepository reporteRepository)
        {
            this.reporteRepository = reporteRepository;
        }

        public async Task<InformeVentasDTO> GetInformeVentasAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            var criteria = new ReporteCriteria(desde, hasta, estado, top);

            var resumen = await reporteRepository.GetResumenVentasAsync(criteria);
            var porMes = await reporteRepository.GetVentasPorMesAsync(criteria);
            var topProductos = await reporteRepository.GetTopProductosAsync(criteria);
            var porMarca = await reporteRepository.GetFacturacionPorMarcaAsync(criteria);

            return new InformeVentasDTO
            {
                Desde = criteria.Desde,
                Hasta = criteria.Hasta,
                Estado = criteria.Estado,
                Top = criteria.Top,
                Resumen = new VentasResumenDTO
                {
                    CantidadOrdenes = resumen.CantidadOrdenes,
                    TotalFacturado = resumen.TotalFacturado,
                    TicketPromedio = resumen.TicketPromedio
                },
                VentasPorMes = porMes.Select(f => new VentasPorMesDTO
                {
                    Anio = f.Anio,
                    Mes = f.Mes,
                    CantidadOrdenes = f.CantidadOrdenes,
                    TotalFacturado = f.TotalFacturado,
                    TicketPromedio = f.TicketPromedio
                }).ToList(),
                TopProductos = topProductos.Select(f => new ProductoVendidoDTO
                {
                    ProductoId = f.ProductoId,
                    Producto = f.Producto,
                    Categoria = f.Categoria,
                    Marca = f.Marca,
                    UnidadesVendidas = f.UnidadesVendidas,
                    Facturacion = f.Facturacion
                }).ToList(),
                FacturacionPorMarca = porMarca.Select(f => new FacturacionMarcaDTO
                {
                    MarcaId = f.MarcaId,
                    Marca = f.Marca,
                    UnidadesVendidas = f.UnidadesVendidas,
                    Facturacion = f.Facturacion,
                    Porcentaje = f.Porcentaje
                }).ToList()
            };
        }

        public async Task<byte[]> GenerarInformeVentasPdfAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            var informe = await GetInformeVentasAsync(desde, hasta, estado, top);
            return InformeVentasPdf.Generar(informe);
        }

        public async Task<GraficosInformeDTO> GetGraficosInformeAsync(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            var informe = await GetInformeVentasAsync(desde, hasta, estado, top);

            return new GraficosInformeDTO
            {
                VentasPorMes = informe.VentasPorMes.Any()
                    ? Convert.ToBase64String(GraficosReporte.VentasPorMes(informe.VentasPorMes))
                    : null,
                TopProductos = informe.TopProductos.Any()
                    ? Convert.ToBase64String(GraficosReporte.TopProductos(informe.TopProductos))
                    : null,
                FacturacionPorMarca = informe.FacturacionPorMarca.Any()
                    ? Convert.ToBase64String(GraficosReporte.FacturacionPorMarca(informe.FacturacionPorMarca))
                    : null
            };
        }

    }
}
