namespace Catalog.Domain.Entities
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
