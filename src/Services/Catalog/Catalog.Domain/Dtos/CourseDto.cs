namespace Catalog.Domain.Dtos
{
    public record CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ChapterDto> Chapters { get; set; }

    }
}
