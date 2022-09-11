using Dapper;
using MySql.Data.MySqlClient;

namespace Adotepet.Api.Repositorios
{
    public abstract class RepositorioBase
    {
        protected readonly MySqlConnection Conn;
        private MySqlTransaction? _transaction = null;
        public RepositorioBase(MySqlConnection connection) 
        {
            Conn = connection;
        }

        protected MySqlTransaction Transaction => _transaction;

        protected void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = Conn.BeginTransaction();
            }
        }

        protected void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        protected void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        protected int LastInsertId()
        {
            return Conn.ExecuteScalar<int>("SELECT LAST_INSERT_ID()", transaction: _transaction);
        }

        protected int ExecuteInsert(string query, Tuple<string, object?>[] parametros) 
        {
            var parametrosDb = new DynamicParameters();
            foreach (var param in parametros)
            {
                parametrosDb.Add(param.Item1, param.Item2);
            }
            Conn.Execute(query, parametrosDb, _transaction);
            return LastInsertId();
        }
    }
}
