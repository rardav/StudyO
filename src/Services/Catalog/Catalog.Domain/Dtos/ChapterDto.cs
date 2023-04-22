using StudyO.Courses.Domain.Dtos;

namespace Catalog.Domain.Dtos
{
    public record ChapterDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
        public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
    }
}
