using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class MarcaEndpoints
    {
        public static void MapMarcaEndpoints(this WebApplication app)
        {
            app.MapGet("/marcas/{id}", async (int id, IMarcaService marcaService) =>
            {
                MarcaDTO? dto = await marcaService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetMarca")
            .Produces<MarcaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("MarcasLeer");

            app.MapGet("/marcas", async (IMarcaService marcaService) =>
            {
                var dtos = await marcaService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllMarcas")
            .Produces<List<MarcaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("MarcasLeer");

            app.MapPost("/marcas", async (MarcaDTO dto, IMarcaService marcaService) =>
            {
                try
                {
                    MarcaDTO marcaDTO = await marcaService.AddAsync(dto);

                    return Results.Created($"/marcas/{marcaDTO.Id}", marcaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMarca")
            .Produces<MarcaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("MarcasAgregar");

            app.MapPut("/marcas", async (MarcaDTO dto, IMarcaService marcaService) =>
            {
                try
                {
                    var found = await marcaService.UpdateAsync(dto);

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
            .WithName("UpdateMarca")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("MarcasActualizar");

            app.MapDelete("/marcas/{id}", async (int id, IMarcaService marcaService) =>
            {
                var deleted = await marcaService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteMarca")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("MarcasEliminar"); 
        }
    }
}
