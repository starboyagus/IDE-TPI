using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ProductoEndpoints
    {
        public static void MapProductoEndpoints(this WebApplication app)
        {
            app.MapGet("/productos/{id}", async (int id, IProductoService productoService) =>
            {
                ProductoDTO? dto = await productoService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetProducto")
            .Produces<ProductoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/productos", async (IProductoService productoService) =>
            {
                var dtos = await productoService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllProductos")
            .Produces<List<ProductoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/productos", async (ProductoDTO dto, IProductoService productoService) =>
            {
                try
                {
                    ProductoDTO productoDTO = await productoService.AddAsync(dto);

                    return Results.Created($"/productos/{productoDTO.Id}", productoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddProducto")
            .Produces<ProductoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/productos", async (ProductoDTO dto, IProductoService productoService) =>
            {
                try
                {
                    var found = await productoService.UpdateAsync(dto);

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
            .WithName("UpdateProducto")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/productos/{id}", async (int id, IProductoService productoService) =>
            {
                var deleted = await productoService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteProducto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
