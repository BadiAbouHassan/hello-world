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
        public int roleID { get; set; }
        public Role role { get; set; } 


        public User()
        {

        }
    }
}