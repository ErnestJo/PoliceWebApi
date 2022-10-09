﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policeWebApi.Constants
{
    public class StoredProcedure
    {
        private static string schema = "[dbo].";

        public static string getRoles = schema + "[get_role]";
        public static string getGender = schema + "[get_gender]";
        public static string getMartialStatus = schema + "[get_martial]";
        public static string getTitle = schema + "[get_title]";

        public static string addStaff = schema + "[add_staffs]";
        public static string getStaff = schema + "[get_staffs]";
        public static string updateStaff = schema  + "[update_staff]"
;    }
}
