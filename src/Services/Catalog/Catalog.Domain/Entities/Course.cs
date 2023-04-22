namespace Catalog.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
