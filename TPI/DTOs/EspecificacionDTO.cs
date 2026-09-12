using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EspecificacionDTO
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Valor { get; set; }
        public string? Unidad { get; set; }
        public int ProductoId { get; set; }
        public string? Producto { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsActivo { get; set; }
    }
}
