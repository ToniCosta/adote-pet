using System.ComponentModel.DataAnnotations;

namespace Adotepet.Api.ViewModels
{
    public class CriarContaViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Celular { get; set; }
        [Required]
        public string? Senha { get; set; }
    }
}
