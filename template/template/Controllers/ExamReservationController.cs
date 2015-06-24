using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class ExamReservationController
    {
        private ExamReservationService examReservationService;

        public ExamReservationController()
        {
            this.examReservationService = new ExamReservationService();
        }

        public int addExamReservation(ExamReservation reservation)
        {
            return this.examReservationService.addExamrRservation(reservation);
        }

        public List<ExamReservation> getExamReservations(int examID = 0, int scheduleID = 0, int applicantID = 0)
        {
            return this.examReservationService.getExamReservations(examID, scheduleID, applicantID);
        }
    }
}