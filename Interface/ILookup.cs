using policeWebApi.Model.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Interface
{
    public interface ILookup
    {
        public Task<ResponseLookup> roleLookup();
    }
}
