using Adotepet.Api.Models;
using Adotepet.Api.Repositorios;

namespace Adotepet.Api.Servicos
{
    public class ListasServico
    {
        private readonly ListasRepositorio _repositorio;
        public ListasServico(ListasRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Cidade> BuscarCidades(string nomeCidade)
        {
            return _repositorio.BuscarCidades(nomeCidade);
        }

        public IEnumerable<TipoAnimal> ListarTiposAnimais()
        {
            return _repositorio.ListarTiposAnimais();
        }

        public IEnumerable<Raca> BuscarRacas(int tipoAnimalId, string raca)
        {
            return _repositorio.BuscarRacas(tipoAnimalId, raca);
        }
    }
}
