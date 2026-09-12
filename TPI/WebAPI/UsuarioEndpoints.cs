using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/usuarios/{id}", async (int id, IUsuarioService usuarioService) =>
            {
                UsuarioDTO? dto = await usuarioService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("UsuariosLeer");

            app.MapGet("/usuarios", async (IUsuarioService usuarioService) =>
            {
                var dtos = await usuarioService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("UsuariosLeer");

            app.MapPost("/usuarios", async (UsuarioDTO dto, IUsuarioService usuarioService) =>
            {
                try
                {
                    UsuarioDTO usuarioDTO = await usuarioService.AddAsync(dto);

                    return Results.Created($"/usuarios/{usuarioDTO.Id}", usuarioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("UsuariosAgregar");

            app.MapPut("/usuarios", async (UsuarioDTO dto, IUsuarioService usuarioService) =>
            {
                try
                {
                    var found = await usuarioService.UpdateAsync(dto);

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
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("UsuariosActualizar");

            app.MapDelete("/usuarios/{id}", async (int id, IUsuarioService usuarioService) =>
            {
                var deleted = await usuarioService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("UsuariosEliminar");

            app.MapPost("/usuarios/login", async (LoginDTO dto, IUsuarioService usuarioService, IJwtService jwtService) =>
            {
                UsuarioDTO? usuario = await usuarioService.LoginAsync(dto);

                if (usuario == null)
                {
                    return Results.Unauthorized();
                }

                string token = jwtService.GenerateToken(usuario);

                return Results.Ok(new AuthResponseDTO
                {
                    Token = token,
                    Usuario = new UsuarioAuthDTO
                    {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        Email = usuario.Email,
                        Telefono = usuario.Telefono,
                        Rol = usuario.Rol
                    },
                    Expiration = DateTime.UtcNow.AddHours(1) // Set token expiration time
                });
            })
                .WithName("LoginUsuario")
                .Produces<AuthResponseDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .WithOpenApi()
                .AllowAnonymous();

            app.MapGet("/usuarios/criteria", async (string texto, IUsuarioService usuarioService) =>
            {
                try
                {
                    var criteria = new UsuarioCriteriaDTO { Texto = texto };
                    var usuarios = await usuarioService.GetByCriteriaAsync(criteria);
                    return Results.Ok(usuarios);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetUsuariosByCriteria")
            .WithOpenApi()
            .RequireAuthorization("UsuariosLeer");
        }
    }
}
