using Microsoft.AspNetCore.Mvc;
using policeWebApi.Interface;
using policeWebApi.Model;
using policeWebApi.Model.staff.request;
using policeWebApi.Model.staff.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StaffManagementController : ControllerBase
    {
        private readonly IStaffManagement _spconn;
        public StaffManagementController(IStaffManagement spconn)
        {
            _spconn = spconn;
        }

        [HttpPost(nameof(AddStaff))]
        public async Task<GeneralResponse> AddStaff(addStaff param)
        {
            try
            {
                if (param.staff_fname.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.staff_fname))
                {
                    GeneralResponse rtn = new GeneralResponse
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "Staff first name  is Invalid"
                    };
                    return rtn;
                }
                else if (param.staff_mname.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.staff_mname))
                {
                    GeneralResponse rtn = new GeneralResponse
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "Staff middle name is Invalid"
                    };
                    return rtn;
                }

                else if (param.staff_lname.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.staff_lname))
                {
                    GeneralResponse rtn = new GeneralResponse
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "Staff last name is Invalid"
                    };
                    return rtn;
                }

                else if (param.email.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.email))
                {
                    GeneralResponse rtn = new GeneralResponse
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "email is Invalid"
                    };
                    return rtn;
                }

                else if (param.phone_number.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.phone_number) || param.phone_number.Length != 12  || !Regex.Match(param.phone_number, @"^(2556[123456789]|2557[123456789])\d{7}$").Success)
                {
                    GeneralResponse rtn = new GeneralResponse
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "phone number is Invalid"
                    };
                    return rtn;
                }

                else
                {
                    var result = await _spconn.AddStaff(param);
                    return result;
                }
            }
            catch (Exception ex)
            {
                GeneralResponse exp = new GeneralResponse
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                return exp;
            }
        }

        [HttpGet(nameof(GetAllStaff))]
        public async Task<ResponseGetStaff> GetAllStaff()
        {
            try
            {
                var results = await _spconn.GetAllStaffs();
                return results;
            }
            catch (Exception ex)
            {
                ResponseGetStaff exp = new ResponseGetStaff
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                //log error
                return exp;
            }
        }

        [HttpPost(nameof(UpdateStaff))]
        public async Task<GeneralResponse> UpdateStaff(EditStaff param)
        {
            try
            {
                    var result = await _spconn.UpdateStaff(param);
                    return result;
                
            }
            catch (Exception ex)
            {
                GeneralResponse exp = new GeneralResponse
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                return exp;
            }
        }

        [HttpPost(nameof(GetSingleStaff))]
        public async Task<ResponseGetStaff> GetSingleStaff(ById param)
        {
            try
            {
                var result = await _spconn.GetSingleStaff(param);
                return result;

            }
            catch (Exception ex)
            {
                ResponseGetStaff exp = new ResponseGetStaff
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                return exp;
            }
        }

    }
}
