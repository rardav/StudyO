namespace Aggregator.Models
{
    public record FaqModel
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}