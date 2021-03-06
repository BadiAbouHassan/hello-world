﻿using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class PermissionController
    {
        private PermissionService permissionService ; 
        public PermissionController()
        {
            this.permissionService= new PermissionService();
        }

        public Boolean addPermission(Permission permission)
        {
            return this.permissionService.add(permission);
        }

        public List<Permission> getPermissions(int permissionID = 0)
        {
            return this.permissionService.getPermissions(permissionID);
        }
        public Boolean updatePermission(Permission permission)
        {
            return this.permissionService.updatePermission(permission);
        }
    }
}