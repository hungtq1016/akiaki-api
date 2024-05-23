namespace Core.Models
{
    public class Role : AbstractEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Group> Groups { get; set; }

    }
}
