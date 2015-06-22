using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;
using System.Data;

namespace template.DBService
{
    public class ExamService
    {
        public ExamService()
        {
        }

        public int addExam(Exam exam)
        {
            int result = 0;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into Exam(examName, examDescription,examDuration,passingMark,numberOfQuestions,questionMark) OUTPUT INSERTED.examID values(N'"
                                + exam.examName + "', N'" + exam.examDescription + "', '" + exam.examDuration + "','" + exam.passingMark + "', '"
                                + exam.numberOfQuestions + "','" + exam.questionMark + "');";

                result= dbObj.executeQueryAndReturnLastID(query);
               
            }
            dbObj.CloseConnection();

            return result;

        
        }

        public Exam getExamByID(int examID)
        {
            Exam req = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "Select * from Exam where examID =" + examID;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    req = fillExam(reader);
                }

            }
            dbObj.CloseConnection();

            return req;
        }

        public DataSet getExamDataSet()
        {
            SQLClass dbObj = new SQLClass();
            DataSet ds = new DataSet();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "select * from Exam";
                SqlDataAdapter myCommand = new SqlDataAdapter(query, cn);
                myCommand.Fill(ds, "Exam");
            }
            dbObj.CloseConnection();
            return ds;
        }

        public List<Exam> getExams(int examID = 0 )
        {
            List<Exam> req = new List<Exam>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (examID != 0)
                {
                    whereCondition = " WHERE examID = " + examID;
                }

                String query = "Select * from Exam";

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    Exam request = fillExam(reader);
                    req.Add(request);
                }

            }
            dbObj.CloseConnection();
            return req;
        }

        private Exam fillExam(SqlDataReader reader)
        {
            Exam exam = new Exam();

            exam.examID = Int32.Parse(reader["examID"].ToString());
            exam.examName = reader["examName"].ToString();
            exam.examDuration = Double.Parse(reader["examDuration"].ToString());
            exam.examDescription = reader["examDescription"].ToString();
            exam.numberOfQuestions = Int32.Parse(reader["numberOfQuestions"].ToString());
            exam.passingMark = Double.Parse(reader["passingMark"].ToString());
            exam.questionMark = Double.Parse(reader["questionMark"].ToString());

            return exam;
        }
    }
}