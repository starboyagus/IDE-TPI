namespace Domain.Model
{
    public class ReporteCriteria
    {
        public DateTime Desde { get; private set; }
        public DateTime Hasta { get; private set; }
        public EstadoOrden? Estado { get; private set; }
        public int Top { get; private set; }

        public ReporteCriteria(DateTime desde, DateTime hasta, EstadoOrden? estado, int top)
        {
            if (desde.Date > hasta.Date)
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            if (top < 1 || top > 100)
                throw new ArgumentException("El top debe estar entre 1 y 100.");

            Desde = desde.Date;
            Hasta = hasta.Date;
            Estado = estado;
            Top = top;
        }
    }
}
