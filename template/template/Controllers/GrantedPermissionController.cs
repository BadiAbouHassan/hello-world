using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class GrantedPermissionController
    {
        protected GrantedPermissionService grantedPermissionService = new GrantedPermissionService();

        public List<GrantedPermission> getGrantedPermission(Role role)
        {
            return this.grantedPermissionService.getGrantedPermissionByRole(role); 
        }
    }
}