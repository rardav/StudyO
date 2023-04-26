namespace Catalog.Domain.Dtos.CrudDtos
{
    public class CreateSectionDto
    {
        public string Title { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
