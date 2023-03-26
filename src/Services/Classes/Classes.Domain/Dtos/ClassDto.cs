namespace Classes.Domain.Dtos
{
    public record ClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid InstructorId { get; set; }
        public List<Guid> StudentsIds { get; set; }
        public List<AssignmentDto> Assignments { get; set; }
    }
}
