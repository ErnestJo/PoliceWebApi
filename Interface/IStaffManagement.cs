using policeWebApi.Model;
using policeWebApi.Model.staff.request;
using policeWebApi.Model.staff.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Interface
{
     public interface IStaffManagement
    {
        public Task<GeneralResponse> AddStaff(addStaff param);
        public Task<GeneralResponse> UpdateStaff(EditStaff param);
        public Task<ResponseGetStaff> GetAllStaffs();
    }
}
