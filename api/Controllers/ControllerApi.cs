using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Controllers
{
    public abstract class ControllerApi : ControllerBase
    {
        protected readonly MySqlConnection _connection;

        public ControllerApi(MySqlConnection connection)
        {
            _connection = connection;
        }

        protected IActionResult Executar<T, TOutput>(Func<T, TOutput> executeFunction, T input) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Verifique os campos obrigatórios");
            }
            try
            {
                var result = executeFunction(input);
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
    }
}
