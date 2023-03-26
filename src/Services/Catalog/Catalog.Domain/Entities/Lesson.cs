namespace Catalog.Domain.Entities
{
    public record Lesson
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int OrderNumber { get; set; }
    }
}
