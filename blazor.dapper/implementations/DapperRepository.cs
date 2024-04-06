using blazor.models.Configs;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace blazor.dapper.implementations
{
    public class DapperRepository : IDapperRepository
    {
        #region Object declaration and Constructor

        private IDbConnection Connection;
        private int? CommandTimeout = 0;
        private IDbTransaction Transaction = null;

        /// <summary>
        ///  Create a GenericRepository for Dapper
        /// </summary>
        /// <param name="ConnectionStringsOptions"></param>
        public DapperRepository(IOptions<ConnectionConfigs> ConnectionStringsOptions)
        {
            this.Connection = new SqlConnection(ConnectionStringsOptions.Value.DefaultConnection);
        }

        #endregion

        #region Add or Update single or multiple records.

        public int AddOrUpdate<T>(string query, T entity, CommandType type = CommandType.StoredProcedure)
        {
            if (Connection == null)
                throw new ArgumentNullException(nameof(entity), $"The parameter {nameof(entity)} can't be null");
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateObject(entity, nameof(entity));
            int result = Connection.Execute(query, entity, Transaction, CommandTimeout, type);
            return result;
        }

        public int AddOrUpdate<T>(string query, IEnumerable<T> entities, CommandType type = CommandType.StoredProcedure)
        {
            if (Connection == null)
                throw new ArgumentNullException(nameof(entities), $"The parameter {nameof(entities)} can't be null");
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateEnumerable(entities, nameof(entities));
            int result = Connection.Execute(query, entities, Transaction, CommandTimeout, type);
            return result;
        }

        public Task<int> AddOrUpdateAsync<T>(string query, T entity, CommandType type = CommandType.StoredProcedure)
        {
            if (Connection == null)
                throw new ArgumentNullException(nameof(entity), $"The parameter {nameof(entity)} can't be null");
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateObject(entity, nameof(entity));
            var result = Connection.ExecuteAsync(query, entity, Transaction, CommandTimeout, type);
            return result;
        }

        public Task<int> AddOrUpdateAsync<T>(string query, IEnumerable<T> entities, CommandType type = CommandType.StoredProcedure)
        {
            if (Connection == null)
                throw new ArgumentNullException(nameof(entities), $"The parameter {nameof(entities)} can't be null");
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateEnumerable(entities, nameof(entities));
            var result = Connection.ExecuteAsync(query, entities, Transaction, CommandTimeout, type);
            return result;
        }
        #endregion

        #region Get record by Id.
        public T Find<T>(string query, object primarykeyFields, CommandType type = CommandType.StoredProcedure)
        {
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateObject(primarykeyFields, nameof(primarykeyFields));
            return Connection.QueryFirstOrDefault<T>(query, primarykeyFields, Transaction, CommandTimeout, type);
        }

        public Task<T> FindAsync<T>(string query, object primarykeyFields, CommandType type = CommandType.StoredProcedure)
        {
            return Task.Run(() =>
            {
                return Find<T>(query, primarykeyFields, type);
            });
        }
        #endregion

        #region Get tables
        public List<T> GetTable<T>(string query, CommandType type = CommandType.StoredProcedure)
        {
            ParameterValidator.ValidateString(query, nameof(query));
            //ParameterValidator.ValidateObject(parameters, nameof(parameters));
            return Connection.Query<T>(query, type).ToList();
        }

        public Task<IEnumerable<T>> GetTableAsync<T>(string query, CommandType type = CommandType.StoredProcedure)
        {
            ParameterValidator.ValidateString(query, nameof(query));
            //ParameterValidator.ValidateObject(parameters, nameof(parameters));
            return Connection.QueryAsync<T>(query, type);
        }
        #endregion

        #region Get more than one tables
        public SqlMapper.GridReader GetTables(string query, object parameters, CommandType type = CommandType.StoredProcedure)
        {
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateObject(parameters, nameof(parameters));
            return Connection.QueryMultiple(query, parameters, Transaction, CommandTimeout, type);
        }
        public Task<SqlMapper.GridReader> GetTablesAsync(string query, object parameters, CommandType type = CommandType.StoredProcedure)
        {
            ParameterValidator.ValidateString(query, nameof(query));
            ParameterValidator.ValidateObject(parameters, nameof(parameters));
            return Connection.QueryMultipleAsync(query, parameters, Transaction, CommandTimeout, type);
        }
        #endregion

        #region House Keeping
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();

                Connection.Dispose();
                Transaction = null;
                CommandTimeout = null;
            }
        }

        #endregion
    }
}