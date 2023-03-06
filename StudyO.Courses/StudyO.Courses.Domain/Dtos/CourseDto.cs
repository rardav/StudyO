namespace StudyO.Courses.Domain.Dtos
{
    public record CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
    }
}
