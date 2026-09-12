using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrdenDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoOrden Estado { get; set; }
        public decimal Total{ get; set; }
        public int UsuarioId { get; set; }
        public string? Usuario { get; set; }
        public string DireccionEnvio { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsActivo { get; set; }
    }
}
