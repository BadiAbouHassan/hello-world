using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class RoleService
    {

        public RoleService()
        {
        }

        /// <summary>
        /// insert role to RoleTable
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Boolean add(Role role)
        {
            Boolean result;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                // check if the role name has been already inserted before ... 
                String checkQuery = "SELECT * FROM Role WHERE LOWER(roleName) = '" + role.roleName + "'";
                SqlDataReader reader =  dbObj.selectQuery(checkQuery);
                if (reader.Read())
                {
                    dbObj.CloseConnection();
                    throw new Exception("role name already exist !!");
                }
                String query = "insert into Role(roleName, predefined) values('"
                                + role.roleName + "','" + role.predefined + "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }


       

    }
}