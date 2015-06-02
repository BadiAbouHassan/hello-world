using System;
using System.Collections.Generic;
using System.Web;

namespace template.Models
{
    public class GrantedPermission
    {
        public int grantedPermissionID { get; set; }
        public int permissionID { get; set; }
        public int roleID { get; set; }

        public GrantedPermission()
        {
        }
    }
}