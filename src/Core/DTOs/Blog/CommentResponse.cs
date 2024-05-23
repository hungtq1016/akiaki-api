namespace Core.DTOs
{
    public class CommentResponse : AbstractEntity
    {
        public string Content { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public Guid? ParentId { get; set; }
        public UserResponse User { get; set; }

    }
}
