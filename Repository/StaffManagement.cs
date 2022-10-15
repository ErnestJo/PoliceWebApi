using Dapper;
using Newtonsoft.Json;
using policeWebApi.Constants;
using policeWebApi.Interface;
using policeWebApi.Model;
using policeWebApi.Model.staff.request;
using policeWebApi.Model.staff.response;
using policeWebApi.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Repository
{
    public class StaffManagement : IStaffManagement
    {
        public StaffManagement(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        private readonly IDapperRepository _dapper;


        public async Task<GeneralResponse> AddStaff(addStaff param)
        {
            try
            {
                var dp_params = new DynamicParameters();
                dp_params.Add("staff_fname", param.staff_fname, DbType.String);
                dp_params.Add("staff_mname", param.staff_mname, DbType.String); 
                dp_params.Add("staff_lname", param.staff_lname, DbType.String);
                dp_params.Add("email", param.email, DbType.String);
                dp_params.Add("gender", param.gender, DbType.Int64);
                dp_params.Add("phone_number", param.phone_number, DbType.String);
                dp_params.Add("staff_role", param.staff_role, DbType.Int32);
                dp_params.Add("staff_title", param.staff_role, DbType.Int32);
                dp_params.Add("martial_status", param.staff_role, DbType.Int32);

                Task<GeneralAddResponse> result = await Task.FromResult(_dapper.execute_QuerySingleOrDefaultAsync<GeneralAddResponse>(StoredProcedure.addStaff
                    , dp_params));

                GeneralResponse responseTemp = new GeneralResponse();


                GeneralAddResponse results = (GeneralAddResponse)await result;
                if (results.code == 999)
                {
                    responseTemp.Code = Codes.General_failure;
                    responseTemp.Message = CustomeSMS.failinsert;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    GeneralResponse resdt = JsonConvert.DeserializeObject<GeneralResponse>(sdt);
                    return resdt;
                }
                else
                {
                    responseTemp.Code = Codes.SUCCESS;
                    responseTemp.Message = CustomeSMS.Success;
                    responseTemp.Data = (GeneralAddResponse)await result;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    GeneralResponse resdt = JsonConvert.DeserializeObject<GeneralResponse>(sdt);
                    return resdt;
                }


            }

            catch (Exception ex)
            {
                GeneralResponse responseTemp = new GeneralResponse();
                responseTemp.Code = Codes.General_failure;
                responseTemp.Message = ex.Message;

                string sdt = JsonConvert.SerializeObject(responseTemp);
                GeneralResponse resdt = JsonConvert.DeserializeObject<GeneralResponse>(sdt);
                return resdt;
            }
        }

        public async Task<ResponseGetStaff> GetAllStaffs()
        {
            try
            {


                Task<IEnumerable<GetStaffs>> result = await Task.FromResult(_dapper.execute_QueryAsync<GetStaffs>(StoredProcedure.getStaff
                    , null));
                var data = (List<GetStaffs>)await result;

                if (result.Result == null || data.Count == 0)
                {
                    ResponseGetStaff responseTemp = new ResponseGetStaff();
                    responseTemp.Code = Codes.N0_Data_Found;
                    responseTemp.Message = CustomeSMS.NoData;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    ResponseGetStaff resdt = JsonConvert.DeserializeObject<ResponseGetStaff>(sdt);
                    return resdt;

                }
                else
                {
                    ResponseGetStaff responseTemp = new ResponseGetStaff();
                    responseTemp.Code = Codes.SUCCESS;
                    responseTemp.Message = CustomeSMS.Success;
                    responseTemp.Data = (List<GetStaffs>)await result;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    ResponseGetStaff resdt = JsonConvert.DeserializeObject<ResponseGetStaff>(sdt);
                    return resdt;

                }
            }
            catch (Exception ex)
            {

                ResponseGetStaff responseTemp = new ResponseGetStaff();
                responseTemp.Code = Codes.General_failure;
                responseTemp.Message = ex.Message;

                string sdt = JsonConvert.SerializeObject(responseTemp);
                ResponseGetStaff resdt = JsonConvert.DeserializeObject<ResponseGetStaff>(sdt);
                return resdt;
            }

        }

        public async Task<GeneralResponse> UpdateStaff(EditStaff param)
        {
            try
            {
                var dp_params = new DynamicParameters();
                dp_params.Add("staff_id", param.staff_id, DbType.Int32);
                dp_params.Add("staff_fname", param.staff_fname, DbType.String);
                dp_params.Add("staff_mname", param.staff_mname, DbType.String);
                dp_params.Add("staff_lname", param.staff_lname, DbType.String);
                dp_params.Add("email", param.email, DbType.String);
                dp_params.Add("gender", param.gender, DbType.Int64);
                dp_params.Add("phone_number", param.phone_number, DbType.String);
                dp_params.Add("staff_role", param.staff_role, DbType.Int32);
                dp_params.Add("staff_title", param.staff_role, DbType.Int32);
                dp_params.Add("martial_status", param.staff_role, DbType.Int32);

                Task<GeneralAddResponse> result = await Task.FromResult(_dapper.execute_QuerySingleOrDefaultAsync<GeneralAddResponse>(StoredProcedure.updateStaff
                    , dp_params));

                GeneralResponse responseTemp = new GeneralResponse();


                GeneralAddResponse results = (GeneralAddResponse)await result;
                if (results.code == 999)
                {
                    responseTemp.Code = Codes.General_failure;
                    responseTemp.Message = CustomeSMS.failinsert;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    GeneralResponse resdt = JsonConvert.DeserializeObject<GeneralResponse>(sdt);
                    return resdt;
                }
                else
                {
                    responseTemp.Code = Codes.SUCCESS;
                    responseTemp.Message = CustomeSMS.Success;
                    responseTemp.Data = (GeneralAddResponse)await result;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    GeneralResponse resdt = JsonConvert.DeserializeObject<GeneralResponse>(sdt);
                    return resdt;
                }


            }

            catch (Exception ex)
            {
                GeneralResponse responseTemp = new GeneralResponse();
                responseTemp.Code = Codes.General_failure;
                responseTemp.Message = ex.Message;

                string sdt = JsonConvert.SerializeObject(responseTemp);
                GeneralResponse resdt = JsonConvert.DeserializeObject<GeneralResponse>(sdt);
                return resdt;
            }

        }

        public async Task<ResponseGetStaff> GetSingleStaff(ById param)
        {
            try
            {
                var dp_params = new DynamicParameters();
                dp_params.Add("id", param.id, DbType.Int32);

                Task<IEnumerable<GetStaffs>> result = await Task.FromResult(_dapper.execute_QueryAsync<GetStaffs>(StoredProcedure.getStaffById
                    , dp_params));
                var data = (List<GetStaffs>)await result;

                if (result.Result == null )
                {
                    ResponseGetStaff responseTemp = new ResponseGetStaff();
                    responseTemp.Code = Codes.N0_Data_Found;
                    responseTemp.Message = CustomeSMS.NoData;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    ResponseGetStaff resdt = JsonConvert.DeserializeObject<ResponseGetStaff>(sdt);
                    return resdt;

                }
                else
                {
                    ResponseGetStaff responseTemp = new ResponseGetStaff();
                    responseTemp.Code = Codes.SUCCESS;
                    responseTemp.Message = CustomeSMS.Success;
                    responseTemp.Data = (List<GetStaffs>)await result;

                    string sdt = JsonConvert.SerializeObject(responseTemp);
                    ResponseGetStaff resdt = JsonConvert.DeserializeObject<ResponseGetStaff>(sdt);
                    return resdt;

                }
            }
            catch (Exception ex)
            {

                ResponseGetStaff responseTemp = new ResponseGetStaff();
                responseTemp.Code = Codes.General_failure;
                responseTemp.Message = ex.Message;

                string sdt = JsonConvert.SerializeObject(responseTemp);
                ResponseGetStaff resdt = JsonConvert.DeserializeObject<ResponseGetStaff>(sdt);
                return resdt;
            }

        }
    }
}
