using System;
using System.Collections.Generic;
using System.Web;

namespace template.Models
{
    public class Permission
    {
        public int permissionID { get; set; }
        public String name { get; set; }
        public String code { get; set; }

        public Permission()
        {
        }

    }
}