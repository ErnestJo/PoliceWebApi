using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Constants
{
    public class StoredProcedure
    {
        private static string schema = "[dbo].";

        public static string getRoles = schema + "[get_role]";
    }
}
