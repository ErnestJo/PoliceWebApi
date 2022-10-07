using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Constants
{
    public class Connection
    {

        public static class Conn
        {
            private readonly static string Grant_type = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["Granttype"];
            public static string Username = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["Username"];
            public static string Password = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["Password"];

            //Const
            private static string _dbconnName = "default";
            private static string _granttype = Grant_type;

            // Config Constants


            public static string DBConnName
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(_dbconnName))
                    {
                        _dbconnName = " ";
                    }
                    return _dbconnName;
                }
                set { _dbconnName = value; }
            }

            public static string Granttype
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(_granttype))
                    {
                        _granttype = " ";
                    }
                    return _granttype;
                }
                set { _granttype = value; }
            }
        }
    }
}
