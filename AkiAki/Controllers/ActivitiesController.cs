namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ResourceController<Activity, ActivityRequest, ActivityResponse>
    {
        public ActivitiesController(IService<Activity, ActivityRequest, ActivityResponse> service) : base(service)
        {
        }
    }
}
