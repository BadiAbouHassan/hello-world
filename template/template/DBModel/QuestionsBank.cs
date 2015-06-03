using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class QuestionsBank
    {
        public int questionsID { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public double mark { get; set; }
        public int courseID { get; set; }

        public QuestionsBank()
        {
        }


    }
}