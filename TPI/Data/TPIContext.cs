using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Especificacion> Especificaciones { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenItem> OrdenItems { get; set; }

        // El DbContext se crea una vez por request, así que la base NO se verifica acá:
        // de eso se encarga el EnsureCreated() del arranque en Program.cs.
        public TPIContext(DbContextOptions<TPIContext> options) : base(options)
        {
        }

        internal TPIContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                // Restricción única para Email
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasConversion<int>();

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasColumnType("bit");

                //Datos inical de prueba
                // HasData no pasa por el constructor, así que el salt y el hash se calculan acá.
                var saltSeed = Usuario.GenerateSalt();

                entity.HasData(
                    new { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan@gmail.com", Telefono = "3511234567", Salt = saltSeed, Contrasenia = Usuario.HashPassword("usuario123", saltSeed), Rol = RolUsuario.Admin, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Nombre = "Agus", Apellido = "Gol", Email = "agus@gmail.com", Telefono = "3511234567", Salt = saltSeed, Contrasenia = Usuario.HashPassword("usuario123", saltSeed), Rol = RolUsuario.Usuario, FechaAlta = DateTime.Now, EsActivo = true });
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Stock)
                    .IsRequired();

                entity.Property(e => e.EsPreVenta)
                .IsRequired()
                .HasColumnType("bit");

                entity.Property(e => e.CategoriaId)
                    .IsRequired();

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasColumnType("bit");

                // Datos iniciales de prueba
                entity.HasData(
                    new { Id = 1, Nombre = "AMD Ryzen 5 5600", Descripcion = "Procesador AM4 6C 12T", Precio = 1200.0m, Stock = 10, EsPreVenta = false, CategoriaId = 1, MarcaId = 2, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Nombre = "Mouse Logitech MX Master 3", Descripcion = "Mouse inalámbrico ergonómico", Precio = 89.9m, Stock = 25, EsPreVenta = false, CategoriaId = 5, MarcaId = 3, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 3, Nombre = "Corsair Vengeance 8gb DDR4", Descripcion = "Memoria RAM DDR4 8GB 3200MHz", Precio = 149.0m, Stock = 15, EsPreVenta = false, CategoriaId = 2, MarcaId = 4, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 4, Nombre = "NVIDIA RTX 5070", Descripcion = "Placa de video RTX5070 12GB VRAM", Precio = 349.0m, Stock = 8, EsPreVenta = false, CategoriaId = 3, MarcaId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 5, Nombre = "Auriculares Sony WH-1000XM4", Descripcion = "Auriculares con cancelación de ruido", Precio = 279.98m, Stock = 20, EsPreVenta = false, CategoriaId = 4, MarcaId = 5, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 6, Nombre = "Mouse ATK Dragonfly A9", Descripcion = "mouse inalámbrico ultraligero para gaming con diseño simétrico, ideal para agarres de tipo claw, palm y fingertip", Precio = 50.0m, Stock = 3, EsPreVenta = false, CategoriaId = 5, MarcaId = 6, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 7, Nombre = "NVIDIA RTX 2060", Descripcion = "Placa de video RTX2060 6GB VRAM", Precio = 150.0m, Stock = 50, EsPreVenta = false, CategoriaId = 3, MarcaId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 8, Nombre = "ROG Strix Scope RX Eva Edition", Descripcion = "Teclado Gamer", Precio = 350.0m, Stock = 10, EsPreVenta = true, CategoriaId = 6, MarcaId = 7, FechaAlta = DateTime.Now, EsActivo = true }
                );
            });
            modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany()
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
            .HasOne(p => p.Marca)
            .WithMany()
            .HasForeignKey(p => p.MarcaId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasColumnType("bit");

                // Datos iniciales de prueba
                entity.HasData(
                    new { Id = 1, Nombre = "CPU", Descripcion = "Unidad central de procesamiento", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Nombre = "RAM", Descripcion = "Memoria de acceso aleatorio", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 3, Nombre = "GPU", Descripcion = "Unidad de procesamiento de graficos", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 4, Nombre = "Auricular", Descripcion = "Periferico con parlantes stereo", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 5, Nombre = "Mouse", Descripcion = "Periferico con sensor optico y click mecanico", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 6, Nombre = "Teclado", Descripcion = "Periférico de entrada fundamental en informática que permite introducir texto, números, símbolos y comandos en una computadora, laptop, tableta o teléfono inteligente", FechaAlta = DateTime.Now, EsActivo = true }
                );
            });
            modelBuilder.Entity<Especificacion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Unidad)
                    .HasMaxLength(100);

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasColumnType("bit");

                // Datos iniciales de prueba
                entity.HasData(
                    // Especificaciones del AMD Ryzen 5 5600 (ProductoId = 1)
                    new { Id = 1, Clave = "Cores", Valor = "6", Unidad = (string?)null, ProductoId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Clave = "Threads", Valor = "12", Unidad = (string?)null, ProductoId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 3, Clave = "Frecuencia Base", Valor = "3.5", Unidad = "GHz", ProductoId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 4, Clave = "TDP", Valor = "65", Unidad = "W", ProductoId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 5, Clave = "Socket", Valor = "AM4", Unidad = (string?)null, ProductoId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    // Especificaciones del Corsair Vengeance 8gb DDR4 (ProductoId = 3)
                    new { Id = 6, Clave = "Capacidad", Valor = "8", Unidad = "GB", ProductoId = 3, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 7, Clave = "Tipo", Valor = "DDR4", Unidad = (string?)null, ProductoId = 3, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 8, Clave = "Frecuencia", Valor = "3200", Unidad = "MHz", ProductoId = 3, FechaAlta = DateTime.Now, EsActivo = true },
                    // Especificaciones de la NVIDIA RTX 5070 (ProductoId = 4)
                    new { Id = 9, Clave = "VRAM", Valor = "12", Unidad = "GB", ProductoId = 4, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 10, Clave = "Tipo Memoria", Valor = "GDDR7", Unidad = (string?)null, ProductoId = 4, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 11, Clave = "TDP", Valor = "250", Unidad = "W", ProductoId = 4, FechaAlta = DateTime.Now, EsActivo = true }
                );
            });

            modelBuilder.Entity<Especificacion>()
            .HasOne(e => e.Producto)
            .WithMany(p => p.Especificaciones)
            .HasForeignKey(e => e.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PaisOrigen)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasColumnType("bit");

                entity.HasData(
                    new { Id = 1, Nombre = "Nvidia", PaisOrigen = "USA", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Nombre = "AMD", PaisOrigen = "USA", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 3, Nombre = "Logitech", PaisOrigen = "USA", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 4, Nombre = "Corsair", PaisOrigen = "USA", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 5, Nombre = "Sony", PaisOrigen = "Japon", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 6, Nombre = "ATK", PaisOrigen = "China", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 7, Nombre = "ROG", PaisOrigen = "China", FechaAlta = DateTime.Now, EsActivo = true }
                );
            });
            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasConversion<int>();
                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                entity.Property(e => e.UsuarioId)
                    .IsRequired();
                entity.Property(e => e.DireccionEnvio)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.FechaAlta)
                    .IsRequired();
                entity.Property(e => e.EsActivo)
                    .IsRequired()
                    .HasColumnType("bit");
                // Relaciones
                entity.HasOne(o => o.Usuario)
                      .WithMany()
                      .HasForeignKey(o => o.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                var fechaBase = DateTime.Now;

                // Datos iniciales de prueba para órdenes
                entity.HasData(
                    new { Id = 1, Estado = EstadoOrden.Entregado, Total = 1498.00m, UsuarioId = 2, DireccionEnvio = "Av. Colón 1234, Córdoba", FechaAlta = fechaBase.AddDays(-2), EsActivo = true },
                    new { Id = 2, Estado = EstadoOrden.Enviado, Total = 369.88m, UsuarioId = 1, DireccionEnvio = "Bv. Chacabuco 789, Córdoba", FechaAlta = fechaBase.AddDays(-5), EsActivo = true },
                    new { Id = 3, Estado = EstadoOrden.Procesando, Total = 449.00m, UsuarioId = 2, DireccionEnvio = "Av. Vélez Sársfield 550, Córdoba", FechaAlta = fechaBase.AddDays(-10), EsActivo = true },
                    new { Id = 4, Estado = EstadoOrden.Pendiente, Total = 350.00m, UsuarioId = 2, DireccionEnvio = "Caseros 321, Córdoba", FechaAlta = fechaBase.AddDays(-15), EsActivo = true },
                    new { Id = 5, Estado = EstadoOrden.Entregado, Total = 1898.00m, UsuarioId = 1, DireccionEnvio = "San Jerónimo 200, Córdoba", FechaAlta = fechaBase.AddMonths(-1).AddDays(-3), EsActivo = true },
                    new { Id = 6, Estado = EstadoOrden.Entregado, Total = 299.00m, UsuarioId = 2, DireccionEnvio = "Alvear 450, Córdoba", FechaAlta = fechaBase.AddMonths(-1).AddDays(-12), EsActivo = true },
                    new { Id = 7, Estado = EstadoOrden.Cancelado, Total = 279.98m, UsuarioId = 2, DireccionEnvio = "Av. General Paz 100, Córdoba", FechaAlta = fechaBase.AddMonths(-1).AddDays(-20), EsActivo = true },
                    new { Id = 8, Estado = EstadoOrden.Entregado, Total = 2700.00m, UsuarioId = 1, DireccionEnvio = "Belgrano 600, Córdoba", FechaAlta = fechaBase.AddMonths(-2).AddDays(-5), EsActivo = true },
                    new { Id = 9, Estado = EstadoOrden.Entregado, Total = 229.80m, UsuarioId = 2, DireccionEnvio = "Ituzaingó 850, Córdoba", FechaAlta = fechaBase.AddMonths(-2).AddDays(-18), EsActivo = true },
                    new { Id = 10, Estado = EstadoOrden.Entregado, Total = 909.96m, UsuarioId = 2, DireccionEnvio = "Rondeau 400, Córdoba", FechaAlta = fechaBase.AddMonths(-3).AddDays(-6), EsActivo = true },
                    new { Id = 11, Estado = EstadoOrden.Entregado, Total = 647.00m, UsuarioId = 1, DireccionEnvio = "Estrada 150, Córdoba", FechaAlta = fechaBase.AddMonths(-3).AddDays(-16), EsActivo = true },
                    new { Id = 12, Estado = EstadoOrden.Entregado, Total = 1289.90m, UsuarioId = 2, DireccionEnvio = "Larrañaga 230, Córdoba", FechaAlta = fechaBase.AddMonths(-4).AddDays(-8), EsActivo = true },
                    new { Id = 13, Estado = EstadoOrden.Entregado, Total = 529.98m, UsuarioId = 1, DireccionEnvio = "Obispo Trejo 310, Córdoba", FechaAlta = fechaBase.AddMonths(-5).AddDays(-10), EsActivo = true }
                );
            });

            modelBuilder.Entity<OrdenItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.OrdenId)
                    .IsRequired();
                entity.Property(e => e.ProductoId)
                    .IsRequired();
                entity.Property(e => e.Cantidad)
                    .IsRequired();
                entity.Property(e => e.PrecioUnitario)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                // Relaciones
                entity.HasOne(oi => oi.Orden)
                      .WithMany(o => o.Items)
                      .HasForeignKey(oi => oi.OrdenId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(oi => oi.Producto)
                      .WithMany()
                      .HasForeignKey(oi => oi.ProductoId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Datos iniciales de prueba para items de órdenes
                entity.HasData(
                    new { Id = 1, OrdenId = 1, ProductoId = 1, Cantidad = 1, PrecioUnitario = 1200.00m },
                    new { Id = 2, OrdenId = 1, ProductoId = 3, Cantidad = 2, PrecioUnitario = 149.00m },

                    new { Id = 3, OrdenId = 2, ProductoId = 2, Cantidad = 1, PrecioUnitario = 89.90m },
                    new { Id = 4, OrdenId = 2, ProductoId = 5, Cantidad = 1, PrecioUnitario = 279.98m },

                    new { Id = 5, OrdenId = 3, ProductoId = 4, Cantidad = 1, PrecioUnitario = 349.00m },
                    new { Id = 6, OrdenId = 3, ProductoId = 6, Cantidad = 2, PrecioUnitario = 50.00m },

                    new { Id = 7, OrdenId = 4, ProductoId = 8, Cantidad = 1, PrecioUnitario = 350.00m },

                    new { Id = 8, OrdenId = 5, ProductoId = 4, Cantidad = 2, PrecioUnitario = 349.00m },
                    new { Id = 9, OrdenId = 5, ProductoId = 1, Cantidad = 1, PrecioUnitario = 1200.00m },

                    new { Id = 10, OrdenId = 6, ProductoId = 7, Cantidad = 1, PrecioUnitario = 150.00m },
                    new { Id = 11, OrdenId = 6, ProductoId = 3, Cantidad = 1, PrecioUnitario = 149.00m },

                    new { Id = 12, OrdenId = 7, ProductoId = 5, Cantidad = 1, PrecioUnitario = 279.98m },

                    new { Id = 13, OrdenId = 8, ProductoId = 1, Cantidad = 2, PrecioUnitario = 1200.00m },
                    new { Id = 14, OrdenId = 8, ProductoId = 7, Cantidad = 2, PrecioUnitario = 150.00m },

                    new { Id = 15, OrdenId = 9, ProductoId = 2, Cantidad = 2, PrecioUnitario = 89.90m },
                    new { Id = 16, OrdenId = 9, ProductoId = 6, Cantidad = 1, PrecioUnitario = 50.00m },

                    new { Id = 17, OrdenId = 10, ProductoId = 5, Cantidad = 2, PrecioUnitario = 279.98m },
                    new { Id = 18, OrdenId = 10, ProductoId = 8, Cantidad = 1, PrecioUnitario = 350.00m },

                    new { Id = 19, OrdenId = 11, ProductoId = 4, Cantidad = 1, PrecioUnitario = 349.00m },
                    new { Id = 20, OrdenId = 11, ProductoId = 3, Cantidad = 2, PrecioUnitario = 149.00m },

                    new { Id = 21, OrdenId = 12, ProductoId = 1, Cantidad = 1, PrecioUnitario = 1200.00m },
                    new { Id = 22, OrdenId = 12, ProductoId = 2, Cantidad = 1, PrecioUnitario = 89.90m },

                    new { Id = 23, OrdenId = 13, ProductoId = 7, Cantidad = 1, PrecioUnitario = 150.00m },
                    new { Id = 24, OrdenId = 13, ProductoId = 6, Cantidad = 2, PrecioUnitario = 50.00m },
                    new { Id = 25, OrdenId = 13, ProductoId = 5, Cantidad = 1, PrecioUnitario = 279.98m }
                );
            });
        }
        public void SembrarOrdenesSiVacio()
        {
            if (Ordenes.Any())
                return;

            var fechaBase = DateTime.Now;

            var ordenes = new List<Orden>
            {
                new Orden(0, EstadoOrden.Entregado, 1498.00m, 2, "Av. Colón 1234, Córdoba", fechaBase.AddDays(-2), true),
                new Orden(0, EstadoOrden.Enviado, 369.88m, 1, "Bv. Chacabuco 789, Córdoba", fechaBase.AddDays(-5), true),
                new Orden(0, EstadoOrden.Procesando, 449.00m, 2, "Av. Vélez Sársfield 550, Córdoba", fechaBase.AddDays(-10), true),
                new Orden(0, EstadoOrden.Pendiente, 350.00m, 2, "Caseros 321, Córdoba", fechaBase.AddDays(-15), true),
                new Orden(0, EstadoOrden.Entregado, 1898.00m, 1, "San Jerónimo 200, Córdoba", fechaBase.AddMonths(-1).AddDays(-3), true),
                new Orden(0, EstadoOrden.Entregado, 299.00m, 2, "Alvear 450, Córdoba", fechaBase.AddMonths(-1).AddDays(-12), true),
                new Orden(0, EstadoOrden.Cancelado, 279.98m, 2, "Av. General Paz 100, Córdoba", fechaBase.AddMonths(-1).AddDays(-20), true),
                new Orden(0, EstadoOrden.Entregado, 2700.00m, 1, "Belgrano 600, Córdoba", fechaBase.AddMonths(-2).AddDays(-5), true),
                new Orden(0, EstadoOrden.Entregado, 229.80m, 2, "Ituzaingó 850, Córdoba", fechaBase.AddMonths(-2).AddDays(-18), true),
                new Orden(0, EstadoOrden.Entregado, 909.96m, 2, "Rondeau 400, Córdoba", fechaBase.AddMonths(-3).AddDays(-6), true),
                new Orden(0, EstadoOrden.Entregado, 647.00m, 1, "Estrada 150, Córdoba", fechaBase.AddMonths(-3).AddDays(-16), true),
                new Orden(0, EstadoOrden.Entregado, 1289.90m, 2, "Larrañaga 230, Córdoba", fechaBase.AddMonths(-4).AddDays(-8), true),
                new Orden(0, EstadoOrden.Entregado, 529.98m, 1, "Obispo Trejo 310, Córdoba", fechaBase.AddMonths(-5).AddDays(-10), true)
            };

            Ordenes.AddRange(ordenes);
            SaveChanges();

            var items = new List<OrdenItem>
            {
                new OrdenItem(0, ordenes[0].Id, 1, 1, 1200.00m),
                new OrdenItem(0, ordenes[0].Id, 3, 2, 149.00m),

                new OrdenItem(0, ordenes[1].Id, 2, 1, 89.90m),
                new OrdenItem(0, ordenes[1].Id, 5, 1, 279.98m),

                new OrdenItem(0, ordenes[2].Id, 4, 1, 349.00m),
                new OrdenItem(0, ordenes[2].Id, 6, 2, 50.00m),

                new OrdenItem(0, ordenes[3].Id, 8, 1, 350.00m),

                new OrdenItem(0, ordenes[4].Id, 4, 2, 349.00m),
                new OrdenItem(0, ordenes[4].Id, 1, 1, 1200.00m),

                new OrdenItem(0, ordenes[5].Id, 7, 1, 150.00m),
                new OrdenItem(0, ordenes[5].Id, 3, 1, 149.00m),

                new OrdenItem(0, ordenes[6].Id, 5, 1, 279.98m),

                new OrdenItem(0, ordenes[7].Id, 1, 2, 1200.00m),
                new OrdenItem(0, ordenes[7].Id, 7, 2, 150.00m),

                new OrdenItem(0, ordenes[8].Id, 2, 2, 89.90m),
                new OrdenItem(0, ordenes[8].Id, 6, 1, 50.00m),

                new OrdenItem(0, ordenes[9].Id, 5, 2, 279.98m),
                new OrdenItem(0, ordenes[9].Id, 8, 1, 350.00m),

                new OrdenItem(0, ordenes[10].Id, 4, 1, 349.00m),
                new OrdenItem(0, ordenes[10].Id, 3, 2, 149.00m),

                new OrdenItem(0, ordenes[11].Id, 1, 1, 1200.00m),
                new OrdenItem(0, ordenes[11].Id, 2, 1, 89.90m),

                new OrdenItem(0, ordenes[12].Id, 7, 1, 150.00m),
                new OrdenItem(0, ordenes[12].Id, 6, 2, 50.00m),
                new OrdenItem(0, ordenes[12].Id, 5, 1, 279.98m)
            };

            OrdenItems.AddRange(items);
            SaveChanges();
        }
    }
}