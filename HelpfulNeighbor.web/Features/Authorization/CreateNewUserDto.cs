﻿using System.ComponentModel.DataAnnotations;

namespace HelpfulNeighbor.web.Features.Authorization
{
    public class CreateNewUserDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(1)]
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}
