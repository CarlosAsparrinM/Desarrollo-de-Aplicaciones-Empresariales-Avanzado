namespace Lab13__Semana15.Response
{
    public class InvoiceByCustomerResponse
    {
        public int IdInvoices { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerDocumentNumber { get; set; }
    }
}
