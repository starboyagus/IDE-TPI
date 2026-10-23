using Domain.Model;
using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace Application.Services
{
    public static class InformeVentasPdf
    {
        private static readonly CultureInfo Cultura = new("es-AR");

        public static byte[] Generar(InformeVentasDTO informe)
        {
            return Document.Create(documento =>
            {
                documento.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(t => t.FontSize(10));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("Informe de ventas").FontSize(18).Bold();
                        col.Item().Text($"Período: {informe.Desde:dd/MM/yyyy} al {informe.Hasta:dd/MM/yyyy}   |   Estado: {informe.EstadoDescripcion}");
                        col.Item().PaddingTop(5).LineHorizontal(1);
                    });

                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Spacing(20);
                        SeccionResumen(col.Item(), informe.Resumen);
                        SeccionVentasPorMes(col.Item(), informe.VentasPorMes);
                        SeccionTopProductos(col.Item(), informe.TopProductos);
                        SeccionPorMarca(col.Item(), informe.FacturacionPorMarca);
                    });

                    page.Footer().Row(row =>
                    {
                        row.RelativeItem().Text("Excluye órdenes eliminadas. Sin filtro de estado, excluye también las canceladas.").FontSize(8);
                        row.ConstantItem(60).AlignRight().Text(t =>
                        {
                            t.CurrentPageNumber();
                            t.Span(" / ");
                            t.TotalPages();
                        });
                    });
                });
            }).GeneratePdf();
        }

        private static void SeccionResumen(IContainer container, VentasResumenDTO resumen)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Resumen").FontSize(14).Bold();
                col.Item().Row(row =>
                {
                    row.Spacing(10);
                    Tarjeta(row.RelativeItem(), "Órdenes", resumen.CantidadOrdenes.ToString());
                    Tarjeta(row.RelativeItem(), "Total facturado", Moneda(resumen.TotalFacturado));
                    Tarjeta(row.RelativeItem(), "Ticket promedio", Moneda(resumen.TicketPromedio));
                });
            });
        }

        private static void SeccionVentasPorMes(IContainer container, List<VentasPorMesDTO> datos)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Ventas por mes").FontSize(14).Bold();

                if (!datos.Any())
                {
                    col.Item().Text("Sin ventas en el período.");
                    return;
                }

                col.Item().Image(GraficosReporte.VentasPorMes(datos));
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn();
                        c.RelativeColumn();
                        c.RelativeColumn();
                        c.RelativeColumn();
                    });

                    table.Header(h =>
                    {
                        h.Cell().Element(Encabezado).Text("Mes").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Órdenes").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Facturación").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Ticket promedio").Bold();
                    });

                    foreach (var d in datos)
                    {
                        table.Cell().Element(Celda).Text(d.Periodo);
                        table.Cell().Element(Celda).AlignRight().Text(d.CantidadOrdenes.ToString());
                        table.Cell().Element(Celda).AlignRight().Text(Moneda(d.TotalFacturado));
                        table.Cell().Element(Celda).AlignRight().Text(Moneda(d.TicketPromedio));
                    }
                });
            });
        }

        private static void SeccionTopProductos(IContainer container, List<ProductoVendidoDTO> datos)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Productos más vendidos").FontSize(14).Bold();

                if (!datos.Any())
                {
                    col.Item().Text("Sin ventas en el período.");
                    return;
                }

                col.Item().Image(GraficosReporte.TopProductos(datos));
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn(3);
                        c.RelativeColumn(2);
                        c.RelativeColumn(2);
                        c.RelativeColumn();
                        c.RelativeColumn(2);
                    });

                    table.Header(h =>
                    {
                        h.Cell().Element(Encabezado).Text("Producto").Bold();
                        h.Cell().Element(Encabezado).Text("Categoría").Bold();
                        h.Cell().Element(Encabezado).Text("Marca").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Unidades").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Facturación").Bold();
                    });

                    foreach (var d in datos)
                    {
                        table.Cell().Element(Celda).Text(d.Producto);
                        table.Cell().Element(Celda).Text(d.Categoria);
                        table.Cell().Element(Celda).Text(d.Marca);
                        table.Cell().Element(Celda).AlignRight().Text(d.UnidadesVendidas.ToString());
                        table.Cell().Element(Celda).AlignRight().Text(Moneda(d.Facturacion));
                    }
                });
            });
        }

        private static void SeccionPorMarca(IContainer container, List<FacturacionMarcaDTO> datos)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Facturación por marca").FontSize(14).Bold();

                if (!datos.Any())
                {
                    col.Item().Text("Sin ventas en el período.");
                    return;
                }

                col.Item().Image(GraficosReporte.FacturacionPorMarca(datos));
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn(3);
                        c.RelativeColumn();
                        c.RelativeColumn(2);
                        c.RelativeColumn();
                    });

                    table.Header(h =>
                    {
                        h.Cell().Element(Encabezado).Text("Marca").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Unidades").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Facturación").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("%").Bold();
                    });

                    foreach (var d in datos)
                    {
                        table.Cell().Element(Celda).Text(d.Marca);
                        table.Cell().Element(Celda).AlignRight().Text(d.UnidadesVendidas.ToString());
                        table.Cell().Element(Celda).AlignRight().Text(Moneda(d.Facturacion));
                        table.Cell().Element(Celda).AlignRight().Text($"{d.Porcentaje:N2} %");
                    }
                });
            });
        }

        private static void Tarjeta(IContainer container, string titulo, string valor)
        {
            container.Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Column(c =>
            {
                c.Item().Text(titulo).FontColor(Colors.Grey.Darken1);
                c.Item().Text(valor).FontSize(16).Bold();
            });
        }

        private static IContainer Encabezado(IContainer container) =>
            container.Background(Colors.Red.Lighten3).Padding(4);

        private static IContainer Celda(IContainer container) =>
            container.BorderBottom(1).BorderColor(Colors.Blue.Lighten2).Padding(4);

        private static string Moneda(decimal valor) => valor.ToString("C2", Cultura);
    }
}
