namespace Domain.Model
{
    public class ClienteCriteria
    {
        public string Texto { get; private set; }

        public ClienteCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}