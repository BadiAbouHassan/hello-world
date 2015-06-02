using System;
using System.Collections.Generic;
using System.Web;

namespace template.Models
{
    public class Exam
    {
        public int examID { get; set; }
        public String examName { get; set; }
        public DateTime examDate { get; set; }
        public double examDuration { get; set; }
        public DateTime elapsedTime { get; set; } 
        public double result { get; set; }
        public int referenceID { get; set; }

        public Exam()
        {
        }
    }
}