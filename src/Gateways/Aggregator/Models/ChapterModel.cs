namespace Aggregator.Models
{
    public record ChapterModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
        public List<LessonModel> Lessons { get; set; } = new List<LessonModel>();
    }
}
