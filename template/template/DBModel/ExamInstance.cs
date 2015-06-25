using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ExamInstance
    {
        public int instanceID { get; set; }
        public int examID { get; set; }
        public DateTime staringTime { get; set; }
        public double examDuration { get; set; }
        public double elapsedTime { get; set; } 
        public double result { get; set; }
        public int active { get; set; }
        public int finished { get; set; }
        public DateTime activationTime { get; set; }
        public int reservationID { get; set; }

        public ExamInstance()
        {
        }
    }
}