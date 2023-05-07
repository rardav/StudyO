namespace Aggregator.Models
{
    public record ReviewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Guid UserId { get; set; }
    }
}