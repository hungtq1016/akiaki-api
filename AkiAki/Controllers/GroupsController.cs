namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : SingletonController<Group, GroupRequest, GroupResponse>
    {
        public GroupsController(IService<Group, GroupRequest, GroupResponse> service) : base(service)
        {
        }
    }
}
