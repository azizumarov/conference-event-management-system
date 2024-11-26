using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CEMS.AuthService.Models
{
    public class LoginUserModel
    {
        [Required]
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [JsonPropertyName("password")]
        public string Password { get; set; } // Plain text password, hashed later
    }
}
