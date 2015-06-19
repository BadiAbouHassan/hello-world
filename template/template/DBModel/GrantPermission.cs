using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class GrantPermission
    {
        public int grantedPermissionID { get; set; }
        public int permissionID { get; set; }
        public int roleID { get; set; }

        public Permission permission { get; set; }
        public Role role { get; set; }

        public GrantPermission() { } 
    }
}