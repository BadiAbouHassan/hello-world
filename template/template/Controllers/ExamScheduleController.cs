using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class ExamScheduleController
    {
        private ExamScheduleService examScheduleService;

        public ExamScheduleController()
        {
            this.examScheduleService = new ExamScheduleService();
        }

        public bool addExamSchedule(ExamSchedule schedule)
        {
            return this.examScheduleService.addExamSchedule(schedule);
        }

        public List<ExamSchedule> getExamSchedules(int examID = 0, int scheduleID = 0)
        {
            return this.examScheduleService.getExamSchedules(examID, scheduleID);
        }
    }
}