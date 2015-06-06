using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ExamInstance
    {
        public int examID { get; set; }
        public String examName { get; set; }
        public DateTime examDate { get; set; }
        public double examDuration { get; set; }
        public DateTime elapsedTime { get; set; } 
        public double result { get; set; }
        public int referenceID { get; set; }

        public ExamInstance()
        {
        }
    }
}