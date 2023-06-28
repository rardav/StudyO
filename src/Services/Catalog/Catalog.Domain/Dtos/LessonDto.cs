using Catalog.Domain.Dtos;

namespace StudyO.Courses.Domain.Dtos
{
    public record LessonDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; }
        public int OrderNumber { get; set; }
        public List<SectionDto> Sections { get; set; } = new List<SectionDto>();
    }
}
