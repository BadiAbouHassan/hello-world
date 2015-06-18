using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class RoleController
    {
        private RoleService roleService;
        public RoleController()
        {
            this.roleService = new RoleService();
        }

        public Boolean addRole(Role role)
        {
            return this.roleService.add(role);
        }

        public List<Role> getRole(int roleID= 0)
        {
            return this.roleService.getRoles(roleID);
        }
        public Boolean updateRole(Role role)
        {
            return this.roleService.updateRole(role); 
        }
    }
}