using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class ExamInstanceService
    {

        public ExamInstanceService()
        {
        }

        public int addExamInstance(ExamInstance examInstance)
        {
            int result = 0;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into ExamInstance(examID,startingTime,examDuration,elapsedTime,result,active,activationTime,reservationID) OUTPUT inserted.instanceID values('"
                                + examInstance.examID + "', '" + examInstance.staringTime  + "', '" + examInstance.examDuration + "'," + examInstance.elapsedTime + ", '"
                                + examInstance.result + "','"+examInstance.active+"','"+examInstance.activationTime+"','"+examInstance.reservationID+"');";

                result = dbObj.executeQueryAndReturnLastID(query);

            }
            dbObj.CloseConnection();

            return result;
        }

        public ExamInstance getExamInstanceByID(int instanceID)
        {
            ExamInstance req = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from ExamInstance where instanceID =" + instanceID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    req = fillExamIntance(reader);
                }

            }
            dbObj.CloseConnection();

            return req;
        }

        public ExamInstance getExamInstanceByApplicantID(int applicantID)
        {
            ExamInstance req = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select i.* " + 
                               "FROM Applicant as a " +
                               "INNER JOIN RegistrationRequests as r ON a.applicantID = r.applicantID " +
                               "INNER JOIN ExamReservation as e ON e.registerationID = r.registerationID " +
                               "INNER JOIN ExamInstance as i ON i.reservationID = e.reservationID " +
                               "WHERE r.applicantID =" + applicantID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    req = fillExamIntance(reader);
                }

            }
            dbObj.CloseConnection();

            return req;
        }


        private ExamInstance fillExamIntance(SqlDataReader reader)
        {
            ExamInstance req = new ExamInstance();

            req.instanceID = Int32.Parse(reader["instanceID"].ToString());
            req.reservationID = Int32.Parse(reader["reservationID"].ToString());
            req.examID = Int32.Parse(reader["examID"].ToString());
            req.staringTime = Convert.ToDateTime(reader["startingTime"].ToString());
            req.elapsedTime = double.Parse(reader["elapsedTime"].ToString());
            req.examDuration = Double.Parse(reader["examDuration"].ToString());
            req.result = Double.Parse(reader["result"].ToString());
            req.activationTime = Convert.ToDateTime(reader["activationTime"].ToString());
            req.active = Int32.Parse(reader["active"].ToString());
            return req;
        }


        public List<ExamInstance> getAll()
        {
            List<ExamInstance> req = new List<ExamInstance>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from ExamInstance";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    ExamInstance request = fillExamIntance(reader);
                    req.Add(request);
                }

            }
            dbObj.CloseConnection();

            return req;
        }

        public  bool updateExamInstance(ExamInstance examInstance)
        {
            SQLClass dbObj = new SQLClass();
            SqlConnection conn = dbObj.openConnection();
            // add the insert between transaction and commit in order no to lose data integratiy ... 
            using (conn)
            {

                String query = "update  ExamInstance set result = '" +examInstance.result+ "', "
                                + "finished = '" + examInstance.finished+ "' "
                                + "where instanceID =" + examInstance.instanceID;
                dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();
            return true;
        }


    }



}