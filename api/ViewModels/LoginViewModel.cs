using System.ComponentModel.DataAnnotations;

namespace Adotepet.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Senha { get; set; }
    }

    public class LoginResponse
    {
        public string? Token { get; set; }
    }
}
