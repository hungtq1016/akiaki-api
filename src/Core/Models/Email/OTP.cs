namespace Core.Models
{
    public class OTP : AbstractEntity
    {
        public string Email { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int Code { get; set; }
    }
}
