using Application.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework Context
builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependency Injection
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// Verificar conexión y aplicar migraciones pendientes
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TPIContext>();

    try
    {
        var pendingMigrations = context.Database.GetPendingMigrations().ToList();

        if (pendingMigrations.Any())
        {
            Console.WriteLine($"⏳ Aplicando {pendingMigrations.Count} migración(es) pendiente(s)...");
            context.Database.Migrate();
            Console.WriteLine("✅ Migraciones aplicadas y base de datos actualizada.");
        }
        else
        {
            Console.WriteLine("✅ Conexión exitosa. Base de datos ya está actualizada.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error al conectar o migrar: {ex.Message}");
    }


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    // Map endpoints
    app.MapClienteEndpoints();
    app.MapProductoEndpoints();
    app.Run();
}