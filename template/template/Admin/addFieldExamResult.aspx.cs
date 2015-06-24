using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Admin
{
    public partial class addFieldExamResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    errMsgDiv.Style.Add("display", "none");
                    successMsgDiv.Style.Add("display", "none");

                    int ID = int.Parse(Request.Params["applicantID"].ToString());

                    if (ID != 0)
                    {
                        Controllers.ApplicantController controller = new Controllers.ApplicantController();

                        List<DBModel.Applicant> applicantList = controller.getApplicants(ID);
                        if (applicantList.Count > 0)
                        {
                            DBModel.Applicant applicant = applicantList[0];

                            applicantID.Value = ID.ToString();
                            applicantName.Text = applicant.firstname + " " + applicant.middlename + " " + applicant.lastname;

                            DBService.ExamInstanceService examInstanceService = new DBService.ExamInstanceService();

                            DBModel.ExamInstance examInstance = examInstanceService.getExamInstanceByApplicantID(ID);
                            examInstanceID.Value = examInstance.instanceID.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = ex.Message;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.FieldExamController controller = new Controllers.FieldExamController();

                DBModel.FieldExam fieldExam = new DBModel.FieldExam();
                fieldExam.examInstanceID = int.Parse(examInstanceID.Value.ToString());
                fieldExam.notes = fieldExamNotes.Value.ToString();
                fieldExam.result = decimal.Parse(fieldExamResult.Value.ToString());

                int fieldExamID = controller.addFieldExamResult(fieldExam);

                if (fieldExamID != 0)
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Field Exam result saved successfuly!";
                }
                else
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error saving Field Exam result!";
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