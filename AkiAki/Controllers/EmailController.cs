
using System.Linq.Expressions;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("schedule")]
        public IActionResult SendMail(ScheduleMail request)
        {
            _emailService.SendSchedule(request);
            return Ok();
        }


        [HttpPost("treatment")]
        public IActionResult Sendreatment(ScheduleMail request)
        {
            _emailService.SendTreatment(request);
            return Ok();
        }
    }
}
