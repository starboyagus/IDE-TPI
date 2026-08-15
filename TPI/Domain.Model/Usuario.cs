using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Contrasenia { get; private set; }
        public RolUsuario Rol { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public bool EsActivo { get; private set; }

        public Usuario(int id, string nombre, string apellido, string email, string telefono, string contrasenia, RolUsuario rol, DateTime fechaAlta, bool esActivo)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetTelefono(telefono);
            SetContrasenia(contrasenia);
            SetRol(rol);
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

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede ser nulo o vacío.", nameof(telefono));
            Telefono = telefono;
        }

        public void SetContrasenia(string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(contrasenia))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(contrasenia));
            Contrasenia = contrasenia;
        }

        public void SetRol(RolUsuario rol)
        {
            if (!Enum.IsDefined(typeof(RolUsuario), rol))
                throw new ArgumentException("El rol no es válido.", nameof(rol));
            Rol = rol;
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
