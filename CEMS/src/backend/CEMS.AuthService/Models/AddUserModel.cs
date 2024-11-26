using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CEMS.AuthService.Models
{
    public class AddUserModel
    {
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [Required]
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [JsonPropertyName("password")]
        public string Password { get; set; } // Plain text password, hashed later
    }
}
