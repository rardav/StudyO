namespace Users.Domain.Dtos
{
    public class UserDetailsDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegister { get; set; }
        public int Role { get; set; }
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? GithubUsername { get; set; }
    }
}
