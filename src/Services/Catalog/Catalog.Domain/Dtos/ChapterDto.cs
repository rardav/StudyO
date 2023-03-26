using StudyO.Courses.Domain.Dtos;

namespace Catalog.Domain.Dtos
{
    public record ChapterDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}
