using Dapper;
using Newtonsoft.Json;
using policeWebApi.Constants;
using policeWebApi.Interface;
using policeWebApi.Model.Account.rq;
using policeWebApi.Model.Account.rs;
using policeWebApi.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Repository
{
    public class Account : IAccount 
    {
        public Account(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        private readonly IDapperRepository _dapper;

        public async Task<ResponseLogin> Login(LoginRq param)
        {
            try
            {
                var dp_params = new DynamicParameters();
                dp_params.Add("staff_username", param.staff_username, DbType.String);
                dp_params.Add("staff_password", param.staff_password, DbType.String);

                Task<loginData> result = await Task.FromResult(_dapper.execute_QuerySingleOrDefaultAsync<loginData>(StoredProcedure.login
                    , dp_params));
              
                        ResponseLogin responseTemp = new ResponseLogin();
                     
                            loginData results = (loginData)await result;
                            if (results == null)
                            {
                                responseTemp.Code = Codes.N0_Data_Found;
                                responseTemp.Message = CustomeSMS.NoData;

                                string sdt = JsonConvert.SerializeObject(responseTemp);
                                ResponseLogin resdt = JsonConvert.DeserializeObject<ResponseLogin>(sdt);
                                return resdt;
                            }
                            else
                            {
                                responseTemp.Code = Codes.SUCCESS;
                                responseTemp.Message = CustomeSMS.Success;
                                responseTemp.Data = (loginData)await result;

                                string sdt = JsonConvert.SerializeObject(responseTemp);
                                ResponseLogin resdt = JsonConvert.DeserializeObject<ResponseLogin>(sdt);
                                return resdt;
                            }

            }
            catch (Exception ex)
            {

                ResponseLogin responseTemp = new ResponseLogin();
                responseTemp.Code = Codes.General_failure;
                responseTemp.Message = ex.Message;

                string sdt = JsonConvert.SerializeObject(responseTemp);
                ResponseLogin resdt = JsonConvert.DeserializeObject<ResponseLogin>(sdt);
                return resdt;
            }
        }

    }
}
