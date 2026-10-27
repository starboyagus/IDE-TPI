using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace Application.Services
{
    public static class InformeStockCriticoPdf
    {
        private static readonly CultureInfo Cultura = new("es-AR");

        public static byte[] Generar(InformeStockCriticoDTO informe)
        {
            return Document.Create(documento =>
            {
                documento.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(t => t.FontSize(9));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("Stock Crítico y Alerta de Reposición").FontSize(18).Bold();
                        col.Item().Text($"Umbral mínimo: {informe.UmbralMinimo} unidades   |   Filtro: {informe.TipoFiltroDescripcion}   |   Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        col.Item().PaddingTop(5).LineHorizontal(1);
                    });

                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Spacing(15);
                        SeccionResumen(col.Item(), informe.Resumen);
                        SeccionProductos(col.Item(), informe.Productos);

                        if (informe.PorCategoria.Any())
                        {
                            SeccionPorCategoria(col.Item(), informe.PorCategoria);
                        }

                        if (informe.PorMarca.Any())
                        {
                            SeccionPorMarca(col.Item(), informe.PorMarca);
                        }
                    });

                    page.Footer().Row(row =>
                    {
                        row.RelativeItem().Text("Reporte de inventario sobre productos activos. Ordenado por criticidad de inventario.").FontSize(8);
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

        private static void SeccionResumen(IContainer container, StockCriticoResumenDTO resumen)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Resumen de alertas").FontSize(13).Bold();
                col.Item().Row(row =>
                {
                    row.Spacing(10);
                    Tarjeta(row.RelativeItem(), "Total alertas", resumen.TotalAlertas.ToString(), Colors.Blue.Darken2);
                    Tarjeta(row.RelativeItem(), "Sin Stock (0)", resumen.CantidadSinStock.ToString(), Colors.Red.Darken2);
                    Tarjeta(row.RelativeItem(), "Stock Crítico", resumen.CantidadStockBajo.ToString(), Colors.Orange.Darken2);
                    Tarjeta(row.RelativeItem(), "En Pre-Venta", resumen.CantidadPreVenta.ToString(), Colors.Cyan.Darken2);
                });
            });
        }

        private static void SeccionProductos(IContainer container, List<ProductoStockCriticoDTO> datos)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Detalle de productos en alerta").FontSize(13).Bold();

                if (!datos.Any())
                {
                    col.Item().Text("No se detectaron productos bajo las condiciones especificadas.");
                    return;
                }

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(30);   // ID
                        c.RelativeColumn(3);    // Producto
                        c.RelativeColumn(2);    // Categoria
                        c.RelativeColumn(2);    // Marca
                        c.ConstantColumn(45);   // Stock
                        c.RelativeColumn(2);    // Criticidad
                        c.RelativeColumn(2);    // Precio
                    });

                    table.Header(h =>
                    {
                        h.Cell().Element(Encabezado).Text("ID").Bold();
                        h.Cell().Element(Encabezado).Text("Producto").Bold();
                        h.Cell().Element(Encabezado).Text("Categoría").Bold();
                        h.Cell().Element(Encabezado).Text("Marca").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Stock").Bold();
                        h.Cell().Element(Encabezado).Text("Criticidad").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Precio").Bold();
                    });

                    foreach (var d in datos)
                    {
                        table.Cell().Element(Celda).Text(d.Id.ToString());
                        table.Cell().Element(Celda).Text(d.Nombre);
                        table.Cell().Element(Celda).Text(d.Categoria);
                        table.Cell().Element(Celda).Text(d.Marca);

                        // Resaltar stock si es 0
                        if (d.Stock == 0)
                            table.Cell().Element(CeldaAlertaRoja).AlignRight().Text(d.Stock.ToString()).Bold();
                        else
                            table.Cell().Element(Celda).AlignRight().Text(d.Stock.ToString());

                        table.Cell().Element(Celda).Text(d.Criticidad);
                        table.Cell().Element(Celda).AlignRight().Text(Moneda(d.Precio));
                    }
                });
            });
        }

        private static void SeccionPorCategoria(IContainer container, List<StockPorCategoriaDTO> datos)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Productos en alerta por categoría").FontSize(13).Bold();

                col.Item().Image(GraficosReporte.StockPorCategoria(datos));

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn(3);
                        c.RelativeColumn();
                    });

                    table.Header(h =>
                    {
                        h.Cell().Element(Encabezado).Text("Categoría").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Productos en alerta").Bold();
                    });

                    foreach (var d in datos)
                    {
                        table.Cell().Element(Celda).Text(d.Categoria);
                        table.Cell().Element(Celda).AlignRight().Text(d.CantidadProductos.ToString());
                    }
                });
            });
        }

        private static void SeccionPorMarca(IContainer container, List<StockPorMarcaDTO> datos)
        {
            container.Column(col =>
            {
                col.Spacing(8);
                col.Item().Text("Productos en alerta por marca").FontSize(13).Bold();

                col.Item().Image(GraficosReporte.StockPorMarca(datos));

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn(3);
                        c.RelativeColumn();
                    });

                    table.Header(h =>
                    {
                        h.Cell().Element(Encabezado).Text("Marca").Bold();
                        h.Cell().Element(Encabezado).AlignRight().Text("Productos en alerta").Bold();
                    });

                    foreach (var d in datos)
                    {
                        table.Cell().Element(Celda).Text(d.Marca);
                        table.Cell().Element(Celda).AlignRight().Text(d.CantidadProductos.ToString());
                    }
                });
            });
        }

        private static void Tarjeta(IContainer container, string titulo, string valor, string colorHex)
        {
            container.Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(c =>
            {
                c.Item().Text(titulo).FontSize(9).FontColor(Colors.Grey.Darken2);
                c.Item().Text(valor).FontSize(16).Bold().FontColor(colorHex);
            });
        }

        private static IContainer Encabezado(IContainer container) =>
            container.Background(Colors.Grey.Lighten3).Padding(4);

        private static IContainer Celda(IContainer container) =>
            container.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4);

        private static IContainer CeldaAlertaRoja(IContainer container) =>
            container.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Background(Colors.Red.Lighten5).Padding(4);

        private static string Moneda(decimal valor) => valor.ToString("C2", Cultura);
    }
}
