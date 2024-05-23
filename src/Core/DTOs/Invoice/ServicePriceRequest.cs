namespace Core.DTOs
{
    public class ServicePriceRequest : EntityRequest
    {
        public string Label { get; set; }
        public double Price { get; set; }
    }
}
