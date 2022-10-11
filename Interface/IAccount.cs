using policeWebApi.Model.Account.rq;
using policeWebApi.Model.Account.rs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Interface
{
   public interface IAccount
    {
        public Task<ResponseLogin> Login(LoginRq param);
    }
}
