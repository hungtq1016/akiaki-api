namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePricesController : ResourceController<ServicePrice, ServicePriceRequest, ServicePriceResponse>
    {
        public ServicePricesController(IService<ServicePrice, ServicePriceRequest, ServicePriceResponse> service) : base(service)
        {
        }
    }
}
