namespace Catalog.Domain.Entities
{
    public record Chapter
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
