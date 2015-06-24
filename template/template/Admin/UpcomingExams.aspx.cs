using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using template.DBService;

namespace template.Admin
{
    public partial class UpcomingExams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ExamReservation> examReservation;
            ExamScheduleController controller = new ExamScheduleController();
            Applicant app;
            ExamSchedule sched;
            HuntingClub club;

            //get the logged user
            DBModel.User loggedAdmin = (DBModel.User)Session["logged_user"];

            //chck the role of the user
            Role UserRole = loggedAdmin.role;

            if (Request.QueryString["exams"] != null)
            {
                String datenoew = DateTime.Today.ToShortDateString();
                if (UserRole.roleName == "superadmin")
                {

                    examReservation = (new ExamReservationService()).getAllReservationsOfUserAfterToday(datenoew);
                }
                else
                {
                    examReservation = (new ExamReservationService()).getAllReservationsOfUserAfterToday(datenoew, loggedAdmin);
                }

                if (examReservation.Count > 0)
                {
                    foreach (ExamReservation ex in examReservation)
                    {
                        app = (new ApplicantService()).getApplicantOfID(ex.applicantID);
                        sched = (new ExamScheduleService()).getExamSchedules(0, ex.examScheduleID)[0];
                        club = (new HuntingClubService()).getClubofID(sched.clubID);

                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = app.firstname +" "+app.middlename +" "+app.lastname;
                        tRow.Cells.Add(nameCell);

                        TableCell clubNameCell = new TableCell();
                        clubNameCell.Text = club.clubName;
                        tRow.Cells.Add(clubNameCell);

                        TableCell scheduledTimeCell = new TableCell();
                        scheduledTimeCell.Text = sched.scheduleDateTime.ToString();
                        tRow.Cells.Add(scheduledTimeCell);

                

                    }

                }
            }

        }
    }
}