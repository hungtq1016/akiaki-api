namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchTypesController : ResourceController<BranchType, BranchTypeRequest, BranchTypeResponse>
    {
        public BranchTypesController(IService<BranchType, BranchTypeRequest, BranchTypeResponse> service) : base(service)
        {
        }
    }
}
