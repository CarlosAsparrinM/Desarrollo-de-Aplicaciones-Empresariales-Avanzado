namespace Lab13__Semana15.Response
{
    public class DetailByDateResponse
    {
        public int IdDetails { get; set; }
        public int Amount { get; set; }
        public float DetailPrice { get; set; }
        public float SubTotal { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public float InvoiceTotal { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
    }
}
