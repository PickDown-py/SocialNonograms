using System.ComponentModel.DataAnnotations;

namespace SN.Model
{
    public class AuthenticationUserModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}