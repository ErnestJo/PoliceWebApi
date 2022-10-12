using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Model.staff.response
{
    public class GetStaffs
    {
        public int id { get; set; }

        public string Staff { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string role { get; set; }

        public string  gender { get; set; }

        public string title { get; set; }

        public string mstatus { get; set; }

    }

    public class ResponseGetStaff
    {

        private Codes code;
        private string message;
        private List<GetStaffs> data;

        // Declare a Code property of type string:
        public Codes Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        // Declare a Name property of type string:
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        // Declare a Age property of type int:
        public List<GetStaffs> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}
