namespace Catalog.Domain.Dtos.CrudDtos
{
    public record CreateCourseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatorId { get; set; }
    }
}

