namespace Catalog.Domain.Dtos.CrudDtos
{
    public record CreateLessonDto
    {
        public string Title { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
    }
}
