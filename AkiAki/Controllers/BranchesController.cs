namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ResourceController<Branch, BranchRequest, BranchResponse>
    {
        public BranchesController(IService<Branch, BranchRequest, BranchResponse> service) : base(service)
        {
        }
    }
}
