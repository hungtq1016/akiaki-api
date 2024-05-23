using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class RegisterRequest
    {
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "This must be an email address.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[!@#$%^&*(),.?\"":{}|<>])(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$",
         ErrorMessage = "Password not allow.")]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}
