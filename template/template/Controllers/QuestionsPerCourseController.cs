using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class QuestionsPerCourseController
    {
        private QuestionsPerCourseService questionsPerCourseService;

        public QuestionsPerCourseController()
        {
            this.questionsPerCourseService = new QuestionsPerCourseService();
        }

        public bool addQuestion(QuestionsPerCourse question)
        {
            return this.questionsPerCourseService.addQuestionPerCourse(question);
        }

        public List<QuestionsPerCourse> getQuestions(int questionID = 0)
        {
            return this.questionsPerCourseService.getQuestions(questionID);
        }
    }
}