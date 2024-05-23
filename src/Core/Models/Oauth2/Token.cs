namespace Core.Models
{
    public class Token : AbstractEntity
    {
        public string RefreshToken { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
