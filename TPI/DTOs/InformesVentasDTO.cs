using Domain.Model;

namespace DTOs
{
    public class InformeVentasDTO
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public EstadoOrden? Estado { get; set; }
        public int Top { get; set; }

        public VentasResumenDTO Resumen { get; set; } = new();
        public List<VentasPorMesDTO> VentasPorMes { get; set; } = new();
        public List<ProductoVendidoDTO> TopProductos { get; set; } = new();
        public List<FacturacionMarcaDTO> FacturacionPorMarca { get; set; } = new();
        public string EstadoDescripcion => Estado?.ToString() ?? "Todos (sin cancelados)";
    }
}
