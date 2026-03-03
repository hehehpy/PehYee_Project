using System.ComponentModel.DataAnnotations;

namespace PehYee_Project.Models
{
    public class Register
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}