using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Controllers
{
    public abstract class ControllerApi : ControllerBase
    {
        protected readonly MySqlConnection _connection;
        protected static FileExtensionContentTypeProvider _mimeTypeProvider = new FileExtensionContentTypeProvider();

        public ControllerApi(MySqlConnection connection)
        {
            _connection = connection;
        }

        protected IActionResult Executar<TOutput>(Func<TOutput> executeFunction) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Verifique os campos obrigatórios");
            }
            try
            {
                var result = executeFunction();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            finally
            {
                _connection.Dispose();
            }
        }

        protected int GetEntidadeId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "EntidadeId").Value ?? "0");
        }
    }
}
