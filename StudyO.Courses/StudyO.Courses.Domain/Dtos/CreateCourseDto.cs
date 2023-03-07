namespace StudyO.Courses.Domain.Dtos
{
    public record CreateCourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

