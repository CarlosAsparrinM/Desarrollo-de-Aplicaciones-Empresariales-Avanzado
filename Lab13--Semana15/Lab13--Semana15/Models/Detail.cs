namespace Lab13__Semana15.Models
{
    public class Detail
    {
        public int IdDetails { get; set; }

        public int Products_idProducts { get; set; }

        public int Invoices_idInvoices { get; set; }

        public int Amount { get; set; }

        public float Price { get; set; }

        public float SubTotal { get; set; }

        public bool IsDeleted { get; set; }
    }
}
