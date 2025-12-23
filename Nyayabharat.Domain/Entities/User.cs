using Nyayabharat.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nyayabharat.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }   // PK

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public UserType UserType { get; set; } // matches DB (int)

        public string PasswordHash { get; set; } = null!;
    }
}
