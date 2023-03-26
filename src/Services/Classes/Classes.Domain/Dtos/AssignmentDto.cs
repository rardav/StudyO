namespace Classes.Domain.Dtos
{
    public record AssignmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDateTime { get; set; }
        public Guid AssignedCourseId { get; set; }
    }
}
