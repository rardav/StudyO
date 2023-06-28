namespace Catalog.Domain.Entities
{
    public record Lesson
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();
    }
}
