namespace Lab13__Semana15.Models
{
    public class Invoice
    {
        public int IdInvoices { get; set; }

        public int Customers_idCustomers { get; set; }

        public DateTime Date { get; set; }

        public string InvoiceNumber { get; set; }

        public float Total { get; set; }

        public bool IsDeleted { get; set; }
    }
}
