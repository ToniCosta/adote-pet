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
                var query = "insert into usuarios(nome, sobrenome, telefone, email, senha, tipo, cadastro_preenchido) values (@nome, @sobrenome, @telefone, @email, MD5(@senha), @tipo, false)";

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

        
        public void AtualizaTutor(Tutor model, int usuarioId, int tutorId)
        {
            try
            {
                BeginTransaction();
                var query = "update tutores set idade = @idade, sexo = @sexo, estado_civil = @estado_civil, rg = @rg, cpf = @cpf, qtd_pessoas_reside = @qtd_pessoas_reside, " +
                    " logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, uf = @uf, cep = @cep, " +
                    " possui_area_lazer = @possui_area_lazer, veterinario_proximo = @veterinario_proximo, tipo_residencia = @tipo_residencia, tipo_animal_id = @tipo_animal_id, " +
                    " raca_id = @raca_id, porte = @porte, motivo_adocao = @motivo_adocao, latitude = @latitude, longitude = @longitude " +
                    " where id = @id";
                var parametros = new DynamicParameters();
                parametros.Add("@idade", model.Idade);
                parametros.Add("@sexo",model.Sexo);
                parametros.Add("@estado_civil", model.EstadoCivil);
                parametros.Add("@rg", model.Rg);
                parametros.Add("@cpf", model.Cpf);
                parametros.Add("@qtd_pessoas_reside", model.QtdPessoasReside);
                parametros.Add("@logradouro", model.Logradouro);
                parametros.Add("@numero", model.Numero);
                parametros.Add("@complemento", model.Complemento);
                parametros.Add("@bairro", model.Bairro);
                parametros.Add("@cidade", model.Cidade);
                parametros.Add("@uf", model.Uf);
                parametros.Add("@cep", model.Cep);

                parametros.Add("@possui_area_lazer", model.PossuiAreaLazer);
                parametros.Add("@veterinario_proximo", model.VeterinarioProximo);
                parametros.Add("@tipo_residencia", model.TipoResidencia);
                parametros.Add("@tipo_animal_id", model.TipoAnimalId);

                parametros.Add("@raca_id", model.RacaId);
                parametros.Add("@porte", model.Porte);
                parametros.Add("@motivo_adocao", model.MotivoAdocao);
                parametros.Add("@latitude", model.Latitude);
                parametros.Add("@longitude", model.Longitude);
                parametros.Add("@id", tutorId);
                Conn.Execute(query, parametros, Transaction);

                query = "update usuarios set cadastro_preenchido = true where id = @id";
                parametros = new DynamicParameters();
                parametros.Add("@id", usuarioId);
                Conn.Execute(query, parametros, Transaction);
                Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public Tutor? BuscarDadosTutor(int tutorId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@id", tutorId);
            return
                Conn.Query<Tutor>(
                        "select u.*, r.descricao as raca, t.descricao as tipo_animal " +
                        " from tutores u " +
                        " left join racas_animais r on r.id = u.raca_id " +
                        " left join tipos_animais t on t.id = u.tipo_animal_id " +
                        " where u.id = @id ",
                    parametros, transaction: Transaction)
                .FirstOrDefault();
        }
    }
}
