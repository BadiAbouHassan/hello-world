using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class RegistrationRequestService
    {

        public RegistrationRequestService()
        {
        }


        /// <summary>
        /// function that inser request and rturns the last request inserted
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistrationRequests addRequest(RegistrationRequests request)
        {
            
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into RegistrationRequests(applicantID, clubID,registrationRequestsDate,verifiedByAdmin,verificationDate) OUTPUT inserted.refrenceID values('"
                                + request.applicantID + "', '" + request.clubID + "', '" + request.registrationRequestsDate + "','" + request.verifiedByAdmin + "', '"
                                + request.verificationDate + "');";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {
                    request.referenceID = Int32.Parse(reader["referenceID"].ToString());
                }
                else
                {
                    request = null;
                }

            }
            dbObj.CloseConnection();

            return request;
        }


        public Boolean updateRequestByRequest(RegistrationRequests request)
        {

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "update table RegistrationRequests set verifiedByAdmin ='"+ request.verifiedByAdmin +"','" +"verificationDate ='"+  request.verificationDate +
                                 "' where referenceID ="+request.referenceID+";";

                dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();

            return true;
        }



        public RegistrationRequests getRequestByID(int referenceID)
        {
            RegistrationRequests req = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from RegistrationRequests where referenceID =" + referenceID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    req = fillRegistrationRequest(reader);
                }

            }
            dbObj.CloseConnection();

            return req;
        }


        public List<RegistrationRequests> getAll()
        {
            List<RegistrationRequests> req = new List<RegistrationRequests>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from RegistrationRequests";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    RegistrationRequests request = fillRegistrationRequest(reader);
                    req.Add(request);
                }

            }
            dbObj.CloseConnection();

            return req;
        }

        private RegistrationRequests fillRegistrationRequest(SqlDataReader reader)
        {
            RegistrationRequests req = new RegistrationRequests();

            req.referenceID = Int32.Parse(reader["referenceID"].ToString());
            req.clubID = Int32.Parse(reader["clubID"].ToString());
            req.registrationRequestsDate = reader["registrationRequestsDate"].ToString();
            req.verificationDate = reader["verificationDate"].ToString();
            req.verifiedByAdmin = Int32.Parse(reader["verifiedByAdmin"].ToString());

            return req;

         }

    }
}