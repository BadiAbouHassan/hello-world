using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using System.Data;

namespace template.Admin
{
    public partial class assignExamSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                int ID = int.Parse(Request.Params["applicantID"].ToString());

                ApplicantController controller = new ApplicantController();

                List<DBModel.Applicant> applicantList = controller.getApplicants(ID);
                if (applicantList.Count > 0)
                {
                    DBModel.Applicant applicant = applicantList[0];

                    applicantID.Value = ID.ToString();
                    applicantName.Text = applicant.firstname + " " + applicant.middlename + " " + applicant.lastname;
                }

                this.fillExamSchedulesSelect();
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }

        public void fillExamSchedulesSelect()
        {
            try
            {
                DBService.ExamScheduleService scheduleService = new DBService.ExamScheduleService();
                DataSet ds = scheduleService.getSchedulesDataSet();
                scheduledExam.DataSource = ds;
                scheduledExam.DataTextField = "examName";
                scheduledExam.DataValueField = "examID";
                scheduledExam.DataBind();
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }
    }
}