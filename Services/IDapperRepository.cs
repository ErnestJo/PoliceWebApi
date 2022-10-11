using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Services
{
   public   interface IDapperRepository
    {
        public Task<IEnumerable<T>> execute_QueryAsync<T>(string query, DynamicParameters parameters);

        public Task<T> execute_QuerySingleOrDefaultAsync<T>(string query, DynamicParameters parameters);
        public Task<int> execute_ExecuteAsync<T>(string query, DynamicParameters parameters);

        T execute_sp2<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
        public List<T> execute_sp<T>(string query, DynamicParameters parameters);
        List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
    }
}
