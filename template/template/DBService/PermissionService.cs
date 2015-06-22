using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class PermissionService
    {
        public PermissionService() { }

        public Boolean add(Permission permission)
        {
            Boolean result;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                // check if the role name has been already inserted before ... 
                //String checkQuery = "SELECT * FROM Role WHERE LOWER(roleName) = '" + role.roleName + "'";
                //SqlDataReader reader = dbObj.selectQuery(checkQuery);
                //if (reader.Read())
                //{
                //    dbObj.CloseConnection();
                //    throw new Exception("role name already exist !!");
                //}
                String query = "insert into Permission(name, code) values(N'"
                                + permission.name+ "',N'" + permission.code+ "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }

        public Boolean updatePermission(Permission permission)
        {
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Update Permission Set name = N'"+permission.name+"', code = N'"+permission.code+"' where permissionID = '"+permission.permissionID+"'";
                dbObj.selectQuery(query);
            }
            dbObj.CloseConnection();
            return true;
        }

        public List<Permission> getPermissions(int permissionID = 0)
        {
            List<Permission> req = new List<Permission>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (permissionID != 0)
                {
                    whereCondition = " WHERE permissionID = " + permissionID;
                }
                String query = "Select * from Permission " + whereCondition;
                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    Permission request = fillPermission(reader);
                    req.Add(request);
                }
            }
            dbObj.CloseConnection();
            return req;
        }
        private Permission fillPermission(SqlDataReader reader)
        {
            Permission permission = new Permission();
            permission.permissionID = Int32.Parse(reader["permissionID"].ToString());
            permission.name = reader["name"].ToString();
            permission.code = reader["code"].ToString();
            return permission;
        }
    }


}