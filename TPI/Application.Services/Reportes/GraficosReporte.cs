using Domain.Model;
using DTOs;
using ScottPlot;

namespace Application.Services
{
    public static class GraficosReporte
    {
        public static byte[] VentasPorMes(List<VentasPorMesDTO> datos)
        {
            var plot = new Plot();

            var barras = datos.Select((d, i) => new Bar { Position = i, Value = (double)d.TotalFacturado }).ToArray();
            plot.Add.Bars(barras);

            var ticks = datos.Select((d, i) => new Tick(i, d.Periodo)).ToArray();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(bottom: 0);

            plot.Title("Facturación por mes");
            plot.YLabel("Facturación ($)");

            return plot.GetImageBytes(900, 400, ImageFormat.Png);
        }

        public static byte[] TopProductos(List<ProductoVendidoDTO> datos)
        {
            var plot = new Plot();

            var barras = datos.Select((d, i) => new Bar { Position = datos.Count - 1 - i, Value = d.UnidadesVendidas }).ToArray();
            var barPlot = plot.Add.Bars(barras);
            barPlot.Horizontal = true;

            var ticks = datos.Select((d, i) => new Tick(datos.Count - 1 - i, d.Producto)).ToArray();
            plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(left: 0);

            plot.Title("Productos más vendidos (unidades)");

            return plot.GetImageBytes(900, 120 + 40 * datos.Count, ImageFormat.Png);
        }

        public static byte[] FacturacionPorMarca(List<FacturacionMarcaDTO> datos)
        {
            var plot = new Plot();

            var barras = datos.Select((d, i) => new Bar { Position = i, Value = (double)d.Facturacion }).ToArray();
            plot.Add.Bars(barras);

            var ticks = datos.Select((d, i) => new Tick(i, d.Marca)).ToArray();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(bottom: 0);

            plot.Title("Facturación por marca");
            plot.YLabel("Facturación ($)");

            return plot.GetImageBytes(900, 400, ImageFormat.Png);
        }
    }
}
