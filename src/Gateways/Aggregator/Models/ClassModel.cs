namespace Aggregator.Models
{
    public record ClassModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AssignmentModel> Assignments { get; set; }
    }
}
