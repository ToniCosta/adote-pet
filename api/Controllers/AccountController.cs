using Adotepet.Api.Repositorios;
using Adotepet.Api.Servicos;
using Adotepet.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

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
                () => 
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    return servico.FazerLoginGerarToken(model);
                }
            );
        }

        [HttpPost]
        [Route("criar-conta-tutor")]
        public IActionResult CriarContaTutor([FromBody] CriarContaViewModel model)
        {
            return Executar(
                () =>
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    servico.CriarUsuarioTutor(model);
                    return servico.FazerLoginGerarToken(new LoginViewModel() { Email = model.Email, Senha = model.Senha });
                }
            );
        }

        [HttpPost]
        [Route("criar-conta-representante")]
        public IActionResult CriarContaRepresentante([FromBody] CriarContaViewModel model)
        {
            return Executar(
                () =>
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    servico.CriarUsuarioRepresentante(model);
                    return servico.FazerLoginGerarToken(new LoginViewModel() { Email = model.Email, Senha = model.Senha });
                }
            );
        }

    }
}
