using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Domain.Model
{
    public class Orden
    {
        public int Id { get; private set; }
        public EstadoOrden Estado { get; private set; }
        public decimal Total{ get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public string DireccionEnvio { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsActivo { get; private set; }
        public ICollection<OrdenItem> Items { get; private set; } = new List<OrdenItem>();

        public Orden(int id, EstadoOrden estado, decimal total, int usuarioId, string direccionEnvio, DateTime fechaAlta, bool esActivo)
        {
            SetId(id);         
            SetTotal(total);
            SetUsuarioId(usuarioId);
            SetDireccionEnvio(direccionEnvio);
            SetFechaAlta(fechaAlta);
            SetEsActivo(esActivo);
            SetEstado(estado);
        }

        private void ValidarModificable()
        {
             if(Estado == EstadoOrden.Entregado || Estado==EstadoOrden.Cancelado){
                throw new ArgumentException($"La orden ya esta {Estado} y no puede modificarse");
            }
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetEstado(EstadoOrden estado)
        {
            ValidarModificable();
            if (!Enum.IsDefined(typeof(EstadoOrden), estado))
                throw new ArgumentException("El estado no es válido.", nameof(estado));
            Estado = estado;
        }
        public void SetTotal(decimal total)
        {
            ValidarModificable();
            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo.", nameof(total));
            Total = total;
        }
        public void SetUsuarioId(int usuarioId)
        {
            ValidarModificable();
            if (usuarioId <= 0)
                throw new ArgumentException("El usuario es obligatorio.", nameof(usuarioId));
            UsuarioId = usuarioId;
        }

        public void SetDireccionEnvio(string direccionEnvio)
        {
            ValidarModificable();
            if (string.IsNullOrWhiteSpace(direccionEnvio))
                throw new ArgumentException("La dirección de envío no puede ser nula o vacía.", nameof(direccionEnvio));
            DireccionEnvio = direccionEnvio;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default)
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }

        public void SetEsActivo(bool esActivo)
        {
            ValidarModificable();
            EsActivo = esActivo;
        }


    }
}
