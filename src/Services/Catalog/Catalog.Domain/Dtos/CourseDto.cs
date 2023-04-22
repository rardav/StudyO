namespace Catalog.Domain.Dtos
{
    public record CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ChapterDto> Chapters { get; set; } = default!;

    }
}
