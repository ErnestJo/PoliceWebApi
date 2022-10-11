using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Model.Account.rq
{
    public class AccountRq
    {
    }

    public class LoginRq
    {
        public string staff_username { get; set; }

        public string staff_password { get; set; }
    }
}
