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
        public Applicant checkUserAuthentication(String username, String password)
        {
            Applicant user = null;
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
        public Boolean addUser(Applicant user)
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
                                + user.cellular + "','" + user.phone+ "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }


        /// <summary>
        ///  this function fill user object
        /// </summary>
        public Applicant fillUser(SqlDataReader reader)
        {
            Applicant user = new Applicant();
            user.applicantID = Int32.Parse(reader["ID"].ToString());
            user.username = reader["username"].ToString();
            user.registrationNb = reader["registrationNb"].ToString();
            user.nationality = reader["nationality"].ToString();
            user.firstname = reader["firstname"].ToString();
            user.middlename = reader["middlename"].ToString();
            user.bloodType = reader["bloodType"].ToString();
            user.profession = reader["Profession"].ToString();
            user.gender = reader["gender"].ToString();
            user.mailAddress = reader["mailAddress"].ToString();
            user.fax = reader["fax"].ToString();
            user.dateOfBirth = reader["dateOfBirth"].ToString();
            user.placeOfBirth = reader["placeOfBirth"].ToString();
            user.city = reader["city"].ToString();
            user.lastname = reader["lastname"].ToString();
            user.cellular = reader["cellular"].ToString();
            user.phone = reader["phone"].ToString();
            user.userAddress = reader["userAddress"].ToString();
            user.email = reader["email"].ToString();
            user.password = reader["pass"].ToString();

            return user;

        }

    }
}