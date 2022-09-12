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

        [HttpGet]
        [Route("pets-entidade")]
        [Authorize(Roles = Usuario.TIPO_INSTITUICAO)]
        public IActionResult ListarEntidade()
        {
            return Executar(() => {
                return new PetServico(new PetRepositorio(_connection)).ListarPetsEntidade(GetEntidadeId());
            });
        }

        [HttpGet]
        [Route("buscar-pet-editar/{id}")]
        [Authorize(Roles = Usuario.TIPO_INSTITUICAO)]
        public IActionResult BuscarPetEditar([FromRoute] int id)
        {
            return Executar(() => {
                return new PetServico(new PetRepositorio(_connection)).BuscarPet(id, GetEntidadeId());
            });
        }

        [HttpGet]
        [Route("foto")]
        [AllowAnonymous]
        public IActionResult Criar([FromQuery] string foto)
        {
            try
            {
                var path = Path.Combine(_filePath, foto);
                if (!System.IO.File.Exists(path))
                {
                    return NotFound();
                }
                var bytes = System.IO.File.ReadAllBytes(path);
                _mimeTypeProvider.TryGetContentType(foto, out var contentType);
                return File(bytes, contentType ?? "application/octet-stream");
            }
            finally
            {
                _connection.Dispose();
            }
        }

        [HttpGet]
        [Route("buscar-pets")]
        public IActionResult BuscarPets([FromQuery] string filtro)
        {
            return Executar(() => {
                decimal? lat = null, lng = null;
                if (GetTutorId() > 0)
                {
                    var tutor = new AccountServico(new UsuariosRepositorio(_connection)).BuscarDadosTutor(GetTutorId());
                    lat = tutor?.Latitude;
                    lng = tutor?.Longitude;
                }
                return new PetServico(new PetRepositorio(_connection)).BuscarPets(filtro, lat, lng);
            });
        }
    }
}
