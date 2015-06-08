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
                String query = "insert into Permission(name, code) values('"
                                + permission.name+ "','" + permission.code+ "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }

    }


}