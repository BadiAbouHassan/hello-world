using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class GrantedPermissionService
    {
        public List<GrantedPermission> getGrantedPermissionByRole(Role role)
        {
            List<GrantedPermission> grantedPermissions = new List<GrantedPermission>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * From Role inner join grantedPermission on Role.roleID = grantedPermission.roleID inner join Permission on Permission.permissionID = grantedPermission.permissionID where grantedPermission.roleID = '"+role.roleID+"' ";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    GrantedPermission grantedPermission = fillGrantedPermission(reader);
                    grantedPermissions.Add(grantedPermission);
                }
            }
            dbObj.CloseConnection();
            return grantedPermissions; 
        }

        public GrantedPermission fillGrantedPermission(SqlDataReader reader)
        {
            GrantedPermission grantedPermission = new GrantedPermission();
            grantedPermission.grantedPermissionID = int.Parse(reader["grantedPermissionID"].ToString());
            grantedPermission.roleID = int.Parse(reader["roleID"].ToString());
            grantedPermission.permissionID = int.Parse(reader["permissionID"].ToString());
            Role role = new Role();
            role.roleID = int.Parse(reader["roleID"].ToString());
            role.roleName = reader["roleName"].ToString();
            role.predefined = int.Parse(reader["predefined"].ToString());
            grantedPermission.role = role; 
            Permission permission = new Permission();
            permission.permissionID = int.Parse(reader["permissionID"].ToString());
            permission.name = reader["name"].ToString();
            permission.code = reader["code"].ToString();
            grantedPermission.permission = permission; 
            return grantedPermission; 
        }
    }
}