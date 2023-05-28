using System.ComponentModel.DataAnnotations;

namespace Users.Domain.Dtos.CrudDtos
{
    public record LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

