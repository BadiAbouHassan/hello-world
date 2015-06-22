using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.Controllers;
using System.Data.SqlClient;

namespace template.DBService
{
    public class QuestionsBankService
    {
        public int addQuestion(DBModel.QuestionsBank question)
        {
            int result = 0;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String query = "INSERT INTO QuestionsBank(courseID, title, questionDesc) OUTPUT INSERTED.questionID " +
                               "Values(" + question.courseID + ", N'" + question.title + "', N'" + question.description + "')";
                result = dbObj.executeQueryAndReturnLastID(query);
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
                    result.Add(fillQuestionsBank(reader));
                }
            }
            dbObj.CloseConnection();

            return result;
        }
        public List<QuestionsBank> getQuestionsByCourseID(int courseID)
        {
            List<QuestionsBank> result = null;
            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String query = "SELECT * FROM QuestionsBank WHERE courseID = " + courseID;
                SqlDataReader reader = dbObj.selectQuery(query);
                result = new List<QuestionsBank>();
                while (reader.Read())
                {
                    result.Add(fillQuestionsBank(reader));
                }
            }
            dbObj.CloseConnection();
            return result;
        }

        public DBModel.QuestionsBank fillQuestionsBank(SqlDataReader reader)
        {
            DBModel.QuestionsBank question = new QuestionsBank();

            question.courseID = int.Parse(reader["courseID"].ToString());
            question.questionsID = int.Parse(reader["questionID"].ToString());
            question.title = reader["title"].ToString();
            question.description = reader["questionDesc"].ToString();

            return question;
        }

        public List<QuestionsBank> getRandomQuestions(int number)
        {
            List<QuestionsBank> questionsList = new List<QuestionsBank>();

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {

                String query = "SELECT TOP " + number + " PERCENT * FROM QuestionsBank ORDER BY NEWID()";

                SqlDataReader reader = dbObj.selectQuery(query);

                while (reader.Read())
                {
                    questionsList.Add(fillQuestionsBank(reader));
                }
            }
            dbObj.CloseConnection();
            return questionsList;
        }
    }
}