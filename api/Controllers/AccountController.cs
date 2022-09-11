using Adotepet.Api.Repositorios;
using Adotepet.Api.Servicos;
using Adotepet.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Controllers
{
    [Route("/api/account")]
    public class AccountController : ControllerApi
    {
        public AccountController(MySqlConnection connection) : base(connection) { }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            return Executar(
                (m) => 
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    return servico.FazerLoginGerarToken(m);
                }, 
                model
            );
        }

        [HttpPost]
        [Route("criar-conta-tutor")]
        public IActionResult CriarContaTutor([FromBody] CriarContaViewModel model)
        {
            return Executar(
                (m) =>
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    servico.CriarUsuarioTutor(m);
                    return true;
                },
                model
            );
        }

        [HttpPost]
        [Route("criar-conta-representante")]
        public IActionResult CriarContaRepresentante([FromBody] CriarContaViewModel model)
        {
            return Executar(
                (m) =>
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    servico.CriarUsuarioRepresentante(m);
                    return true;
                },
                model
            );
        }

    }
}
