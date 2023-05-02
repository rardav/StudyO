using Catalog.Domain.Entities;

namespace Catalog.Domain.Dtos
{
    public record CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Language { get; set; }
        public int Level { get; set; }
        public int Subject { get; set; }

        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
