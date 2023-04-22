namespace Catalog.Domain.Dtos.CrudDtos
{
    public record CreateChapterDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
    }
}
