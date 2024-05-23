namespace Core.DTOs
{
    public class InvoiceDetailResponse : AbstractEntity
    {
        public Guid InvoiceId { get; set; }
        public Guid ServicePriceId { get; set; }
        public ServicePriceResponse ServicePrice { get; set; }
    }
}
