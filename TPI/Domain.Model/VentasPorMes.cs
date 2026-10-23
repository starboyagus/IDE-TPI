// Domain.Model/VentasPorMes.cs
namespace Domain.Model
{
    public class VentasPorMes
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int CantidadOrdenes { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal TicketPromedio { get; set; }
    }
}
