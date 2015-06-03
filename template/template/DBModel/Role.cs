using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class Role
    {
        public int roleID { get; set; }
        public String roleName { get; set; }
        public int predefined { get; set; }

        public Role()
        {
        }
    }
}