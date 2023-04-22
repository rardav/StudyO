namespace Catalog.Domain.Dtos
{
    public record SectionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
