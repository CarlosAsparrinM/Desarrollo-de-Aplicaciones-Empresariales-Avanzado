namespace Lab12__Semana14.Response
{
    public class PagoResponse
    {
        public int IdPago { get; set; }

        public int IdMatricula { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string MetodoPago { get; set; }

        public string EstadoPago { get; set; }
    }
}
