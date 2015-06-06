using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class QuestionsBankController
    {
        private QuestionsBankService serviceDB;

        public QuestionsBankController()
        {
            this.serviceDB = new QuestionsBankService();
        }

        public int addQuestion(QuestionsBank question)
        {
            int result = 0;

            result = this.serviceDB.addQuestion(question);

            return result;
        }

        public List<QuestionsBank> getCourses(int questionID = 0)
        {
            return this.serviceDB.getQuestions(questionID);
        }
    }
}