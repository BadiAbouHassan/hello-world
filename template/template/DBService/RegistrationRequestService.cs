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
        public RegistrationRequests addRequestByCnx(RegistrationRequests request,SQLClass dbObj)
        {

            String query = "insert into RegistrationRequests(applicantID, clubID,registrationRequestsDate,verifiedByAdmin,verificationDate, referenceNo) OUTPUT inserted.registerationID values('"
                                + request.applicantID + "', '" + request.clubID + "', '" + request.registrationRequestsDate + "','" + request.verifiedByAdmin + "', '"
                                + request.verificationDate + "', '" + request.referenceNo + "');";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {
                    request.registerationID = Int32.Parse(reader["registerationID"].ToString());
                }
                else
                {
                    request = null;
                }

            return request;
        }


        public Boolean deleteRequestByApplicantID(int ID)
        {
            
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {


                String query = "DELETE RegistrationRequests "
                              + "FROM RegistrationRequests "
                              + "INNER JOIN Applicant ON RegistrationRequests.applicantID=Applicant.applicantID  "
                              + "Where Applicant.applicantID =" + ID;
                dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();

            return true;
        }

        public Boolean updateRequestByRequest(RegistrationRequests request)
        {

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "update table RegistrationRequests set verifiedByAdmin ='"+ request.verifiedByAdmin +"','" +"verificationDate ='"+  request.verificationDate +
                                 "' where registerationID =" + request.registerationID + ";";

                dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();

            return true;
        }

        public bool verifyRegisterationRequest(int registerationID)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String verificationDate = System.Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");

                String query = "UPDATE RegistrationRequests SET verifiedByAdmin='1',verificationDate='" + verificationDate + "' where registerationID =" + registerationID + ";";

                result = dbObj.executeQuery(query);
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
                String query = "Select * from RegistrationRequests where registerationID =" + referenceID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    req = fillRegistrationRequest(reader);
                }

            }
            dbObj.CloseConnection();

            return req;
        }

        public RegistrationRequests getRequestByClubID(int clubID)
        {
            RegistrationRequests req = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from RegistrationRequests where clubID =" + clubID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    req = fillRegistrationRequest(reader);
                }

            }
            dbObj.CloseConnection();

            return req;
        }

        public RegistrationRequests getRequestByApplicant(int applicantID)
        {
            RegistrationRequests req = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from RegistrationRequests where applicantID =" + applicantID;

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

            req.registerationID = Int32.Parse(reader["registerationID"].ToString());
            req.clubID = Int32.Parse(reader["clubID"].ToString());
            req.registrationRequestsDate = reader["registrationRequestsDate"].ToString();
            req.verificationDate = reader["verificationDate"].ToString();
            req.verifiedByAdmin = Int32.Parse(reader["verifiedByAdmin"].ToString());
            req.referenceNo = reader["referenceNo"].ToString();

            return req;

         }

    }
}