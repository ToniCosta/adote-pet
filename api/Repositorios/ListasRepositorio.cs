using Adotepet.Api.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Repositorios
{
    public class ListasRepositorio : RepositorioBase
    {
        public ListasRepositorio(MySqlConnection connection) : base(connection) { }

        public IEnumerable<Cidade> BuscarCidades(string? cidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@cidade", "%" + cidade?.ToUpper() + "%");
            return 
                Conn.Query<Cidade>("select * from cidades where upper(nome) like @cidade order by nome limit 30",
                    parametros, transaction: Transaction)
                .ToList();
        }

        public IEnumerable<TipoAnimal> ListarTiposAnimais()
        {
            return
                Conn.Query<TipoAnimal>("select * from tipos_animais order by descricao", transaction: Transaction)
                .ToList();
        }

        public IEnumerable<Raca> BuscarRacas(int tipoAnimalId, string raca)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@descricao", "%" + raca?.ToUpper() + "%");
            parametros.Add("@tipoAnimalId", tipoAnimalId);
            return
                Conn.Query<Raca>("select * from racas_animais where upper(descricao) like @descricao and tipo_animal_id = @tipoAnimalId order by descricao limit 30",
                    parametros, transaction: Transaction)
                .ToList();
        }
    }
}
