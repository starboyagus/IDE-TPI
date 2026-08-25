using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsActivo { get; private set; }

        public Categoria(int id, string nombre, string descripcion, DateTime fechaAlta, bool esActivo)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetFechaAlta(fechaAlta);
            SetEsActivo(esActivo);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
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