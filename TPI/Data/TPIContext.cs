using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public TPIContext(DbContextOptions<TPIContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        internal TPIContext()
        {
            this.Database.EnsureCreated();
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

            modelBuilder.Entity<Cliente>(entity =>
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

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                //Datos inical de prueba
                entity.HasData(
                    new { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan@gmail.com", FechaAlta = DateTime.Now });
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

                entity.Property(e => e.FechaAlta)
                    .IsRequired();

                // Datos iniciales de prueba
                entity.HasData(
                    new { Id = 1, Nombre = "Laptop Dell XPS 13", Descripcion = "Ultrabook de alto rendimiento", Precio = 1200.0m, Stock = 10, EsPreVenta = false, FechaAlta = DateTime.Now },
                    new { Id = 2, Nombre = "Mouse Logitech MX Master 3", Descripcion = "Mouse inalámbrico ergonómico", Precio = 89.9m, Stock = 25, EsPreVenta = false, FechaAlta = DateTime.Now },
                    new { Id = 3, Nombre = "Teclado Mecánico Corsair K70", Descripcion = "Teclado mecánico RGB", Precio = 149.0m, Stock = 15, EsPreVenta = false, FechaAlta = DateTime.Now },
                    new { Id = 4, Nombre = "Monitor Samsung 27 4K", Descripcion = "Monitor 4K de 27 pulgadas", Precio = 349.0m, Stock = 8, EsPreVenta = false, FechaAlta = DateTime.Now },
                    new { Id = 5, Nombre = "Auriculares Sony WH-1000XM4", Descripcion = "Auriculares con cancelación de ruido", Precio = 279.98m, Stock = 20, EsPreVenta = false, FechaAlta = DateTime.Now }
                );
            });
        }
    }
}