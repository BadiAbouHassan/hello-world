using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Threading;

namespace template.Admin
{
    public partial class addExamSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // to make the default date display in the system in this format ....
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = ci; 
            if (!IsPostBack)
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                try
                {
                    if (!IsPostBack)
                    {
                        this.fillExamsSelect();
                        this.fillClubsSelect();
                    }
                }
                catch (Exception ex)
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = ex.Message;
                }
            }
        }

        public void fillExamsSelect()
        {
            try
            {
                DBService.ExamService examService = new DBService.ExamService();
                DataSet ds = examService.getExamDataSet();
                examDDL.DataSource = ds;
                examDDL.DataTextField = "examName";
                examDDL.DataValueField = "examID";
                examDDL.DataBind();
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }

        public void fillClubsSelect()
        {
            try
            {
                DBService.HuntingClubService clubService = new DBService.HuntingClubService();
                DataSet ds = clubService.getClubsDataSet();
                clubDDL.DataSource = ds;
                clubDDL.DataTextField = "clubName";
                clubDDL.DataValueField = "clubID";
                clubDDL.DataBind();
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ExamSchedule schedule = new ExamSchedule();
                schedule.examID = int.Parse(examDDL.SelectedValue);
                schedule.clubID = int.Parse(clubDDL.SelectedValue);
                String dateTime = scheduleDateTime.SelectedDate.ToString("yyyy-MM-dd") + " " + hour.Value.ToString() + ":" + minutes.Value.ToString();
                schedule.scheduleDateTime = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm", null);
                schedule.numberOfSeats = int.Parse(numberOfSeats.Value.ToString());

                ExamScheduleController controller = new ExamScheduleController();
                if (controller.addExamSchedule(schedule))
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Exam Schedule saved successfuly!";
                }
                else
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error saving schedule data!";
                }
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }
    }
}