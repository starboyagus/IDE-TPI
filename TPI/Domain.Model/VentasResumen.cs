// Domain.Model/VentasResumen.cs
namespace Domain.Model
{
    public class VentasResumen
    {
        public int CantidadOrdenes { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal TicketPromedio { get; set; }
    }
}
