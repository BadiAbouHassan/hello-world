using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class ExamService
    {
        public ExamService()
        {
        }

        public bool addExam(Exam exam)
        {
            bool result;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "insert into Exam(examName, examDescription,examDuration,passingMark,numberOfQuestions,questionMark) values('"
                                + exam.examName + "', '" + exam.examDescription + "', '" + exam.examDuration + "','" + exam.passingMark + "', '"
                                + exam.numberOfQuestions + "','" + exam.questionMark + "');";

                result= dbObj.executeQuery(query);
               
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
        public List<Exam> getExams(int examID)
        {
            List<Exam> req = new List<Exam>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
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