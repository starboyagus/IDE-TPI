namespace Domain.Model
{
    public class UsuarioCriteria
    {
        public string Texto { get; private set; }

        public UsuarioCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}
