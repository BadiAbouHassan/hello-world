using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using template.DBModel;

namespace template.Controllers
{
    public class UserController
    {

        public UserController()
        {
        }

        /// <summary>
        ///  this function select user of given paswod and username --> for login aurhentication
        /// </summary>
        public User checkUserAuthentication(String username, String password)
        {
            User user = null;
            SQLClass dbObj = new SQLClass();
            using(SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from UserTable where username= '" + username + "' AND pass ='" + password + "' ";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    user = fillUser(reader);
                }
            }
            dbObj.CloseConnection();
            return user;
        }


        /// <summary>
        ///  this function select user of given paswod and username --> for login aurhentication
        /// </summary>
        public Boolean addUser(User user)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into UserTable(username, pass,firstname,middlename ,lastname,gender,dateOfBirth,placeOfBirth,registrationNb,"
                            + "nationality,bloodType,Profession,email,mailAddress,fax,city,userAddress,cellular,phone,roleID,clubID) values('"
                                + user.username + "', '" + user.password + "', '" + user.firstname + "','" + user.middlename + "', '"
                                + user.lastname + "', '" + user.gender + "', '" + user.dateOfBirth + "', '" + user.placeOfBirth + "','"
                                + user.registrationNb + "','" + user.nationality + "', '" + user.bloodType + "','" + user.profession + "','"
                                + user.email + "','" + user.mailAddress + "','" + user.fax + "','" + user.city + "','" + user.userAddress + "','"
                                + user.cellular + "','" + user.phone + "','" + user.roleID + "','" + user.clubID + "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }


        /// <summary>
        ///  this function fill user object
        /// </summary>
        public User fillUser(SqlDataReader reader)
        {
            User user = new User();
            user.userID = Int32.Parse(reader["userID"].ToString());
            user.username = reader["username"].ToString();
           // user.nationalID = reader["nationalID"].ToString();
            user.nationality = reader["nationality"].ToString();
            user.firstname = reader["firstname"].ToString();
            user.lastname = reader["lastname"].ToString();
           // user.mobileNb = reader["mobileNb"].ToString();
           // user.phoneNb = reader["phoneNb"].ToString();
            user.userAddress = reader["userAddress"].ToString();
            user.email = reader["email"].ToString();
            user.password = reader["pass"].ToString();
            user.roleID = Int32.Parse(reader["roleID"].ToString());
            return user;

        }

    }
}