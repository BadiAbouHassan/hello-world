using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class User
    {
        public int userID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String firstname { get; set; }
        public String middlename { get; set; }
        public String lastname { get; set; }
        public String email { get; set; }
        public String cellular { get; set; }
        public String phone { get; set; }
        public int roleID { get; set; }
        public int clubID { get; set; }


        public User()
        {

        }
    }
}