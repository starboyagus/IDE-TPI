using Application.Services;
using Domain.Model;
using DTOs;

namespace WebAPI
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this WebApplication app)
        {
            // === Reportes de Ventas ===
            app.MapGet("/reportes/ventas", async (DateTime desde, DateTime hasta, EstadoOrden? estado, int? top, IReporteService reporteService) =>
            {
                try
                {
                    var informe = await reporteService.GetInformeVentasAsync(desde, hasta, estado, top ?? 10);
                    return Results.Ok(informe);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetInformeVentas")
            .Produces<InformeVentasDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");

            app.MapGet("/reportes/ventas/pdf", async (DateTime desde, DateTime hasta, EstadoOrden? estado, int? top, IReporteService reporteService) =>
            {
                try
                {
                    var pdf = await reporteService.GenerarInformeVentasPdfAsync(desde, hasta, estado, top ?? 10);
                    return Results.File(pdf, "application/pdf", $"informe-ventas-{desde:yyyyMMdd}-{hasta:yyyyMMdd}.pdf");
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetInformeVentasPdf")
            .Produces(StatusCodes.Status200OK, contentType: "application/pdf")
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");

            app.MapGet("/reportes/ventas/graficos", async (DateTime desde, DateTime hasta, EstadoOrden? estado, int? top, IReporteService reporteService) =>
            {
                try
                {
                    var graficos = await reporteService.GetGraficosInformeAsync(desde, hasta, estado, top ?? 10);
                    return Results.Ok(graficos);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetGraficosInformeVentas")
            .Produces<GraficosInformeDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");

            // === Reportes de Stock Crítico y Alerta de Reposición ===
            app.MapGet("/reportes/stock-critico", async (int? umbral, string? tipo, int? categoriaId, int? marcaId, IReporteService reporteService) =>
            {
                try
                {
                    var informe = await reporteService.GetInformeStockCriticoAsync(umbral ?? 5, tipo, categoriaId, marcaId);
                    return Results.Ok(informe);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetInformeStockCritico")
            .Produces<InformeStockCriticoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");

            app.MapGet("/reportes/stock-critico/pdf", async (int? umbral, string? tipo, int? categoriaId, int? marcaId, IReporteService reporteService) =>
            {
                try
                {
                    var pdf = await reporteService.GenerarInformeStockCriticoPdfAsync(umbral ?? 5, tipo, categoriaId, marcaId);
                    return Results.File(pdf, "application/pdf", $"informe-stock-critico-{DateTime.Now:yyyyMMddHHmmss}.pdf");
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetInformeStockCriticoPdf")
            .Produces(StatusCodes.Status200OK, contentType: "application/pdf")
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");

            app.MapGet("/reportes/stock-critico/graficos", async (int? umbral, string? tipo, int? categoriaId, int? marcaId, IReporteService reporteService) =>
            {
                try
                {
                    var graficos = await reporteService.GetGraficosInformeStockAsync(umbral ?? 5, tipo, categoriaId, marcaId);
                    return Results.Ok(graficos);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetGraficosInformeStockCritico")
            .Produces<GraficosInformeStockDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");
        }
    }
}
