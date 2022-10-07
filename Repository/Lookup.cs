using Newtonsoft.Json;
using policeWebApi.Constants;
using policeWebApi.Interface;
using policeWebApi.Model.Lookup;
using policeWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Repository
{
    public class LookUp : ILookup
    {
        public LookUp(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        private readonly IDapperRepository _dapper;

     
        public async Task<ResponseLookup> roleLookup()
        {
            try
            {
                Task<IEnumerable<Lookup>> result = await Task.FromResult(_dapper.execute_QueryAsync<Lookup>(StoredProcedure.getRoles
                    , null));
                var data = (List<Lookup>)await result;

                if (result.Result == null || data.Count == 0)
                {
                    ResponseLookup responseTemp = new ResponseLookup();
                    responseTemp.Code = Codes.N0_Data_Found;
                    responseTemp.Message = CustomeSMS.NoData;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    ResponseLookup resdt = JsonConvert.DeserializeObject<ResponseLookup>(sdt);
                    return resdt;

                }
                else
                {
                    ResponseLookup responseTemp = new ResponseLookup();
                    responseTemp.Code = Codes.SUCCESS;
                    responseTemp.Message = CustomeSMS.Success;
                    responseTemp.Data = (List<Lookup>)await result;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    ResponseLookup resdt = JsonConvert.DeserializeObject<ResponseLookup>(sdt);
                    return resdt;

                }
            }
            catch (Exception ex)
            {
               
                ResponseLookup responseTemp = new ResponseLookup();
                responseTemp.Code = Codes.General_failure;
                responseTemp.Message = ex.Message;

                string sdt = JsonConvert.SerializeObject(responseTemp);
                ResponseLookup resdt = JsonConvert.DeserializeObject<ResponseLookup>(sdt);
                return resdt;
            }

        }

    }
}
