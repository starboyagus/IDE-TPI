using System.Text.RegularExpressions;

namespace DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public bool esPreVenta { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}