using Catalog.Domain.Entities.Enums;

namespace Catalog.Domain.Entities
{
    public record Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public Language Language { get; set; }
        public Level Level { get; set; }
        public Subject Subject { get; set; }
        public int TimeToComplete { get; set; }
        public string Prerequisites { get; set; } = string.Empty;



        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<string> SkillsToGain { get; set; } = new List<string>();
        public List<Faq> FAQs { get; set; } = new List<Faq>();
    }
}
