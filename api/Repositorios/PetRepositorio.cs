using Adotepet.Api.Models;
using Adotepet.Api.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Repositorios
{
    public class PetRepositorio : RepositorioBase
    {
        public PetRepositorio(MySqlConnection connection) : base(connection) { }

        public int CriarPet(CriarPetViewModel viewModel, int entidadeId, string foto, decimal? latitude, decimal? longitude)
        {
            var query = "insert into pets(entidade_id, nome, cor, tamanho_pelo, tipo_animal_id, raca_id, porte, peso, " +
                " idade, comportamento, localizacao, descricao, foto, status_pet, latitude, longitude) " +
                " values (@entidade_id, @nome, @cor, @tamanho_pelo, @tipo_animal_id, @raca_id, @porte, @peso, " +
                " @idade, @comportamento, @localizacao, @descricao, @foto, @status_pet, @latitude, @longitude)";

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
                        new("@foto", foto),
                        new("@status_pet", Pet.STATUS_PARA_ADOCAO),
                        new("@latitude", latitude),
                        new("@longitude", longitude)
                }
            );
        }

        public IEnumerable<Pet> ListarPetsEntidade(int entidadeId)
        {
            var query = "select p.*, r.descricao as raca, t.descricao as tipo_animal " +
                " from pets p " +
                " join racas_animais r on r.id = p.raca_id " +
                " join tipos_animais t on t.id = p.tipo_animal_id " +
                " where p.entidade_id = @entidade_id order by p.nome";
            var parametros = new DynamicParameters();
            parametros.Add("@entidade_id", entidadeId);
            return Conn
                .Query<Pet>(query, parametros)
                .ToList();
        }

        public Pet? BuscarPet(int petId, int? entidadeId)
        {
            var query = "select p.*, r.descricao as raca, t.descricao as tipo_animal " +
                " from pets p " +
                " join racas_animais r on r.id = p.raca_id " +
                " join tipos_animais t on t.id = p.tipo_animal_id " +
                " where p.id = @petId ";
            var parametros = new DynamicParameters();
            parametros.Add("@petId", petId);
            if (entidadeId.HasValue)
            {
                query += " and p.entidade_id = @entidadeId ";
                parametros.Add("@entidadeId", entidadeId);
            }
            query += " order by p.nome";
            
            return Conn
                .Query<Pet>(query, parametros)
                .FirstOrDefault();
        }
    }
}
