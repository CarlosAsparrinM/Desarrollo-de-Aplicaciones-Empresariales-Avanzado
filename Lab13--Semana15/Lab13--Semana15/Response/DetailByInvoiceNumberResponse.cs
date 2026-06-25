namespace Lab13__Semana15.Response
{
    public class DetailByInvoiceNumberResponse
    {
        public int IdDetails { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public float InvoiceTotal { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
