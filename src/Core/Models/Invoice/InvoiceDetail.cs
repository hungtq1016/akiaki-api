namespace Core.Models
{
    public class InvoiceDetail : AbstractEntity
    {
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Guid ServicePriceId { get; set; }
        public ServicePrice ServicePrice { get; set; }
    }
}
