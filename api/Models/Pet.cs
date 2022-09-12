namespace Adotepet.Api.Models
{
    public class Pet
    {
		public int Id { get; set; }
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
    }
}
