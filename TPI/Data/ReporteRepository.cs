using System.Data;
using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly string _connectionString;

        public ReporteRepository(TPIContext context)
        {
            _connectionString = context.Database.GetConnectionString()!;
        }

        private const string FiltroOrdenes = @"
            o.EsActivo = 1
            AND o.Fecha >= @Desde
            AND o.Fecha <  DATEADD(DAY, 1, @Hasta)
            AND ((@Estado IS NULL AND o.Estado <> 5) OR o.Estado = @Estado)";

        private const string SqlResumen = @"
            SELECT COUNT(*)                AS CantidadOrdenes,
                   ISNULL(SUM(o.Total), 0) AS TotalFacturado,
                   ISNULL(AVG(o.Total), 0) AS TicketPromedio
            FROM Ordenes o
            WHERE " + FiltroOrdenes;

        private const string SqlPorMes = @"
            SELECT YEAR(o.Fecha)  AS Anio,
                   MONTH(o.Fecha) AS Mes,
                   COUNT(*)       AS CantidadOrdenes,
                   SUM(o.Total)   AS TotalFacturado,
                   AVG(o.Total)   AS TicketPromedio
            FROM Ordenes o
            WHERE " + FiltroOrdenes + @"
            GROUP BY YEAR(o.Fecha), MONTH(o.Fecha)
            ORDER BY Anio, Mes";

        private const string SqlTopProductos = @"
            SELECT TOP (@Top)
                   p.Id     AS ProductoId,
                   p.Nombre AS Producto,
                   c.Nombre AS Categoria,
                   m.Nombre AS Marca,
                   SUM(oi.Cantidad)                     AS UnidadesVendidas,
                   SUM(oi.Cantidad * oi.PrecioUnitario) AS Facturacion
            FROM OrdenItems oi
            INNER JOIN Ordenes    o ON o.Id = oi.OrdenId
            INNER JOIN Productos  p ON p.Id = oi.ProductoId
            INNER JOIN Categorias c ON c.Id = p.CategoriaId
            INNER JOIN Marcas     m ON m.Id = p.MarcaId
            WHERE " + FiltroOrdenes + @"
            GROUP BY p.Id, p.Nombre, c.Nombre, m.Nombre
            ORDER BY UnidadesVendidas DESC, Facturacion DESC";

        private const string SqlPorMarca = @"
            SELECT m.Id     AS MarcaId,
                   m.Nombre AS Marca,
                   SUM(oi.Cantidad)                     AS UnidadesVendidas,
                   SUM(oi.Cantidad * oi.PrecioUnitario) AS Facturacion,
                   ISNULL(CAST(100.0 * SUM(oi.Cantidad * oi.PrecioUnitario)
                        / NULLIF(SUM(SUM(oi.Cantidad * oi.PrecioUnitario)) OVER (), 0) AS decimal(5,2)), 0) AS Porcentaje
            FROM OrdenItems oi
            INNER JOIN Ordenes   o ON o.Id = oi.OrdenId
            INNER JOIN Productos p ON p.Id = oi.ProductoId
            INNER JOIN Marcas    m ON m.Id = p.MarcaId
            WHERE " + FiltroOrdenes + @"
            GROUP BY m.Id, m.Nombre
            ORDER BY Facturacion DESC";

        private static void AgregarFiltros(SqlCommand cmd, ReporteCriteria criteria)
        {
            cmd.Parameters.Add("@Desde", SqlDbType.Date).Value = criteria.Desde;
            cmd.Parameters.Add("@Hasta", SqlDbType.Date).Value = criteria.Hasta;
            cmd.Parameters.Add("@Estado", SqlDbType.Int).Value =
                criteria.Estado.HasValue ? (object)(int)criteria.Estado.Value : DBNull.Value;
        }

        public async Task<VentasResumen> GetResumenVentasAsync(ReporteCriteria criteria)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SqlResumen, conn);
            AgregarFiltros(cmd, criteria);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();

            return new VentasResumen
            {
                CantidadOrdenes = reader.GetInt32(reader.GetOrdinal("CantidadOrdenes")),
                TotalFacturado = reader.GetDecimal(reader.GetOrdinal("TotalFacturado")),
                TicketPromedio = reader.GetDecimal(reader.GetOrdinal("TicketPromedio"))
            };
        }

        public async Task<IEnumerable<VentasPorMes>> GetVentasPorMesAsync(ReporteCriteria criteria)
        {
            var resultado = new List<VentasPorMes>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SqlPorMes, conn);
            AgregarFiltros(cmd, criteria);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new VentasPorMes
                {
                    Anio = reader.GetInt32(reader.GetOrdinal("Anio")),
                    Mes = reader.GetInt32(reader.GetOrdinal("Mes")),
                    CantidadOrdenes = reader.GetInt32(reader.GetOrdinal("CantidadOrdenes")),
                    TotalFacturado = reader.GetDecimal(reader.GetOrdinal("TotalFacturado")),
                    TicketPromedio = reader.GetDecimal(reader.GetOrdinal("TicketPromedio"))
                });
            }

            return resultado;
        }

        public async Task<IEnumerable<ProductoVendido>> GetTopProductosAsync(ReporteCriteria criteria)
        {
            var resultado = new List<ProductoVendido>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SqlTopProductos, conn);
            AgregarFiltros(cmd, criteria);
            cmd.Parameters.Add("@Top", SqlDbType.Int).Value = criteria.Top;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new ProductoVendido
                {
                    ProductoId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                    Producto = reader.GetString(reader.GetOrdinal("Producto")),
                    Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                    Marca = reader.GetString(reader.GetOrdinal("Marca")),
                    UnidadesVendidas = reader.GetInt32(reader.GetOrdinal("UnidadesVendidas")),
                    Facturacion = reader.GetDecimal(reader.GetOrdinal("Facturacion"))
                });
            }

            return resultado;
        }

        public async Task<IEnumerable<FacturacionMarca>> GetFacturacionPorMarcaAsync(ReporteCriteria criteria)
        {
            var resultado = new List<FacturacionMarca>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SqlPorMarca, conn);
            AgregarFiltros(cmd, criteria);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new FacturacionMarca
                {
                    MarcaId = reader.GetInt32(reader.GetOrdinal("MarcaId")),
                    Marca = reader.GetString(reader.GetOrdinal("Marca")),
                    UnidadesVendidas = reader.GetInt32(reader.GetOrdinal("UnidadesVendidas")),
                    Facturacion = reader.GetDecimal(reader.GetOrdinal("Facturacion")),
                    Porcentaje = reader.GetDecimal(reader.GetOrdinal("Porcentaje"))
                });
            }

            return resultado;
        }
    }
}
