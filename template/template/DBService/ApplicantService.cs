using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class ApplicantService
    {
        /// <summary>
        ///  this function select Applicant of given paswod and Applicantname --> for login aurhentication
        /// </summary>
        public Applicant checkApplicantAuthentication(String username, String password)
        {
            Applicant Applicant = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from Applicant where username= '" + username + "' AND pass ='" + password + "' ";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    Applicant = fillApplicant(reader);
                }
            }
            dbObj.CloseConnection();
            return Applicant;
        }


        /// <summary>
        ///  this function select Applicant of given paswod and Applicantname --> for login aurhentication
        /// </summary>
        public Boolean addApplicant(Applicant Applicant)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into Applicant(username, pass,firstname,middlename ,lastname,gender,dateOfBirth,placeOfBirth,registrationNb,"
                            + "nationality,bloodType,Profession,email,mailAddress,fax,city,applicantAddress,cellular,phone) values('"
                                + Applicant.username + "', '" + Applicant.password + "', '" + Applicant.firstname + "','" + Applicant.middlename + "', '"
                                + Applicant.lastname + "', '" + Applicant.gender + "', '" + Applicant.dateOfBirth + "', '" + Applicant.placeOfBirth + "','"
                                + Applicant.registrationNb + "','" + Applicant.nationality + "', '" + Applicant.bloodType + "','" + Applicant.profession + "','"
                                + Applicant.email + "','" + Applicant.mailAddress + "','" + Applicant.fax + "','" + Applicant.city + "','" + Applicant.applicantAddress + "','"
                                + Applicant.cellular + "','" + Applicant.phone + "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }


        /// <summary>
        ///  this function fill Applicant object
        /// </summary>
        public Applicant fillApplicant(SqlDataReader reader)
        {
            Applicant Applicant = new Applicant();
            Applicant.applicantID = Int32.Parse(reader["ID"].ToString());
            Applicant.username = reader["username"].ToString();
            Applicant.registrationNb = reader["registrationNb"].ToString();
            Applicant.nationality = reader["nationality"].ToString();
            Applicant.firstname = reader["firstname"].ToString();
            Applicant.middlename = reader["middlename"].ToString();
            Applicant.bloodType = reader["bloodType"].ToString();
            Applicant.profession = reader["Profession"].ToString();
            Applicant.gender = reader["gender"].ToString();
            Applicant.mailAddress = reader["mailAddress"].ToString();
            Applicant.fax = reader["fax"].ToString();
            Applicant.dateOfBirth = reader["dateOfBirth"].ToString();
            Applicant.placeOfBirth = reader["placeOfBirth"].ToString();
            Applicant.city = reader["city"].ToString();
            Applicant.lastname = reader["lastname"].ToString();
            Applicant.cellular = reader["cellular"].ToString();
            Applicant.phone = reader["phone"].ToString();
            Applicant.applicantAddress = reader["applicantAddress"].ToString();
            Applicant.email = reader["email"].ToString();
            Applicant.password = reader["pass"].ToString();
            return Applicant;

        }

    }
}