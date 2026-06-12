namespace Semana13.Models
{
    public class Detail
    {
        public int DetailID { get; set; }

        public int Product_ProductID { get; set; }

        public int Invoice_InvoiceID { get; set; }

        public int Amount { get; set; }

        public float Price { get; set; }

        public float SubTotal { get; set; }

        public bool IsDeleted { get; set; }


        public virtual Product Product { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}