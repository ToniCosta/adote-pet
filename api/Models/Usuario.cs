namespace Adotepet.Api.Models
{
    public class Usuario
    {
        public const string TIPO_ADMIN = "ADMIN";
        public const string TIPO_TUTOR = "TUTOR";
        public const string TIPO_INSTITUICAO = "INSTITUICAO";

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }

        public int? EntidadeId { get; set; }
        public int? TutorId { get; set; }
        public bool CadastroPreenchido { get; set; }
    }
}
