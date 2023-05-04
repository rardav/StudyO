using Catalog.Domain.Entities.Enums;

namespace Catalog.Domain.Dtos
{
    public record CourseDto
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



        public List<ChapterDto> Chapters { get; set; } = new List<ChapterDto>();
        public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
        public List<string> SkillsToGain { get; set; } = new List<string>();
        public List<FaqDto> FAQs { get; set; } = new List<FaqDto>();
    }
}
