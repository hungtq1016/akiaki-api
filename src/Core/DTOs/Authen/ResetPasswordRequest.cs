using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class ResetPasswordRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}
