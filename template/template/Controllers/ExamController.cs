using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class ExamController
    {
        private ExamService examService;

        public ExamController()
        {
            this.examService = new ExamService();
        }

        public bool addCourse(Exam exam)
        {
            bool result = false;

            result = this.examService.addExam(exam);

            return result;
        }

        //public List<Course> getCourses(int examID = 0)
        //{
        //   // return this.examService.getExams(examID);
        //}
    }
}