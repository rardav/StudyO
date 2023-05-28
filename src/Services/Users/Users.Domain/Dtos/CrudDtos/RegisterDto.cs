﻿using System.ComponentModel.DataAnnotations;

namespace Users.Domain.Dtos.CrudDtos
{
    public record RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
