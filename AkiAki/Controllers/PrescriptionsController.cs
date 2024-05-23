namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ResourceController<Prescription, PrescriptionRequest, PrescriptionResponse>
    {
        public PrescriptionsController(IService<Prescription, PrescriptionRequest, PrescriptionResponse> service) : base(service)
        {
        }
    }
}
