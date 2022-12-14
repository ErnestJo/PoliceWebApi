using Microsoft.AspNetCore.Mvc;
using policeWebApi.Interface;
using policeWebApi.Model.Lookup;
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
    public class LookupController : ControllerBase
    {
        private readonly ILookup _spconn;
        public  LookupController(ILookup spconn)
        {
            _spconn = spconn;
        }
        
        [HttpGet(nameof(GetRoles))]
        public async Task<ResponseLookup> GetRoles()
        {
            try
            {
                var results = await _spconn.roleLookup();
                return results;
            }
            catch (Exception ex)
            {
                ResponseLookup exp = new ResponseLookup
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                //log error
                return exp;
            }
        }

        [HttpGet(nameof(GetGender))]
        public async Task<ResponseLookup> GetGender()
        {
            try
            {
                var results = await _spconn.genderLookup();
                return results;
            }
            catch (Exception ex)
            {
                ResponseLookup exp = new ResponseLookup
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                //log error
                return exp;
            }
        }

        [HttpGet(nameof(GetTitle))]
        public async Task<ResponseLookup> GetTitle()
        {
            try
            {
                var results = await _spconn.titleLookup();
                return results;
            }
            catch (Exception ex)
            {
                ResponseLookup exp = new ResponseLookup
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                //log error
                return exp;
            }
        }

        [HttpGet(nameof(GetMartialStatus))]
        public async Task<ResponseLookup> GetMartialStatus()
        {
            try
            {
                var results = await _spconn.martialStatusLookup();
                return results;
            }
            catch (Exception ex)
            {
                ResponseLookup exp = new ResponseLookup
                {
                    Code = Codes.General_failure,
                    Message = ex.Message
                };
                //log error
                return exp;
            }
        }
    }
}
