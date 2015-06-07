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

        public List<Answer> getAnswers(int questionID = 0)
        {
            List<Answer> result = null;

            SQLClass dbObj = new SQLClass();
            using (SqlConnection connection = dbObj.openConnection())
            {
                String whereCondition = "";
                if (questionID != 0)
                {
                    whereCondition = " WHERE questionID = " + questionID;
                }
                String query = "SELECT * FROM Answer " + whereCondition;

                SqlDataReader reader = dbObj.selectQuery(query);

                result = new List<Answer>();
                while (reader.Read())
                {
                    result.Add(fillAnswer(reader));
                }
            }
            dbObj.CloseConnection();

            return result;
        }

        public DBModel.Answer fillAnswer(SqlDataReader reader)
        {
            DBModel.Answer answer= new Answer();

            answer.answerID = int.Parse(reader["answerID"].ToString());
            answer.title = reader["title"].ToString();
            answer.correct = int.Parse(reader["correct"].ToString());
            answer.questionID = int.Parse(reader["questionID"].ToString());
            return answer;
        }
    }
}