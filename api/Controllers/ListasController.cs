using Adotepet.Api.Repositorios;
using Adotepet.Api.Servicos;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Controllers
{
    [Route("/api/listas")]
    public class ListasController : ControllerApi
    {
        public ListasController(MySqlConnection connection) : base(connection) { }

        [HttpGet]
        [Route("cidades")]
        public IActionResult Cidades([FromQuery] string cidade) 
        {
            return Executar(
                () =>
                {
                    var servico = new ListasServico(new ListasRepositorio(_connection));
                    return servico.BuscarCidades(cidade);
                }
            );
        }

        [HttpGet]
        [Route("tipos-animais")]
        public IActionResult TiposAnimais()
        {
            return Executar(
                () =>
                {
                    var servico = new ListasServico(new ListasRepositorio(_connection));
                    return servico.ListarTiposAnimais();
                }
            );
        }

        [HttpGet]
        [Route("racas")]
        public IActionResult Racas([FromQuery] string raca, [FromQuery] int tipoAnimalId)
        {
            return Executar(
                () =>
                {
                    var servico = new ListasServico(new ListasRepositorio(_connection));
                    return servico.BuscarRacas(tipoAnimalId, raca);
                }
            );
        }
    }
}
