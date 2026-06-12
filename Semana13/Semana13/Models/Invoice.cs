namespace Semana13.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        public int Customers_CustomerID { get; set; }

        public DateTime Date { get; set; }

        public string InvoiceNumber { get; set; }

        public float Total { get; set; }

        public bool IsDeleted { get; set; }


        public virtual Customer Customer { get; set; }
    }
}