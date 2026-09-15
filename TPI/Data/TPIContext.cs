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
                    new { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan@gmail.com", Telefono = "3511234567", Salt = saltSeed, Contrasenia = Usuario.HashPassword("usuario123", saltSeed), Rol = RolUsuario.Admin, FechaAlta = DateTime.Now, EsActivo = true });
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
                    new { Id = 1, Nombre = "AMD Ryzen 5 5600", Descripcion = "Procesador AM4 6C 12T", Precio = 1200.0m, Stock = 10, EsPreVenta = false, CategoriaId = 1, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Nombre = "Mouse Logitech MX Master 3", Descripcion = "Mouse inalámbrico ergonómico", Precio = 89.9m, Stock = 25, EsPreVenta = false, CategoriaId = 5, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 3, Nombre = "Corsair Vengeance 8gb DDR4", Descripcion = "Memoria RAM DDR4 8GB 3200MHz", Precio = 149.0m, Stock = 15, EsPreVenta = false, CategoriaId = 2, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 4, Nombre = "NVIDIA RTX 5070", Descripcion = "Placa de video RTX5070 12GB VRAM", Precio = 349.0m, Stock = 8, EsPreVenta = false, CategoriaId = 3, FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 5, Nombre = "Auriculares Sony WH-1000XM4", Descripcion = "Auriculares con cancelación de ruido", Precio = 279.98m, Stock = 20, EsPreVenta = false, CategoriaId = 4, FechaAlta = DateTime.Now, EsActivo = true }
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
                    new { Id = 5, Nombre = "Mouse", Descripcion = "Periferico con sensor optico y click mecanico", FechaAlta = DateTime.Now, EsActivo = true }
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
            });

            modelBuilder.Entity<Especificacion>()
            .HasOne(e => e.Producto)
            .WithMany()
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
                    new { Id = 1, Nombre = "Nvidia", Descripcion = "Unidad central de procesamiento", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 2, Nombre = "RAM", Descripcion = "Memoria de acceso aleatorio", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 3, Nombre = "GPU", Descripcion = "Unidad de procesamiento de graficos", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 4, Nombre = "Auricular", Descripcion = "Periferico con parlantes stereo", FechaAlta = DateTime.Now, EsActivo = true },
                    new { Id = 5, Nombre = "Mouse", Descripcion = "Periferico con sensor optico y click mecanico", FechaAlta = DateTime.Now, EsActivo = true }
                );
            });
        }

    }
}
