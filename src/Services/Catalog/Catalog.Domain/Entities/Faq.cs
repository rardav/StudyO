namespace Catalog.Domain.Entities
{
    public record Faq
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
