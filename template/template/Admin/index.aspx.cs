using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
            // to make the default date display in the system in this format ....
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = ci; 
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
                    appRef.Attributes["href"] = "viewApplicants.aspx?applicants=" + appList;
                }

                //hunting club this month
                HuntingClubService clubService = new HuntingClubService();
                List<HuntingClub> clubList = clubService.getClubs();
                if (clubList.Count > 0)
                {
                    clubs_nb.Text = clubList.Count.ToString();
                    clubRef.Attributes["href"] = "viewClubs.aspx?clubs=" + clubList;
                }

                //Users of this club
                UserService usrService = new UserService();
                List<DBModel.User> usrList = usrService.getClubUsers(loggeduser.userID);
                if (usrList.Count > 0)
                {
                    users_nb.Text = usrList.Count.ToString();
                    usrRef.Attributes["href"] = "viewUser.aspx?users=" + usrList;
                }

                //exams
                ExamReservationService service = new ExamReservationService();
                String datenow = DateTime.Today.ToShortDateString();
                List<ExamReservation> list;
                if (UserRole.roleName == "superadmin")
                {
                    list = service.getAllReservationsOfUserAfterToday(datenow);
                }
                else
                {
                    list = service.getAllReservationsOfUserAfterToday(datenow,loggeduser);
                }
                if (list.Count > 0)
                {
                    exams_nb.Text = list.Count.ToString();
                    examRef.Attributes["href"] = "UpcomingExams.aspx?exams=" + list;
                }
            }


        }
    }
}