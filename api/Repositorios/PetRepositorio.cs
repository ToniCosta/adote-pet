using Adotepet.Api.ViewModels;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Repositorios
{
    public class PetRepositorio : RepositorioBase
    {
        public PetRepositorio(MySqlConnection connection) : base(connection) { }

        public int CriarPet(CriarPetViewModel viewModel, int entidadeId, string foto)
        {
            var query = "insert into pets(entidade_id, nome, cor, tamanho_pelo, tipo_animal_id, raca_id, porte, peso, idade, comportamento, localizacao, descricao, foto) " +
                "values (@entidade_id, @nome, @cor, @tamanho_pelo, @tipo_animal_id, @raca_id, @porte, @peso, @idade, @comportamento, @localizacao, @descricao, @foto)";

            return ExecuteInsert(
                query,
                new Tuple<string, object?>[] {
                        new("@entidade_id", entidadeId),
                        new("@nome", viewModel.Nome),
                        new("@cor", viewModel.Cor),
                        new("@tamanho_pelo", viewModel.TamanhoPelo),
                        new("@tipo_animal_id", viewModel.TipoAnimalId),
                        new("@raca_id", viewModel.RacaId),
                        new("@porte", viewModel.Porte),
                        new("@peso", viewModel.Peso),
                        new("@idade", viewModel.Idade),
                        new("@comportamento", viewModel.Comportamento),
                        new("@localizacao", viewModel.Localizacao),
                        new("@descricao", viewModel.Descricao),
                        new("@foto", foto)
                }
            );
        }
    }
}
