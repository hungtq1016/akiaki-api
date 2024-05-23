namespace Core.Models
{
    public class Permission : AbstractEntity
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
