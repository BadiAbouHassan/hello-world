using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class QuestionsPerCourse
    {
        public int questionsPerCourseID { get; set; }
        public int examID { get; set; }
        public int courseID { get; set; }
        public int questionsPerCourseNo { get; set; }

        public QuestionsPerCourse()
        {
        }
    }
}