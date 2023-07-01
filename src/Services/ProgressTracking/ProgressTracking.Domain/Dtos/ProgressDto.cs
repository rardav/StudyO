namespace ProgressTracking.Domain.Dtos
{
    public class ProgressDto
    {
        public string StudentEmail { get; set; }
        public Guid CourseId { get; set; }
        public Guid LessonId { get; set; }
        public bool CourseFinished { get; set; }
    }
}
