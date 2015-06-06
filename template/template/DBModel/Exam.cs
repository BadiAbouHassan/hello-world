using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class Exam
    {
        public int examID { get; set; }
        public String examName { get; set; }
        public String examDescription { get; set; }
        public double examDuration { get; set; }
        public double passingMark { get; set; }
        public int numberOfQuestions { get; set; }
        public double questionMark { get; set; }


        public Exam()
        {
        }
    }
}