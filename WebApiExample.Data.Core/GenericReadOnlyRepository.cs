using System.Collections.Generic;
using System.Data.Odbc;
using WebApiExample.Domain.Core;
using Dapper;
using System.Linq;

namespace WebApiExample.Data.Core
{
    public class GenericReadOnlyRepository<TAggregate, TId> : IReadOnlyRepository<TAggregate, TId> where TAggregate : IAggregateRoot
    {
        private readonly string _tableName;
        private readonly string _connectionString;

        public GenericReadOnlyRepository(string tableName, string connectionString)
        {
            _tableName = tableName;
            _connectionString = connectionString;
        }

        public TAggregate Find(TId id)
        {
            using (var connection = new OdbcConnection(_connectionString))
            {
                connection.Open();
                return connection
                    .QuerySingleOrDefault<TAggregate>($"select * from {_tableName} where id=@Id", new { Id = id });
            }
        }

        public IEnumerable<TAggregate> FindAll()
        {
            using (var connection = new OdbcConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<TAggregate>($"select * from {_tableName}");
            }
        }

        public IEnumerable<TAggregate> Find(string query, dynamic filter)
        {
            using (var connection = new OdbcConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<TAggregate>($"select * from {_tableName} where {query}", (object)filter);
            }
        }
    }
}
