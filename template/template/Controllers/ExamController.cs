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

        public int addExam(Exam exam)
        {
            return this.examService.addExam(exam);
        }

        public List<Exam> getExams(int examID = 0)
        {
            return this.examService.getExams(examID);
        }
    }
}