namespace Core.Models
{
    public class ServicePrice : AbstractEntity
    {
        public string Label { get; set; }
        public double Price { get; set; }
        public ICollection<InvoiceDetail>? InvoiceDetails { get; } = new List<InvoiceDetail>();
    }
}
