using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string Salt { get; private set; }
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

        // Constructor sin parámetros requerido por Entity Framework.
        // Sin él, EF usaría el constructor público al leer de la base y SetContrasenia
        // volvería a hashear el hash ya guardado, rompiendo la contraseña en cada lectura.
        private Usuario() { }

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

        // Recibe la contraseña en texto plano: genera un salt nuevo y la hashea.
        public void SetContrasenia(string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(contrasenia))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(contrasenia));
            Salt = GenerateSalt();
            Contrasenia = HashPassword(contrasenia, Salt);
        }

        // Copia un hash y un salt ya calculados, SIN volver a hashear.
        // Se usa al actualizar un usuario sin cambiarle la contraseña: si en ese caso
        // se llamara a SetContrasenia, se hashearía el hash y la contraseña quedaría destruida.
        public void EstablecerContraseniaHasheada(string contraseniaHasheada, string salt)
        {
            if (string.IsNullOrWhiteSpace(contraseniaHasheada))
                throw new ArgumentException("La contraseña hasheada no puede ser nula o vacía.", nameof(contraseniaHasheada));
            if (string.IsNullOrWhiteSpace(salt))
                throw new ArgumentException("El salt no puede ser nulo o vacío.", nameof(salt));

            Contrasenia = contraseniaHasheada;
            Salt = salt;
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

        // Públicos para que el seed del DbContext pueda generar el par salt/hash inicial.
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            RandomNumberGenerator.Fill(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            string hashedInput = HashPassword(password, Salt);
            return Contrasenia == hashedInput;
        }

        public static string HashPassword(string password, string salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
