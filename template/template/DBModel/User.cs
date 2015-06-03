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
        public String lastname { get; set; }
        public String email { get; set; }
        public String userAddress { get; set; }
        public String mobileNb { get; set; }
        public String phoneNb { get; set; }
        public String nationalID { get; set; }
        public String nationality { get; set; }
        public int roleID { get; set; }

        public User()
        {

        }
    }
}