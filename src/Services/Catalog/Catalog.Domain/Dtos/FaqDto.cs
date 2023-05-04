namespace Catalog.Domain.Dtos
{
    public record FaqDto
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
