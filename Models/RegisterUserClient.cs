using System.ComponentModel.DataAnnotations;

namespace CinemasAPI.Models
{
    public class RegisterUserClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
