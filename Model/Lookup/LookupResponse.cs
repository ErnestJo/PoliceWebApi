using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static policeWebApi.Constants.Enums;

namespace policeWebApi.Model.Lookup
{
    public class Lookup
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ResponseLookup
    {
        private Codes code;
        private string message;
        private List<Lookup> data;

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
        public List<Lookup> Data
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
