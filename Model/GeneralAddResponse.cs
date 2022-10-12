using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Model
{
    public class GeneralAddResponse
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class GeneralResponse
    {

        private Codes code;
        private string message;
        private GeneralAddResponse data;

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
        public GeneralAddResponse Data
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
