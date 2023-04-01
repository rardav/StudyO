namespace Aggregator.Models
{
    public record AssignmentModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDateTime { get; set; }
        public Guid CourseId { get; set; }
        public CourseModel Course { get; set; }
    }
}
