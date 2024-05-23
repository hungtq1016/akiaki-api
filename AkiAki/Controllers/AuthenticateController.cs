﻿using Infrastructure.Filters;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenService _service;

        public AuthenticateController(IAuthenService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _service.LoginAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("user")]
        [TokenRequired]
        public async Task<IActionResult> GetUser()
        {
            var result = await _service.GetUserAsync(HttpContext);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _service.RegisterAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            var result = await _service.SendEmailAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("generate-token")]
        public async Task<IActionResult> AccessToken([FromBody] Guid userId)
        {
            var result = await _service.GenerateAccessToken(userId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var result = await _service.RefreshAccessToken(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("email-valid")]
        public async Task<IActionResult> EmailValid([FromBody] EmailValidRequest request)
        {
            var result = await _service.EmailVaidAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("send-reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _service.SendResetPasswordAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOTP([FromBody] EmailRequest request)
        {
            var result = await _service.SendOTPAsync(request.Email);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("receive-otp")]
        public async Task<IActionResult> ReceiveOTP([FromBody] OTPRequest request)
        {
            var result = await _service.ReceiveOTPAsync(request);
            return StatusCode(result.StatusCode, result);
        }
    }
}
