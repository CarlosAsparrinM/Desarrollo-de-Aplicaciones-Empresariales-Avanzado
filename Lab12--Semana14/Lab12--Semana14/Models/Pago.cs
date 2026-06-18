namespace Lab12__Semana14.Models
{
    public class Pago
    {
        public int IdPago { get; set; }

        public int IdMatricula { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string MetodoPago { get; set; }

        public string EstadoPago { get; set; }

        public bool IsDeleted { get; set; }
    }
}
