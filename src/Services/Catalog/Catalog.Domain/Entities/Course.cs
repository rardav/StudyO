namespace Catalog.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
