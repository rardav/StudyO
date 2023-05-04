namespace Catalog.Domain.Entities
{
    public record Review
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Guid UserId { get; set; }
    }
}
