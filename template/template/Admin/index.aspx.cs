using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.DBModel;
using template.DBService;

namespace template.Admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["logged_user"] != null)
            {
                DBModel.User loggeduser = (DBModel.User)Session["logged_user"];
                //chck the role of the user
                Role UserRole = loggeduser.role;
                List<Applicant> appList;
                //appplicants of user of admin club
                ApplicantService app_service = new ApplicantService();
                if (UserRole.roleName == "superadmin")
                {

                    appList = app_service.getAllApplicantsNotActivated();

                }
                else
                {
                    appList = app_service.getAllApplicantsOfClubNotActivated(loggeduser); //only view the applicants of the hunting club of the admin
                }
               
                if (appList.Count > 0)
                {
                    applicant_nb.Text = appList.Count.ToString();
                }

                //hunting club this month
                HuntingClubService clubService = new HuntingClubService();
                List<HuntingClub> clubList = clubService.getClubs();
                if (clubList.Count > 0)
                {
                    clubs_nb.Text = clubList.Count.ToString();
                }

                //Users of this club
                UserService usrService = new UserService();
                List<DBModel.User> usrList = usrService.getUsers();
                if (usrList.Count > 0)
                {
                    users_nb.Text = usrList.Count.ToString();
                }

                //exams
                ExamReservationService service = new ExamReservationService();
                String datenow = DateTime.Today.ToShortDateString();
                List<ExamReservation> list = service.getAllReservationsOfUserAfterToday(datenow);
                if (list.Count > 0)
                {
                    exams_nb.Text = list.Count.ToString();
                }
            }


        }
    }
}