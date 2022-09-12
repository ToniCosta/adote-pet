namespace Adotepet.Api.Models
{
    public class Pet
    {
		public const string STATUS_PARA_ADOCAO = "Para adoção";
		public const string STATUS_EM_PROCESSO_ADOCAO = "Em processo de adoção";
		public const string STATUS_ADOTADO = "Adotado";

		public int Id { get; set; }
		public string? Entidade { get; set; }
		public string? Nome { get; set; }
		public string? Cor { get; set; }
		public string? TamanhoPelo { get; set; }
		public int TipoAnimalId { get; set; }
		public string? TipoAnimal { get; set; }

		public int RacaId { get; set; }
		public string? Raca { get; set; }

		public string? Porte { get; set; }
		public int? Peso { get; set; }
        public int? Idade { get; set; }
        public string? Comportamento { get; set; }
        public string? Localizacao { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }

		public string? StatusPet { get; set; }
		public decimal? Latitude { get; set; }
		public decimal? Longitude { get; set; }
		public int? TutorId { get; set; }

	}
}
