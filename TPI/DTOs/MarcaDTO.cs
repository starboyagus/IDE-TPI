using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MarcaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool EsActivo { get; set; }
    }
}
