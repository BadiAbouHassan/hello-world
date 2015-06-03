using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using template.Models;

namespace template.Controlers
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
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into UserTable(username, pass,firstname, lastname,email,userAddress,mobileNb,phoneNb,nationalID,nationality,roleID) values('"
                                +user.username+"', '"+user.password+"', '"+user.firstname+"','" +user.lastname+"', '"
                                +user.email+"', '" +user.userAddress+"', '"+user.mobileNb+"', '"+user.phoneNb +"','"
                                +user.nationalID+"','" +user.nationality+"', '"+user.roleID+"');";
            }
            dbObj.CloseConnection();
            return true;
        }


        /// <summary>
        ///  this function fill user object
        /// </summary>
        public User fillUser(SqlDataReader reader)
        {
            User user = new User();
            user.userID = Int32.Parse(reader["userID"].ToString());
            user.username = reader["username"].ToString();
            user.nationalID = reader["nationalID"].ToString();
            user.nationality = reader["nationality"].ToString();
            user.firstname = reader["firstname"].ToString();
            user.lastname = reader["lastname"].ToString();
            user.mobileNb = reader["mobileNb"].ToString();
            user.phoneNb = reader["phoneNb"].ToString();
            user.userAddress = reader["userAddress"].ToString();
            user.email = reader["email"].ToString();
            user.password = reader["pass"].ToString();
            user.roleID = Int32.Parse(reader["roleID"].ToString());
            return user;

        }

    }
}