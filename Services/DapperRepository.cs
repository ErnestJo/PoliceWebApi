using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Connection;

namespace policeWebApi.Services
{
    public class DapperRepository: IDapperRepository
    {
        private readonly IConfiguration _configuration;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<T>> execute_QueryAsync<T>(string query, DynamicParameters parameters)
        {
            IEnumerable<T> result;
            using (var database_connection = new SqlConnection(_configuration.GetConnectionString(Conn.DBConnName)))
            {
                try
                {
                    database_connection.Open();
                    result = await database_connection.QueryAsync<T>(
                        query, parameters, commandType: CommandType.StoredProcedure
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            };
            return result;
        }

    }
}
