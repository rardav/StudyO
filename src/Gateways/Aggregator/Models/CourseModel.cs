namespace Aggregator.Models
{
    public record CourseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public int Language { get; set; }
        public int Level { get; set; }
        public int Subject { get; set; }
        public int TimeToComplete { get; set; }
        public string Prerequisites { get; set; } = string.Empty;



        public List<ChapterModel> Chapters { get; set; } = new List<ChapterModel>();
        public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public List<string> SkillsToGain { get; set; } = new List<string>();
        public List<FaqModel> Faqs { get; set; } = new List<FaqModel>();
    }
}
