namespace StudyO.Courses.Domain.Dtos
{
    public record LessonDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int OrderNumber { get; set; }
    }
}
