// Domain.Model/FacturacionMarca.cs
namespace Domain.Model
{
    public class FacturacionMarca
    {
        public int MarcaId { get; set; }
        public string Marca { get; set; } = string.Empty;
        public int UnidadesVendidas { get; set; }
        public decimal Facturacion { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
