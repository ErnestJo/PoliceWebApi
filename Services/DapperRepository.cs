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


        public List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Conn.DBConnName));
            return db.Query<T>(query, sp_params, commandType: commandType).ToList();
        }



        public List<T> execute_sp<T>(string query, DynamicParameters parameters)
        {
            List<T> result;
            using (IDbConnection database_connection = new SqlConnection(_configuration.GetConnectionString(Conn.DBConnName)))
            {
                if (database_connection.State == ConnectionState.Closed)
                    database_connection.Open();
                using var transaction = database_connection.BeginTransaction();
                try
                {
                    result = database_connection.Query<T>(query, parameters, commandType: CommandType.StoredProcedure, transaction: transaction).ToList();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            };
            return result;
        }

        public T execute_sp2<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(Conn.DBConnName)))
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                using var transaction = dbConnection.BeginTransaction();
                try
                {
                    dbConnection.Query<T>(query, sp_params, commandType: commandType, transaction: transaction);
                    result = sp_params.Get<T>("retVal"); //get output parameter value
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            };
            return result;
        }

        public async Task<T> execute_QuerySingleOrDefaultAsync<T>(string query, DynamicParameters parameters)
        {
            T result;
            using (var database_connection = new SqlConnection(_configuration.GetConnectionString(Conn.DBConnName)))
            {
                try
                {
                    database_connection.Open();
                    result = await database_connection.QuerySingleOrDefaultAsync<T>(
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

        public async Task<int> execute_ExecuteAsync<T>(string query, DynamicParameters parameters)
        {
            int result;
            using (var database_connection = new SqlConnection(_configuration.GetConnectionString(Conn.DBConnName)))
            {
                try
                {
                    database_connection.Open();
                    result = await database_connection.ExecuteAsync(
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
