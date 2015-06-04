using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class ClientService
    {
        /// <summary>
        ///  this function select Client of given paswod and Clientname --> for login aurhentication
        /// </summary>
        public Client checkClientAuthentication(String username, String password)
        {
            Client Client = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from ClientTable where username= '" + username + "' AND pass ='" + password + "' ";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {

                    Client = fillClient(reader);
                }
            }
            dbObj.CloseConnection();
            return Client;
        }


        /// <summary>
        ///  this function select Client of given paswod and Clientname --> for login aurhentication
        /// </summary>
        public Boolean addClient(Client Client)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into ClientTable(username, pass,firstname,middlename ,lastname,gender,dateOfBirth,placeOfBirth,registrationNb,"
                            + "nationality,bloodType,Profession,email,mailAddress,fax,city,userAddress,cellular,phone,clubID) values('"
                                + Client.username + "', '" + Client.password + "', '" + Client.firstname + "','" + Client.middlename + "', '"
                                + Client.lastname + "', '" + Client.gender + "', '" + Client.dateOfBirth + "', '" + Client.placeOfBirth + "','"
                                + Client.registrationNb + "','" + Client.nationality + "', '" + Client.bloodType + "','" + Client.profession + "','"
                                + Client.email + "','" + Client.mailAddress + "','" + Client.fax + "','" + Client.city + "','" + Client.userAddress + "','"
                                + Client.cellular + "','" + Client.phone + "','"  + Client.clubID + "');";

                result = dbObj.executeQuery(query);

            }
            dbObj.CloseConnection();
            return result;
        }


        /// <summary>
        ///  this function fill Client object
        /// </summary>
        public Client fillClient(SqlDataReader reader)
        {
            Client client = new Client();
            client.clientID = Int32.Parse(reader["ID"].ToString());
            client.username = reader["username"].ToString();
            client.registrationNb = reader["registrationNb"].ToString();
            client.nationality = reader["nationality"].ToString();
            client.firstname = reader["firstname"].ToString();
            client.middlename = reader["middlename"].ToString();
            client.bloodType = reader["bloodType"].ToString();
            client.profession = reader["Profession"].ToString();
            client.gender = reader["gender"].ToString();
            client.mailAddress = reader["mailAddress"].ToString();
            client.fax = reader["fax"].ToString();
            client.dateOfBirth = reader["dateOfBirth"].ToString();
            client.placeOfBirth = reader["placeOfBirth"].ToString();
            client.city = reader["city"].ToString();
            client.lastname = reader["lastname"].ToString();
            client.cellular = reader["cellular"].ToString();
            client.phone = reader["phone"].ToString();
            client.userAddress = reader["userAddress"].ToString();
            client.email = reader["email"].ToString();
            client.password = reader["pass"].ToString();
            client.clubID = Int32.Parse(reader["clubID"].ToString());
            return client;

        }

    }
}