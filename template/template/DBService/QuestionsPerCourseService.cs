using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.Controllers;
using System.Data.SqlClient;

namespace template.DBService
{
    public class QuestionsPerCourseService
    {
        public bool addQuestionPerCourse(DBModel.QuestionsPerCourse question)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String query = "INSERT INTO QuestionsPerCourse(courseID, examID, questionsPerCourseNb) " +
                               "Values(" + question.courseID + ", " + question.examID + ", " + question.questionsPerCourseNo + ")";
                result = dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();
            return result;
        }

        public List<QuestionsPerCourse> getQuestions(int questionID = 0, int examID = 0)
        {
            List<QuestionsPerCourse> result = null;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String whereCondition = "";
                if (questionID != 0)
                {
                    whereCondition = " WHERE questionsPerCourseID = " + questionID;
                }
                String query = "SELECT * FROM QuestionsPerCourse " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);

                result = new List<QuestionsPerCourse>();
                while (reader.Read())
                {
                    result.Add(fillQuestionsPerCourse(reader));
                }
            }
            dbObj.CloseConnection();

            return result;
        }
        public List<QuestionsPerCourse> getQuestionsByExam(int examID)
        {
            List<QuestionsPerCourse> result = null;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                
                String query = "SELECT * FROM QuestionsPerCourse WHERE examID = " + examID;

                SqlDataReader reader = dbObj.selectQuery(query);

                result = new List<QuestionsPerCourse>();
                while (reader.Read())
                {
                    result.Add(fillQuestionsPerCourse(reader));
                }
            }
            dbObj.CloseConnection();

            return result;
        }

        public DBModel.QuestionsPerCourse fillQuestionsPerCourse(SqlDataReader reader)
        {
            DBModel.QuestionsPerCourse question = new QuestionsPerCourse();

            question.courseID = int.Parse(reader["courseID"].ToString());
            question.examID = int.Parse(reader["examID"].ToString());
            question.questionsPerCourseNo = int.Parse(reader["questionsPerCourseNb"].ToString());
            question.questionsPerCourseID = int.Parse(reader["questionsPerCourseID"].ToString());

            return question;
        }
    }
}