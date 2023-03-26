namespace Classes.Domain.Entities
{
    public record Assignment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDateTime { get; set; }
        public Guid AssignedCourseId { get; set; }
    }
}
