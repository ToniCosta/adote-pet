namespace Adotepet.Api.Models
{
    public class Tutor
    {
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int? Idade { get; set; }
		public string? Sexo { get; set; }
		public string? EstadoCivil { get; set; }
		public string? Rg { get; set; }
		public string? Cpf { get; set; }
		public int? QtdPessoasReside { get; set; }

		public string? Logradouro { get; set; }
		public string? Numero { get; set; }
		public string? Complemento { get; set; }
		public string? Bairro { get; set; }
		public string? Cidade { get; set; }
		public string? Uf { get; set; }
		public string? Cep { get; set; }

		public string? PossuiAreaLazer { get; set; }
		public string? VeterinarioProximo { get; set; }
		public string? TipoResidencia { get; set; }

		public int? TipoAnimalId { get; set; }
		public string? TipoAnimal { get; set; }
		public int? RacaId { get; set; }
		public string? Raca { get; set; }
		public string? Porte { get; set; }
		public string? MotivoAdocao { get; set; }
		public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
