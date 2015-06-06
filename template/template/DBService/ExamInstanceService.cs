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

        public ExamInstance addExamInstance(ExamInstance examInstance)
        {
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into ExamInstance(examID, examDate,examDuration,elapsedTime,result,referenceID) values('"
                                + examInstance.examID + "', '" + examInstance.examDate + "', '" + examInstance.examDuration + "','" + examInstance.elapsedTime + "', '"
                                + examInstance.result + "','"+examInstance.referenceID+"'); SELECT SCOPE_IDENTITY();";

                SqlDataReader reader = dbObj.selectQuery(query);
                if (reader.Read())
                {
                    examInstance.instanceID = Int32.Parse(reader["instanceID"].ToString());
                }
                else
                {
                    examInstance = null;
                }

            }
            dbObj.CloseConnection();

            return examInstance;
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

        private ExamInstance fillExamIntance(SqlDataReader reader)
        {
            ExamInstance req = new ExamInstance();

            req.instanceID = Int32.Parse(reader["instanceID"].ToString());
            req.referenceID = Int32.Parse(reader["referenceID"].ToString());
            req.examID = Int32.Parse(reader["examID"].ToString());
            req.examDate = Convert.ToDateTime(reader["examDate"].ToString());
            req.elapsedTime = Convert.ToDateTime(reader["elapsedTime"].ToString());
            req.examDuration = Double.Parse(reader["examDuration"].ToString());
            req.result = Double.Parse(reader["result"].ToString());

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



    }



}