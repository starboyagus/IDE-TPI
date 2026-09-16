using System.Text.RegularExpressions;


namespace Domain.Model
{
    public class Especificacion
    {
        public int Id { get; private set; }
        public string Clave { get; private set; }
        public string Valor { get; private set; }
        public string? Unidad { get; private set; }
        public int ProductoId { get; private set; }
        public Producto? Producto { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsActivo { get; private set; }  

        public Especificacion(int id, string clave, string valor, string? unidad, int productoId, DateTime fechaAlta, bool esActivo)
        {
            SetId(id);
            SetClave(clave);
            SetValor(valor);
            SetUnidad(unidad);
            SetProductoId(productoId);
            SetFechaAlta(fechaAlta);
            SetEsActivo(esActivo);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede ser nula o vacía.", nameof(clave));
            Clave = clave;
        }

        public void SetValor(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("El valor no puede ser nulo o vacío.", nameof(valor));
            Valor= valor;
        }

        public void SetUnidad(string? unidad)
        {
            Unidad = unidad;
        }

        public void SetProductoId(int productoId)
        {
            if (productoId < 0)
                throw new ArgumentException("El Id del producto debe ser mayor que 0.", nameof(productoId));
            ProductoId = productoId;
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
