using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Domain.Model
{
    public class Orden
    {
        public int Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public EstadoOrden Estado { get; private set; }
        public decimal Total{ get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public string DireccionEnvio { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsActivo { get; private set; }

        public Orden(int id, DateTime fecha, EstadoOrden estado, decimal total, int usuarioId, string direccionEnvio, DateTime fechaAlta, bool esActivo)
        {
            SetId(id);
            SetFecha(fecha);
            SetEstado(estado);
            SetTotal(total);
            SetUsuarioId(usuarioId);
            SetDireccionEnvio(direccionEnvio);
            SetFechaAlta(fechaAlta);
            SetEsActivo(esActivo);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetFecha(DateTime fecha)
        {
            if (fecha == default)
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fecha));
            Fecha = fecha;
        }

        public void SetEstado(EstadoOrden estado)
        {
            if (!Enum.IsDefined(typeof(EstadoOrden), estado))
                throw new ArgumentException("El rol no es válido.", nameof(estado));
            Estado = estado;
        }
        public void SetTotal(decimal total)
        {
            if (total < 0)
                throw new ArgumentException("El precio debe ser mayor que 0.", nameof(total));
            Total = total;
        }
        public void SetUsuarioId(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentException("La categoría no puede ser nula.", nameof(usuarioId));
            UsuarioId = usuarioId;
        }

        public void SetDireccionEnvio(string direccionEnvio)
        {
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
            EsActivo = esActivo;
        }

        
    }
}
