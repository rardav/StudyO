namespace Aggregator.Models
{
    public record LessonModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
        public List<SectionModel> Sections { get; set; } = new List<SectionModel>();
    }
}
