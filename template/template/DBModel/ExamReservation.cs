using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ExamReservation
    {
        public int reservationID { get; set; }
        public int examScheduleID { get; set; }
        public int applicantID { get; set; }
        public int referenceID { get; set; }


        public ExamReservation()
        {
        }
    }
}