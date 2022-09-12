using Adotepet.Api.Models;
using Adotepet.Api.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Repositorios
{
    public class UsuariosRepositorio : RepositorioBase
    {
        public UsuariosRepositorio(MySqlConnection connection) : base(connection) { }

        public Usuario? BuscarusuarioPorEmail(string? email)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@email", email?.ToUpper());
            return 
                Conn.Query<Usuario>("select * from usuarios where upper(email) = @email",
                    parametros, transaction: Transaction)
                .FirstOrDefault();
        }

        public Usuario? BuscarusuarioPorEmailSenha(string? email, string? plainPassword)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@email", email?.ToUpper());
            parametros.Add("@senha", plainPassword);
            return
                Conn.Query<Usuario>("select u.*, t.id as tutor_id, e.id as entidade_id from usuarios u " +
                " left join tutores t on t.usuario_id = u.id " +
                " left join entidades e on e.usuario_id = u.id " +
                " where upper(email) = @email and senha = MD5(@senha)",
                    parametros, transaction: Transaction)
                .FirstOrDefault();
        }

        private int CadastrarUsuario(CriarContaViewModel viewModel, string tipo)
        {
            try
            {
                BeginTransaction();
                var query = "insert into usuarios(nome, sobrenome, telefone, email, senha, tipo) values (@nome, @sobrenome, @telefone, @email, MD5(@senha), @tipo)";

                var id = ExecuteInsert(
                    query,
                    new Tuple<string, object?>[] {
                        new("@nome", viewModel.Nome),
                        new("@sobrenome", viewModel.Sobrenome),
                        new("@telefone", viewModel.Celular),
                        new("@email", viewModel.Email),
                        new("@senha", viewModel.Senha),
                        new("@tipo", tipo)
                    }
                );

                query = $"insert into {(tipo == Usuario.TIPO_TUTOR ? "tutores" : "entidades")} (usuario_id) values (@usuarioId)";
                ExecuteInsert(query, new Tuple<string, object?>[] {
                        new("@usuarioId", id)
                    });
                Commit();

                return id;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public int CadastrarUsuarioTutor(CriarContaViewModel viewModel) {
            return CadastrarUsuario(viewModel, Usuario.TIPO_TUTOR);
        }

        public int CadastrarUsuarioRepresentante(CriarContaViewModel viewModel)
        {
            return CadastrarUsuario(viewModel, Usuario.TIPO_INSTITUICAO);
        }
    }
}
