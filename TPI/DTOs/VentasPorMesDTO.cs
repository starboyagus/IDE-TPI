namespace DTOs
{
    public class VentasPorMesDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int CantidadOrdenes { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal TicketPromedio { get; set; }

        public string Periodo => $"{Mes:00}/{Anio}";
    }
}
