using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Helper
{
    public class Validation
    {
    }

    public class PosNumberNoZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            int getal;
            if (int.TryParse(value.ToString(), out getal))
            {

                if (getal == 0)
                    return false;

                if (getal > 0)
                    return true;
            }
            return false;

        }
    }
}
