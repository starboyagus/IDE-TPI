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

        public async Task<InformeStockCriticoDTO> GetInformeStockCriticoAsync(int umbral, string? tipo, int? categoriaId = null, int? marcaId = null)
        {
            if (umbral < 0)
                throw new ArgumentException("El umbral no puede ser negativo.", nameof(umbral));

            var resumen = await reporteRepository.GetResumenStockCriticoAsync(umbral);
            var productos = await reporteRepository.GetProductosStockCriticoAsync(umbral, tipo, categoriaId, marcaId);
            var porCategoria = await reporteRepository.GetStockCriticoPorCategoriaAsync(umbral);
            var porMarca = await reporteRepository.GetStockCriticoPorMarcaAsync(umbral);

            return new InformeStockCriticoDTO
            {
                UmbralMinimo = umbral,
                TipoFiltro = tipo,
                Resumen = new StockCriticoResumenDTO
                {
                    TotalAlertas = resumen.TotalAlertas,
                    CantidadSinStock = resumen.CantidadSinStock,
                    CantidadStockBajo = resumen.CantidadStockBajo,
                    CantidadPreVenta = resumen.CantidadPreVenta
                },
                Productos = productos.Select(p => new ProductoStockCriticoDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Categoria = p.Categoria,
                    Marca = p.Marca,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    EsPreVenta = p.EsPreVenta,
                    Criticidad = p.Criticidad,
                    PrioridadCriticidad = p.PrioridadCriticidad
                }).ToList(),
                PorCategoria = porCategoria.Select(c => new StockPorCategoriaDTO
                {
                    CategoriaId = c.CategoriaId,
                    Categoria = c.Categoria,
                    CantidadProductos = c.CantidadProductos
                }).ToList(),
                PorMarca = porMarca.Select(m => new StockPorMarcaDTO
                {
                    MarcaId = m.MarcaId,
                    Marca = m.Marca,
                    CantidadProductos = m.CantidadProductos
                }).ToList()
            };
        }

        public async Task<byte[]> GenerarInformeStockCriticoPdfAsync(int umbral, string? tipo, int? categoriaId = null, int? marcaId = null)
        {
            var informe = await GetInformeStockCriticoAsync(umbral, tipo, categoriaId, marcaId);
            return InformeStockCriticoPdf.Generar(informe);
        }

        public async Task<GraficosInformeStockDTO> GetGraficosInformeStockAsync(int umbral, string? tipo, int? categoriaId = null, int? marcaId = null)
        {
            var informe = await GetInformeStockCriticoAsync(umbral, tipo, categoriaId, marcaId);

            return new GraficosInformeStockDTO
            {
                PorCategoria = informe.PorCategoria.Any()
                    ? Convert.ToBase64String(GraficosReporte.StockPorCategoria(informe.PorCategoria))
                    : null,
                PorMarca = informe.PorMarca.Any()
                    ? Convert.ToBase64String(GraficosReporte.StockPorMarca(informe.PorMarca))
                    : null,
                PorCriticidad = informe.Resumen.TotalAlertas > 0
                    ? Convert.ToBase64String(GraficosReporte.StockPorCriticidad(informe.Resumen))
                    : null
            };
        }
    }
}
