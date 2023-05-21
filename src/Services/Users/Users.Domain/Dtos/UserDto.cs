namespace Users.Domain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfRegister { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string GithubUsername { get; set; }
    }
}
