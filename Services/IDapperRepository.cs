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
    }
}
