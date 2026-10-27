using System.Security.Claims;
using Application.Services;
using Domain.Model;
using DTOs;

namespace WebAPI
{
    public static class OrdenEndpoints
    {
        public static void MapOrdenEndpoints(this WebApplication app)
        {
            app.MapGet("/ordenes/{id}", async (int id, ClaimsPrincipal user, IOrdenService ordenService) =>
            {
                OrdenDTO? dto = await ordenService.GetAsync(id);

                if (dto == null || (!user.EsAdmin() && dto.UsuarioId != user.GetUsuarioId()))
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

            app.MapGet("/ordenes", async (ClaimsPrincipal user, IOrdenService ordenService) =>
            {
                var dtos = user.EsAdmin()
                    ? await ordenService.GetAllAsync()
                    : await ordenService.GetByUsuarioAsync(user.GetUsuarioId());

                return Results.Ok(dtos);
            })
            .WithName("GetAllOrdenes")
            .Produces<List<OrdenDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("OrdenesLeer");

            app.MapPost("/ordenes", async (OrdenDTO dto, ClaimsPrincipal user, IOrdenService ordenService) =>
            {
                try
                {
                    if (!user.EsAdmin())
                    {
                        dto.UsuarioId = user.GetUsuarioId();
                    }

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
                try
                {
                    var deleted = await ordenService.DeleteAsync(id);

                    if (!deleted)
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
            .WithName("DeleteOrden")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("OrdenesEliminar");
        }

        private static int GetUsuarioId(this ClaimsPrincipal user)
        {
            var valor = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub");
            return int.Parse(valor!);
        }

        private static bool EsAdmin(this ClaimsPrincipal user) =>
            user.IsInRole(RolUsuario.Admin.ToString());
    }
}
