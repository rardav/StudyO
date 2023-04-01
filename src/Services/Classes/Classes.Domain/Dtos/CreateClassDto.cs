namespace Classes.Domain.Dtos
{
    public record CreateClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid InstructorId { get; set; }
        public List<Guid> StudentsIds { get; set; } = new List<Guid>();
        public List<AssignmentDto> Assignments { get; set; } = new List<AssignmentDto>();
    }
}
