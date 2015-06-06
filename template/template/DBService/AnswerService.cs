using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.Controllers;
using System.Data.SqlClient;

namespace template.DBService
{
    public class AnswerService
    {
        public bool addAnswer(DBModel.Answer answer)
        {
            bool result = false;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String query = "INSERT INTO Answer(questionID, title, correct)" +
                               "Values(" + answer.questionID + ", '" + answer.title + "', " + answer.correct + ")";
                result = dbObj.executeQuery(query);
            }
            dbObj.CloseConnection();
            return result;
        }

        public List<QuestionsBank> getQuestions(int questionID = 0)
        {
            List<QuestionsBank> result = null;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String whereCondition = "";
                if (questionID != 0)
                {
                    whereCondition = " WHERE ID = " + questionID;
                }
                String query = "SELECT * FROM QuestionsBank " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);

                result = new List<QuestionsBank>();
                while (reader.Read())
                {
                    result.Add(fillCourse(reader));
                }
            }
            dbObj.CloseConnection();

            return result;
        }

        public DBModel.QuestionsBank fillCourse(SqlDataReader reader)
        {
            DBModel.QuestionsBank question = new QuestionsBank();

            question.courseID = int.Parse(reader["courseID"].ToString());
            question.questionsID = int.Parse(reader["ID"].ToString());
            question.title = reader["title"].ToString();
            question.description = reader["description"].ToString();

            return question;
        }
    }
}