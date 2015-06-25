using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class UserService
    {

        public UserService()
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
                String query = "Select * from UserTable inner join Role on UserTable.roleID = Role.roleID where username= '" + username + "' AND pass ='" + password + "' ";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {
                    user = fillUser(reader);
                }
            }
            dbObj.CloseConnection();
            return user;
        }

        public List<User> getUsers(int userId = 0)
        {
            List<User> result = new List<User>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                string whereCondition = "";  
                if (userId != 0)
                {
                    whereCondition = "WHERE userID = "+userId;
                }
                String query = "Select * from UserTable inner join Role on UserTable.roleID = Role.roleID "+whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    User user = fillUser(reader);
                    result.Add(user);
                }
            }
            dbObj.CloseConnection();
            return result;
        }

        public List<User> getClubUsers(int userId = 0)
        {
            List<User> result = new List<User>();
            int ID = (new HuntingClubService()).getClubs(userId)[0].clubID;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {


                String query = "Select * from HuntingClub INNER JOIN UserTable ON HuntingClub.adminUserID = UserTable.userID inner join Role on UserTable.roleID = Role.roleID  where  HuntingClub.clubID=" + ID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    User user = fillUser(reader);
                    result.Add(user);
                }
            }
            dbObj.CloseConnection();
            return result;
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
                String query = "insert into UserTable(firstName,lastName,email,username, pass,roleID) values(N'"
                                + user.firstName + "', N'" + user.lastName+ "','"+user.email+"','"
                                + user.username + "', '" + user.password + "','"+user.roleID +"');";
                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }

        public DataSet getUsersDataSet()
        {
            SQLClass dbObj = new SQLClass();
            DataSet ds = new DataSet();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "select * from UserTable";
                SqlDataAdapter myCommand = new SqlDataAdapter(query, cn);
                myCommand.Fill(ds, "UserTable");
            }
            dbObj.CloseConnection();
            return ds;
        }

        /// <summary>
        ///  this function fill user object
        /// </summary>
        public User fillUser(SqlDataReader reader)
        {
            User user = new User();
            user.userID = Int32.Parse(reader["userID"].ToString());
            user.firstName = reader["firstName"].ToString();
            user.lastName = reader["lastName"].ToString();
            user.email = reader["email"].ToString();
            user.username = reader["username"].ToString();
            user.password = reader["pass"].ToString();
            user.roleID = int.Parse(reader["roleID"].ToString());
            Role role = new Role();
            role.roleID = int.Parse(reader["roleID"].ToString());
            role.roleName = reader["roleName"].ToString();
            role.predefined =int.Parse( reader["predefined"].ToString());
            user.role = role;
            return user;

        }
        public bool updateUser(User user)
        {
            SQLClass dbObj = new SQLClass();
            SqlConnection conn = dbObj.openConnection();
            // add the insert between transaction and commit in order no to lose data integratiy ... 
            using (conn)
            {
                String query = "update  UserTable set firstName =N'" + user.firstName+ "', "
                                + "lastName= N'" + user.lastName+ "',"
                                + "email ='" + user.email+ "', "
                                + "username  = '" + user.username+ "',  "
                                + "pass  = '" + user.password+ "' , "
                                + "roleID = '"+user.roleID+"' "
                                + "where userID =" + user.userID;
                dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();
            return true;
        }

        public User getUserByID(int p)
        {
            User user = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                
                String query = "Select * from UserTable inner join Role on userTable.roleID = Role.roleID WHERE userID = " + p;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                     user = fillUser(reader);
                }
            }
            dbObj.CloseConnection();

            return user;
        }
    }
}