namespace Core.DTOs
{
    public class InvoiceDetailRequest : EntityRequest
    {
        public Guid InvoiceId { get; set; }
        public Guid ServicePriceId { get; set; }
    }
}
