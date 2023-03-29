namespace Classes.Domain.Dtos
{
    public record UpdateClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
