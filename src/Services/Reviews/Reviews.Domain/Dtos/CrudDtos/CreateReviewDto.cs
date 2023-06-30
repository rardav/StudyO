namespace Reviews.Domain.Dtos.CrudDtos
{
    public class CreateReviewDto
    {
        public string AuthorEmail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
        public int Rating { get; set; }
    }
}
