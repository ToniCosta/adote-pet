using Adotepet.Api.Models;
using Adotepet.Api.Repositorios;
using Adotepet.Api.Servicos;
using Adotepet.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Controllers
{
    [Route("/api/pets")]
    public class PetsController : ControllerApi
    {
        private readonly string _filePath;
        public PetsController(MySqlConnection connection, IConfiguration config) : base(connection) 
        {
            _filePath = Path.Combine(config.GetValue<string>("FilesPath"));
        }

        [HttpPost]
        [Authorize(Roles = Usuario.TIPO_INSTITUICAO)]
        public IActionResult Criar([FromForm] CriarPetViewModel model) 
        {
            return Executar(() => {
                return new PetServico(new PetRepositorio(_connection)).CriarPet(model, _filePath, GetEntidadeId());
            });
        }
    }
}
