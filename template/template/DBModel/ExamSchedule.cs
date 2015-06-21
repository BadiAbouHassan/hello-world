using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ExamSchedule
    {

        public int examScheduleID { get; set; }
        public int examID { get; set; }
        public int clubID { get; set; }
        public DateTime scheduleDateTime { get; set; }
        public int numberOfSeats { get; set; }

        public ExamSchedule()
        {
        }
    }
}