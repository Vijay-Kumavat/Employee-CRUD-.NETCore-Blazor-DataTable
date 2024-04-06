using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace blazor.dapper
{
    public interface IDapperRepository : IDisposable
    {
        List<T> GetTable<T>(string query, CommandType type = CommandType.StoredProcedure);

        Task<IEnumerable<T>> GetTableAsync<T>(string query, CommandType type = CommandType.StoredProcedure);

        SqlMapper.GridReader GetTables(string query, object parameters, CommandType type = CommandType.StoredProcedure);

        Task<SqlMapper.GridReader> GetTablesAsync(string query, object parameters, CommandType type = CommandType.StoredProcedure);

        T Find<T>(string query, object primarykeyFields, CommandType type = CommandType.StoredProcedure);

        Task<T> FindAsync<T>(string query, object primarykeyFields, CommandType type = CommandType.StoredProcedure);

        int AddOrUpdate<T>(string query, T entity, CommandType type = CommandType.StoredProcedure);

        Task<int> AddOrUpdateAsync<T>(string query, T entity, CommandType type = CommandType.StoredProcedure);

        int AddOrUpdate<T>(string query, IEnumerable<T> entities, CommandType type = CommandType.StoredProcedure);

        Task<int> AddOrUpdateAsync<T>(string query, IEnumerable<T> entities, CommandType type = CommandType.StoredProcedure);
    }
}