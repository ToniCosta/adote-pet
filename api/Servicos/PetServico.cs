using Adotepet.Api.Models;
using Adotepet.Api.Repositorios;
using Adotepet.Api.ViewModels;

namespace Adotepet.Api.Servicos
{
    public class PetServico
    {
        private readonly PetRepositorio _repositorio;
        public PetServico(PetRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int CriarPet(CriarPetViewModel viewModel, string path, int entidadeId) 
        {
            var savedAs = $"{entidadeId}/pets/{Guid.NewGuid()}{Path.GetExtension(viewModel.Image.FileName)}";
            var pathCompleto = Path.Combine(path, savedAs);
            var dir = Path.GetDirectoryName(pathCompleto);
            if (!Directory.Exists(dir)) 
            {
                Directory.CreateDirectory(dir);
            }

            using (Stream fileStream = new FileStream(pathCompleto, FileMode.Create))
            {
                viewModel.Image.CopyTo(fileStream);
            }
            GeolocationService.BuscarGeolocalizacao(viewModel.Localizacao, out var lat, out var lng);
            return _repositorio.CriarPet(viewModel, entidadeId, savedAs, lat, lng);
        }

        public IEnumerable<Pet> ListarPetsEntidade(int entidadeId)
        {
            return _repositorio.ListarPetsEntidade(entidadeId);
        }

        public IEnumerable<Pet> ListarPetsTutor(int tutorId)
        {
            return _repositorio.ListarPetsTutor(tutorId);
        }

        public Pet? BuscarPet(int petId, int? entidadeId)
        {
            return _repositorio.BuscarPet(petId, entidadeId);
        }

        public IEnumerable<Pet> BuscarPets(string filtro, decimal? lat, decimal? lng)
        {
            return _repositorio.BuscarPets(filtro, lat, lng);
        }
    }
}
