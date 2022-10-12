using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Model.staff.request
{
    public class addStaff
    {

        public string staff_fname { get; set; }

        public string staff_mname { get; set; }

        public string staff_lname { get; set; }

        public string email { get; set; }

        public int phone_number { get; set; }

        public int gender { get; set; }

        public int staff_role { get; set; }

        public int staff_title { get; set; }

        public int martial_status { get; set; }
    }
}
