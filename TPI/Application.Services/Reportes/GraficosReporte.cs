using Domain.Model;
using DTOs;
using ScottPlot;

namespace Application.Services
{
    public static class GraficosReporte
    {
        // Paletas de colores vibrantes y modernas para evitar gráficos monocromáticos/grises
        private static readonly Color[] PaletaVentas = new[]
        {
            Color.FromHex("#2563eb"), // Azul eléctrico
            Color.FromHex("#3b82f6"), // Azul cielo
            Color.FromHex("#06b6d4"), // Cyan
            Color.FromHex("#10b981"), // Esmeralda
            Color.FromHex("#8b5cf6"), // Violeta
            Color.FromHex("#f59e0b"), // Ámbar dorado
            Color.FromHex("#ec4899"), // Fucsia/Rosa
            Color.FromHex("#6366f1"), // Índigo
            Color.FromHex("#14b8a6"), // Turquesa
            Color.FromHex("#f97316"), // Naranja
        };

        private static readonly Color[] PaletaTop = new[]
        {
            Color.FromHex("#4f46e5"), // Índigo profundo
            Color.FromHex("#7c3aed"), // Púrpura real
            Color.FromHex("#2563eb"), // Azul cobalto
            Color.FromHex("#0891b2"), // Cyan oceánico
            Color.FromHex("#059669"), // Verde selva
            Color.FromHex("#d97706"), // Ámbar intenso
            Color.FromHex("#e11d48"), // Carmesí
            Color.FromHex("#db2777"), // Rosa magenta
            Color.FromHex("#0d9488"), // Teal
            Color.FromHex("#ea580c"), // Mandarina
        };

        private static readonly Color[] PaletaMarcas = new[]
        {
            Color.FromHex("#10b981"), // Esmeralda
            Color.FromHex("#6366f1"), // Índigo
            Color.FromHex("#f59e0b"), // Ámbar
            Color.FromHex("#06b6d4"), // Cyan
            Color.FromHex("#ec4899"), // Rosa
            Color.FromHex("#8b5cf6"), // Violeta
            Color.FromHex("#3b82f6"), // Azul
            Color.FromHex("#f97316"), // Naranja
        };

        private static void AplicarEstiloBase(Plot plot)
        {
            plot.FigureBackground.Color = Color.FromHex("#ffffff");
            plot.DataBackground.Color = Color.FromHex("#f8fafc");
            plot.Grid.MajorLineColor = Color.FromHex("#e2e8f0");
        }

        public static byte[] VentasPorMes(List<VentasPorMesDTO> datos)
        {
            var plot = new Plot();
            AplicarEstiloBase(plot);

            var barras = datos.Select((d, i) => new Bar
            {
                Position = i,
                Value = (double)d.TotalFacturado,
                FillColor = PaletaVentas[i % PaletaVentas.Length],
                LineWidth = 1,
                LineColor = Color.FromHex("#ffffff")
            }).ToArray();
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
            AplicarEstiloBase(plot);

            var barras = datos.Select((d, i) => new Bar
            {
                Position = datos.Count - 1 - i,
                Value = d.UnidadesVendidas,
                FillColor = PaletaTop[i % PaletaTop.Length],
                LineWidth = 1,
                LineColor = Color.FromHex("#ffffff")
            }).ToArray();
            var barPlot = plot.Add.Bars(barras);
            barPlot.Horizontal = true;

            var ticks = datos.Select((d, i) => new Tick(datos.Count - 1 - i, d.Producto)).ToArray();
            plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(left: 0);

            plot.Title("Productos más vendidos (unidades)");

            return plot.GetImageBytes(900, Math.Max(400, 120 + 40 * datos.Count), ImageFormat.Png);
        }

        public static byte[] FacturacionPorMarca(List<FacturacionMarcaDTO> datos)
        {
            var plot = new Plot();
            AplicarEstiloBase(plot);

            var barras = datos.Select((d, i) => new Bar
            {
                Position = i,
                Value = (double)d.Facturacion,
                FillColor = PaletaMarcas[i % PaletaMarcas.Length],
                LineWidth = 1,
                LineColor = Color.FromHex("#ffffff")
            }).ToArray();
            plot.Add.Bars(barras);

            var ticks = datos.Select((d, i) => new Tick(i, d.Marca)).ToArray();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(bottom: 0);

            plot.Title("Facturación por marca");
            plot.YLabel("Facturación ($)");

            return plot.GetImageBytes(900, 400, ImageFormat.Png);
        }

        public static byte[] StockPorCategoria(List<StockPorCategoriaDTO> datos)
        {
            var plot = new Plot();
            AplicarEstiloBase(plot);

            var barras = datos.Select((d, i) => new Bar
            {
                Position = i,
                Value = d.CantidadProductos,
                FillColor = PaletaVentas[i % PaletaVentas.Length],
                LineWidth = 1,
                LineColor = Color.FromHex("#ffffff")
            }).ToArray();
            plot.Add.Bars(barras);

            var ticks = datos.Select((d, i) => new Tick(i, d.Categoria)).ToArray();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(bottom: 0);

            plot.Title("Productos en alerta por categoría");
            plot.YLabel("Cantidad de productos");

            return plot.GetImageBytes(900, 400, ImageFormat.Png);
        }

        public static byte[] StockPorMarca(List<StockPorMarcaDTO> datos)
        {
            var plot = new Plot();
            AplicarEstiloBase(plot);

            var barras = datos.Select((d, i) => new Bar
            {
                Position = i,
                Value = d.CantidadProductos,
                FillColor = PaletaMarcas[i % PaletaMarcas.Length],
                LineWidth = 1,
                LineColor = Color.FromHex("#ffffff")
            }).ToArray();
            plot.Add.Bars(barras);

            var ticks = datos.Select((d, i) => new Tick(i, d.Marca)).ToArray();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(bottom: 0);

            plot.Title("Productos en alerta por marca");
            plot.YLabel("Cantidad de productos");

            return plot.GetImageBytes(900, 400, ImageFormat.Png);
        }

        public static byte[] StockPorCriticidad(StockCriticoResumenDTO resumen)
        {
            var plot = new Plot();
            AplicarEstiloBase(plot);

            var barras = new Bar[]
            {
                new() { Position = 0, Value = resumen.CantidadSinStock, FillColor = Color.FromHex("#dc3545"), LineWidth = 1, LineColor = Color.FromHex("#ffffff") },
                new() { Position = 1, Value = resumen.CantidadStockBajo, FillColor = Color.FromHex("#f59e0b"), LineWidth = 1, LineColor = Color.FromHex("#ffffff") },
                new() { Position = 2, Value = resumen.CantidadPreVenta, FillColor = Color.FromHex("#06b6d4"), LineWidth = 1, LineColor = Color.FromHex("#ffffff") }
            };
            plot.Add.Bars(barras);

            var ticks = new Tick[]
            {
                new(0, "Sin Stock (0)"),
                new(1, "Bajo Umbral"),
                new(2, "Pre-Venta")
            };
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            plot.Axes.Margins(bottom: 0);

            plot.Title("Distribución de alertas por criticidad");
            plot.YLabel("Cantidad de productos");

            return plot.GetImageBytes(900, 400, ImageFormat.Png);
        }
    }
}
