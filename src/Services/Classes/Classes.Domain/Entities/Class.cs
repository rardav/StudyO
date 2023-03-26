namespace Classes.Domain.Entities
{
    public record Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid InstructorId { get; set; }
        public List<Guid> StudentsIds { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
