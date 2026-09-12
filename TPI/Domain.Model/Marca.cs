using System.Text.RegularExpressions;


namespace Domain.Model
{
    public class Marca
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string? PaisOrigen { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsActivo { get; private set; }
        
        public Marca(int id, string nombre, string? paisOrigen, DateTime fechaAlta, bool esActivo)
        {
            SetId(id);
            SetNombre(nombre);
            SetPaisOrigen(paisOrigen);
            SetFechaAlta(fechaAlta);
            SetEsActivo(esActivo);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetPaisOrigen(string paisOrigen)
        {
            PaisOrigen= paisOrigen;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
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
