namespace Aggregator.Models
{
    public class ProgressModel
    {
        public Guid Id { get; set; }
        public string StudentEmail { get; set; }
        public Guid LessonId { get; set; }
        public Guid CourseId { get; set; }
        public bool CourseFinished { get; set; }
        public CourseModel Course { get; set; }
    }
}
