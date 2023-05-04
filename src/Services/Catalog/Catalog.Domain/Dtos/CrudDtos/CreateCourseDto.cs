namespace Catalog.Domain.Dtos.CrudDtos
{
    public record CreateCourseDto
    {
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public Guid CreatorId { get; set; }
        public int Language { get; set; }
        public int Level { get; set; }
        public int Subject { get; set; }
        public int TimeToComplete { get; set; }
        public string Prerequisites { get; set; } = string.Empty;

        public List<string> SkillsToGain { get; set; } = new List<string>();
        public List<FaqDto> FAQs { get; set; } = new List<FaqDto>();
    }
}

