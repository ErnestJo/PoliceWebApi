using Microsoft.AspNetCore.Mvc;
using policeWebApi.Interface;
using policeWebApi.Model.Account.rq;
using policeWebApi.Model.Account.rs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _spconn;
        public AccountController(IAccount spconn)
        {
            _spconn = spconn;
        }

        [HttpPost(nameof(Login))]
        public async Task<ResponseLogin> Login(LoginRq param)
        {
            try
            {
                if(param.staff_username.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.staff_username))
                {
                    ResponseLogin rtn = new ResponseLogin
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "Username  is Invalid"
                    };
                    return rtn;
                }
                else if(param.staff_password.GetType() != typeof(string) || string.IsNullOrWhiteSpace(param.staff_password))
                {
                    ResponseLogin rtn = new ResponseLogin
                    {
                        Code = Codes.Data_validattion_error,
                        Message = "Password is Invalid"
                    };
                    return rtn;
                }
                else
                {
                    var results = await _spconn.Login(param);
                    return results;
                }
            }
            catch (Exception ex)
            {
                ResponseLogin exp = new ResponseLogin
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };

                return exp;
            }
        }
    }
}
