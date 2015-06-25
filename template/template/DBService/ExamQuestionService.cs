using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using template.Controllers;
using template.DBModel;

namespace template.DBService
{
    public class ExamQuestionService
    {
        public int addExamrQuestion(ExamQuestion examQuestion)
        {
            int result = 0;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String query = "INSERT INTO ExamQuestions(examInstanceID, questionID) OUTPUT INSERTED.examQuestionID VALUES ("
                                + examQuestion.examInstanceID + ", " + examQuestion.questionID + ");";

                result = dbObj.executeQueryAndReturnLastID(query);
            }
            dbObj.CloseConnection();

            return result;
        }

        public List<ExamQuestion> getExamQuestions(int examInstanceID = 0, int examWuestionID = 0)
        {
            List<ExamQuestion> req = new List<ExamQuestion>();
            SQLClass dbObj = new SQLClass();
            using (SqlConnection cn = dbObj.openConnection())
            {
                String whereCondition = "";
                if (examInstanceID != 0)
                {
                    whereCondition = " WHERE examInstanceID = " + examInstanceID;
                }
                if (examWuestionID != 0)
                {
                    whereCondition = ((whereCondition.Length == 0) ? " WHERE " : " AND ") + " examWuestionID = " + examWuestionID;
                }

                String query = "Select * FROM ExamQuestions " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);
                while (reader.Read())
                {
                    ExamQuestion examQuestion = this.fillExamQuestion(reader);
                    req.Add(examQuestion);
                }

            }
            dbObj.CloseConnection();
            return req;
        }

        private ExamQuestion fillExamQuestion(SqlDataReader reader)
        {
            ExamQuestion examQuestion = new ExamQuestion();

            examQuestion.examQuestionID = Int32.Parse(reader["examQuestionID"].ToString());
            examQuestion.examInstanceID = Int32.Parse(reader["examInstanceID"].ToString());
            examQuestion.questionID = Int32.Parse(reader["questionID"].ToString());

            return examQuestion;
        }
    }
}