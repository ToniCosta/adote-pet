namespace Adotepet.Api.ViewModels
{

    public class CriarPetViewModel
    {
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Cor { get; set; }
		public string? TamanhoPelo { get; set; }
		public int TipoAnimalId { get; set; }
		public int RacaId { get; set; }
		public string? Porte { get; set; }
		public int Peso { get; set; }
		public int Idade { get; set; }
		public string? Comportamento { get; set; }
		public string? Descricao { get; set; }
		public string? Localizacao { get; set; }
		public IFormFile? Image { get; set; }
	}

}
