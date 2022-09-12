using Adotepet.Api.Models;
using Adotepet.Api.Repositorios;
using Adotepet.Api.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Adotepet.Api.Servicos
{
    public class AccountServico
    {
        private readonly UsuariosRepositorio _usuarioRepositorio;
        public AccountServico(UsuariosRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public LoginResponse FazerLoginGerarToken(LoginViewModel viewModel) 
        {
            var usuario = _usuarioRepositorio.BuscarusuarioPorEmailSenha(viewModel.Email, viewModel.Senha);
            if (usuario == null)
            {
                throw new Exception("Usuário ou senha não encontrados");
            }

            List<Claim> claims = new()
            {
                new Claim("Id", usuario.Id.ToString()),
                new Claim("EntidadeId", usuario.EntidadeId?.ToString() ?? "0"),
                new Claim("TutorId", usuario.TutorId?.ToString() ?? "0"),
                new(ClaimTypes.Role, usuario.Tipo ?? "")
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("L//aa69/un5Nf+yU9/unf+X-");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://adotepet.app",
                Audience = "https://adotepet.app/login",
                Subject = new ClaimsIdentity(new GenericIdentity(usuario.Email ?? "", "Login"), claims),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                ),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponse()
            {
                Token = tokenHandler.WriteToken(token),
                Nome = usuario.Nome,
                Role = usuario.Tipo,
                CadastroCompleto = usuario.CadastroPreenchido
            };
        }

        private void ChecarEmailEmUso(string? email) 
        {
            if (_usuarioRepositorio.BuscarusuarioPorEmail(email) != null)
            {
                throw new Exception("Email já cadastrado");
            }
        }

        public void CriarUsuarioTutor(CriarContaViewModel dadosConta) 
        {
            ChecarEmailEmUso(dadosConta.Email);
            _usuarioRepositorio.CadastrarUsuarioTutor(dadosConta);
        }

        public void CriarUsuarioRepresentante(CriarContaViewModel dadosConta)
        {
            ChecarEmailEmUso(dadosConta.Email);
            _usuarioRepositorio.CadastrarUsuarioRepresentante(dadosConta);
        }

        public void AtualizaTutor(Tutor model, int usuarioId, int tutorId)
        {
            GeolocationService.BuscarGeolocalizacao($"{model.Logradouro}, {model.Numero}. {model.Cidade}-{model.Uf} ", out var lat, out var lng);
            model.Latitude = lat;
            model.Longitude = lng;
            _usuarioRepositorio.AtualizaTutor(model, usuarioId, tutorId);
        }

        public Tutor? BuscarDadosTutor(int tutorId)
        {
            return _usuarioRepositorio.BuscarDadosTutor(tutorId);
        }
    }
}
