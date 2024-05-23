namespace Core.Models
{
    public class Comment : AbstractEntity
    {
        public string Content { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
        public Guid? ParentId { get; set; }
        public Comment Parent { get; set; }
        public ICollection<Comment> Children { get; } = new List<Comment>();

    }
}
