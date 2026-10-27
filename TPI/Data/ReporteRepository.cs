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
            AND o.FechaAlta >= @Desde
            AND o.FechaAlta <  DATEADD(DAY, 1, @Hasta)
            AND ((@Estado IS NULL AND o.Estado <> 5) OR o.Estado = @Estado)";

        private const string SqlResumen = @"
            SELECT COUNT(*)                AS CantidadOrdenes,
                   ISNULL(SUM(o.Total), 0) AS TotalFacturado,
                   ISNULL(AVG(o.Total), 0) AS TicketPromedio
            FROM Ordenes o
            WHERE " + FiltroOrdenes;

        private const string SqlPorMes = @"
            SELECT YEAR(o.FechaAlta)  AS Anio,
                   MONTH(o.FechaAlta) AS Mes,
                   COUNT(*)       AS CantidadOrdenes,
                   SUM(o.Total)   AS TotalFacturado,
                   AVG(o.Total)   AS TicketPromedio
            FROM Ordenes o
            WHERE " + FiltroOrdenes + @"
            GROUP BY YEAR(o.FechaAlta), MONTH(o.FechaAlta)
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
    
        public async Task<IEnumerable<ProductoStockCritico>> GetProductosStockCriticoAsync(int umbralMinimo, string? tipoFiltro, int? categoriaId = null, int? marcaId = null)
        {
            var resultado = new List<ProductoStockCritico>();

            var sql = @"
                SELECT p.Id,
                       p.Nombre,
                       c.Nombre AS Categoria,
                       m.Nombre AS Marca,
                       p.Precio,
                       p.Stock,
                       p.EsPreVenta,
                       CASE 
                           WHEN p.Stock = 0 AND p.EsPreVenta = 0 THEN 'Sin Stock'
                           WHEN p.Stock <= @Umbral AND p.EsPreVenta = 0 THEN 'Stock Crítico'
                           WHEN p.EsPreVenta = 1 AND p.Stock = 0 THEN 'Pre-Venta (Sin Stock)'
                           WHEN p.EsPreVenta = 1 THEN 'Pre-Venta'
                           ELSE 'Normal'
                       END AS Criticidad,
                       CASE 
                           WHEN p.Stock = 0 AND p.EsPreVenta = 0 THEN 1
                           WHEN p.Stock <= @Umbral AND p.EsPreVenta = 0 THEN 2
                           WHEN p.EsPreVenta = 1 AND p.Stock = 0 THEN 3
                           WHEN p.EsPreVenta = 1 THEN 4
                           ELSE 5
                       END AS PrioridadCriticidad
                FROM Productos p
                INNER JOIN Categorias c ON c.Id = p.CategoriaId
                INNER JOIN Marcas     m ON m.Id = p.MarcaId
                WHERE p.EsActivo = 1
                  AND (p.Stock <= @Umbral OR p.EsPreVenta = 1)";

            if (tipoFiltro == "SinStock")
                sql += " AND p.Stock = 0 AND p.EsPreVenta = 0";
            else if (tipoFiltro == "StockBajo")
                sql += " AND p.Stock > 0 AND p.Stock <= @Umbral AND p.EsPreVenta = 0";
            else if (tipoFiltro == "PreVenta")
                sql += " AND p.EsPreVenta = 1";

            if (categoriaId.HasValue)
                sql += " AND p.CategoriaId = @CategoriaId";
            if (marcaId.HasValue)
                sql += " AND p.MarcaId = @MarcaId";

            sql += " ORDER BY PrioridadCriticidad ASC, p.Stock ASC, p.Nombre ASC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Umbral", SqlDbType.Int).Value = umbralMinimo;
            if (categoriaId.HasValue)
                cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = categoriaId.Value;
            if (marcaId.HasValue)
                cmd.Parameters.Add("@MarcaId", SqlDbType.Int).Value = marcaId.Value;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new ProductoStockCritico
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                    Marca = reader.GetString(reader.GetOrdinal("Marca")),
                    Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                    EsPreVenta = reader.GetBoolean(reader.GetOrdinal("EsPreVenta")),
                    Criticidad = reader.GetString(reader.GetOrdinal("Criticidad")),
                    PrioridadCriticidad = reader.GetInt32(reader.GetOrdinal("PrioridadCriticidad"))
                });
            }

            return resultado;
        }

        public async Task<StockCriticoResumen> GetResumenStockCriticoAsync(int umbralMinimo)
        {
            const string sql = @"
                SELECT 
                    COUNT(*) AS TotalAlertas,
                    ISNULL(SUM(CASE WHEN p.Stock = 0 AND p.EsPreVenta = 0 THEN 1 ELSE 0 END), 0) AS CantidadSinStock,
                    ISNULL(SUM(CASE WHEN p.Stock > 0 AND p.Stock <= @Umbral AND p.EsPreVenta = 0 THEN 1 ELSE 0 END), 0) AS CantidadStockBajo,
                    ISNULL(SUM(CASE WHEN p.EsPreVenta = 1 THEN 1 ELSE 0 END), 0) AS CantidadPreVenta
                FROM Productos p
                WHERE p.EsActivo = 1
                  AND (p.Stock <= @Umbral OR p.EsPreVenta = 1)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Umbral", SqlDbType.Int).Value = umbralMinimo;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();

            return new StockCriticoResumen
            {
                TotalAlertas = reader.GetInt32(reader.GetOrdinal("TotalAlertas")),
                CantidadSinStock = reader.GetInt32(reader.GetOrdinal("CantidadSinStock")),
                CantidadStockBajo = reader.GetInt32(reader.GetOrdinal("CantidadStockBajo")),
                CantidadPreVenta = reader.GetInt32(reader.GetOrdinal("CantidadPreVenta"))
            };
        }

        public async Task<IEnumerable<StockPorCategoria>> GetStockCriticoPorCategoriaAsync(int umbralMinimo)
        {
            var resultado = new List<StockPorCategoria>();

            const string sql = @"
                SELECT c.Id AS CategoriaId,
                       c.Nombre AS Categoria,
                       COUNT(*) AS CantidadProductos
                FROM Productos p
                INNER JOIN Categorias c ON c.Id = p.CategoriaId
                WHERE p.EsActivo = 1
                  AND (p.Stock <= @Umbral OR p.EsPreVenta = 1)
                GROUP BY c.Id, c.Nombre
                ORDER BY CantidadProductos DESC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Umbral", SqlDbType.Int).Value = umbralMinimo;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new StockPorCategoria
                {
                    CategoriaId = reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                    Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                    CantidadProductos = reader.GetInt32(reader.GetOrdinal("CantidadProductos"))
                });
            }

            return resultado;
        }

        public async Task<IEnumerable<StockPorMarca>> GetStockCriticoPorMarcaAsync(int umbralMinimo)
        {
            var resultado = new List<StockPorMarca>();

            const string sql = @"
                SELECT m.Id AS MarcaId,
                       m.Nombre AS Marca,
                       COUNT(*) AS CantidadProductos
                FROM Productos p
                INNER JOIN Marcas m ON m.Id = p.MarcaId
                WHERE p.EsActivo = 1
                  AND (p.Stock <= @Umbral OR p.EsPreVenta = 1)
                GROUP BY m.Id, m.Nombre
                ORDER BY CantidadProductos DESC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Umbral", SqlDbType.Int).Value = umbralMinimo;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultado.Add(new StockPorMarca
                {
                    MarcaId = reader.GetInt32(reader.GetOrdinal("MarcaId")),
                    Marca = reader.GetString(reader.GetOrdinal("Marca")),
                    CantidadProductos = reader.GetInt32(reader.GetOrdinal("CantidadProductos"))
                });
            }

            return resultado;
        }
    }
}
