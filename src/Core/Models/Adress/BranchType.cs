namespace Core.Models
{
    public class BranchType : AbstractEntity
    {
        public string Label { get; set; }
        public ICollection<Branch> Branches { get; } = new List<Branch>();
    }
}
