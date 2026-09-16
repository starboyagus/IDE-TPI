using System.Text;
using Application.Services;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework Context
builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    Description = "JWT Authorization header using the Bearer scheme."
});
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddHttpLogging(o => { });

// Add Dependency Injection
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IEspecificacionRepository, EspecificacionRepository>();
builder.Services.AddScoped<IEspecificacionService, EspecificacionService>();

builder.Services.AddScoped<IJwtService, JwtService>();

// Agregar autenticacion JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
            ClockSkew = TimeSpan.Zero
        };
    });

// Add Authorization Policies
builder.Services.AddAuthorization(options =>
{
    // Políticas para Usuarios
    options.AddPolicy("UsuariosLeer", policy => policy.RequireClaim("permission", "usuarios.leer"));
    options.AddPolicy("UsuariosAgregar", policy => policy.RequireClaim("permission", "usuarios.agregar"));
    options.AddPolicy("UsuariosActualizar", policy => policy.RequireClaim("permission", "usuarios.actualizar"));
    options.AddPolicy("UsuariosEliminar", policy => policy.RequireClaim("permission", "usuarios.eliminar"));

    // Políticas para Productos
    options.AddPolicy("ProductosLeer", policy => policy.RequireClaim("permission", "productos.leer"));
    options.AddPolicy("ProductosAgregar", policy => policy.RequireClaim("permission", "productos.agregar"));
    options.AddPolicy("ProductosActualizar", policy => policy.RequireClaim("permission", "productos.actualizar"));
    options.AddPolicy("ProductosEliminar", policy => policy.RequireClaim("permission", "productos.eliminar"));

    // Políticas para Categorías
    options.AddPolicy("CategoriasLeer", policy => policy.RequireClaim("permission", "categorias.leer"));
    options.AddPolicy("CategoriasAgregar", policy => policy.RequireClaim("permission", "categorias.agregar"));
    options.AddPolicy("CategoriasActualizar", policy => policy.RequireClaim("permission", "categorias.actualizar"));
    options.AddPolicy("CategoriasEliminar", policy => policy.RequireClaim("permission", "categorias.eliminar"));

    // Políticas para Marcas
    options.AddPolicy("MarcasLeer", policy => policy.RequireClaim("permission", "marcas.leer"));
    options.AddPolicy("MarcasAgregar", policy => policy.RequireClaim("permission", "marcas.agregar"));
    options.AddPolicy("MarcasActualizar", policy => policy.RequireClaim("permission", "marcas.actualizar"));
    options.AddPolicy("MarcasEliminar", policy => policy.RequireClaim("permission", "marcas.eliminar"));

    // Políticas para Especificaciones
    options.AddPolicy("EspecificacionesLeer", policy => policy.RequireClaim("permission", "especificaciones.leer"));
    options.AddPolicy("EspecificacionesAgregar", policy => policy.RequireClaim("permission", "especificaciones.agregar"));
    options.AddPolicy("EspecificacionesActualizar", policy => policy.RequireClaim("permission", "especificaciones.actualizar"));
    options.AddPolicy("EspecificacionesEliminar", policy => policy.RequireClaim("permission", "especificaciones.eliminar"));

    // Fallback: Requerir autenticación para endpoints no especificados
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

// Verificar conexión y crear la base de datos si no existe
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TPIContext>();

    try
    {
        context.Database.EnsureCreated();
        Console.WriteLine("✅ Conexión exitosa a la base de datos.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error al conectar a la base de datos: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapUsuarioEndpoints();
app.MapProductoEndpoints();
app.MapCategoriaEndpoints();
app.MapMarcaEndpoints();
app.MapEspecificacionEndpoints();
app.Run();