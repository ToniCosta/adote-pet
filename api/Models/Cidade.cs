using System.Text.Json.Serialization;

namespace Adotepet.Api.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string? Uf { get; set; }
        [JsonIgnore]
        public string? Nome { get; set; }
        public string? Descricao => $"{Nome} - {Uf}";
    }
}
