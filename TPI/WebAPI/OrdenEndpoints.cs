using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class OrdenEndpoints
    {
        public static void MapOrdenEndpoints(this WebApplication app)
        {
            app.MapGet("/ordenes/{id}", async (int id, IOrdenService ordenService) =>
            {
                OrdenDTO? dto = await ordenService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetOrden")
            .Produces<OrdenDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("OrdenesLeer");

            app.MapGet("/ordenes", async (IOrdenService ordenService) =>
            {
                var dtos = await ordenService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllOrdenes")
            .Produces<List<OrdenDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("OrdenesLeer");

            app.MapPost("/ordenes", async (OrdenDTO dto, IOrdenService ordenService) =>
            {
                try
                {
                    OrdenDTO ordenDTO = await ordenService.AddAsync(dto);       
                    return Results.Created($"/ordenes/{ordenDTO.Id}", ordenDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddOrden")
            .Produces<OrdenDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("OrdenesAgregar");

            app.MapPut("/ordenes", async (OrdenDTO dto, IOrdenService ordenService) =>
            {
                try
                {
                    var found = await ordenService.UpdateAsync(dto);
                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateOrden")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("OrdenesActualizar");

            app.MapDelete("/ordenes/{id}", async (int id, IOrdenService ordenService) =>
            {
                var deleted = await ordenService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteOrden")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("OrdenesEliminar");
        }
    }
}
