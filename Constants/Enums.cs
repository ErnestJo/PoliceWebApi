using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Constants
{
    public class Enums
    {
        public enum Codes
        {
            SQL_Record_Not_Exists = 506,
            SUCCESS = 200,
            N0_Data_Found = 510,
            General_failure = 500,
            Failed_insert = 511,
            Failed_update = 512,
            Failed_delete = 513,
            Data_validattion_error = 501,
            Object_Already_Exist = 509,
            SQLViewError = 505,
            DB_Session_Expired = 508,
            INFORMATION = 300,
            NOT_APPLICABLE = 400,
            UNAUTHORIZED = 401,
            AUTHORIZED = 444,
            INVALIDCOMMANDCODE = 544
        }


        public static class CustomeSMS
        {
            public static string NoData = "No Data Available";
            public static string Success = "Success";
            public static string failinsert = "Failed to Insert Data";
            public static string failupdate = "Failed to Update Data";
            public static string faildelete = "Failed to Delete Data";
            public static string objectexist = "Object Already Exist";
            public static string sqlerror = "SqlError";
            public static string changepassword = "Failed to Change Password";
            public static string ResetPassword = "Failed to Reset Password";
            public static string DBExpire = "Session has Expire";
            public static string sqlgenfailure = "Failure, Please Contact System Admin";
        }
    }
}
