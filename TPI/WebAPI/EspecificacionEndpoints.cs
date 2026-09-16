using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class EspecificacionEndpoints
    {
        public static void MapEspecificacionEndpoints(this WebApplication app)
        {
            app.MapGet("/especificaciones/{id}", async (int id, IEspecificacionService especificacionService) =>
            {
                EspecificacionDTO? dto = await especificacionService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetEspecificacion")
            .Produces<EspecificacionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("EspecificacionesLeer");

            app.MapGet("/especificaciones", async (IEspecificacionService especificacionService) =>
            {
                var dtos = await especificacionService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllEspecificacion")
            .Produces<List<EspecificacionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("EspecificacionesLeer");

            app.MapPost("/especificaciones", async (EspecificacionDTO dto, IEspecificacionService especificacionService) =>
            {
                try
                {
                    EspecificacionDTO especificacionDTO = await especificacionService.AddAsync(dto);

                    return Results.Created($"/especificaciones/{especificacionDTO.Id}", especificacionDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEspecificacion")
            .Produces<EspecificacionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("EspecificacionesAgregar");

            app.MapPut("/especificaciones", async (EspecificacionDTO dto, IEspecificacionService especificacionService) =>
            {
                try
                {
                    var found = await especificacionService.UpdateAsync(dto);

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
            .WithName("UpdateEspecificacion")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("EspecificacionesActualizar");

            app.MapDelete("/especificaciones/{id}", async (int id, IEspecificacionService especificacionService) =>
            {
                var deleted = await especificacionService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteEspecificacion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("EspecificacionesEliminar");
        }
    }
}
