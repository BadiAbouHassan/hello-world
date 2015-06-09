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
                // String checkQuery = "SELECT * FROM Role WHERE LOWER(roleName) = '" + role.roleName + "'";
                //SqlDataReader reader = dbObj.selectQuery(checkQuery);
                //if (reader.Read())
                //{
                //    dbObj.CloseConnection();
                //    throw new Exception("role name already exist !!");
                //}
                String query = "insert into Role(roleName, predefined) values('"
                                + role.roleName + "','" + role.predefined + "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }


        public List<Role> getRoles(int roleID = 0)
        {
            List<Role> req = new List<Role>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (roleID != 0)
                {
                    whereCondition = " WHERE roleID = " + roleID;
                }

                String query = "Select * from Role";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    Role request = fillRole(reader);
                    req.Add(request);
                }

            }
            dbObj.CloseConnection();
            return req;
        }

        private Role fillRole(SqlDataReader reader)
        {
            Role role = new Role();

            role.roleID = Int32.Parse(reader["roleID"].ToString());
            role.roleName = reader["roleName"].ToString();
            role.predefined = int.Parse(reader["predefined"].ToString());

            return role;
        }

    }
}