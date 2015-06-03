using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ExamQuestions
    {
        public int examQuestionID { get; set; }
        public int examID { get; set; }
        public int questionID { get; set; }

        public ExamQuestions()
        {
        }

    }
}