namespace Users.Domain.Entities
{
    public record User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfRegister { get; set; }
        public int Role { get; set; }
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? GithubUsername { get; set; }
    }
}
