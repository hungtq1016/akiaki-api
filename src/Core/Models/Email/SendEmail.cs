namespace Core.Models 
{
    public class SendEmail : AbstractEntity
    {
        public string Email { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
