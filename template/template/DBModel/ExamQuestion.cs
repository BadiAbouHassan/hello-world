using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ExamQuestion
    {
        public int examQuestionID { get; set; }
        public int examInstanceID { get; set; }
        public int questionID { get; set; }

        public ExamQuestion()
        {
        }

    }
}