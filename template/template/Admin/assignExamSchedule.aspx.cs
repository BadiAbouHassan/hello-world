using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
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

            if (!IsPostBack)
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

                        DBService.RegistrationRequestService registerationService = new DBService.RegistrationRequestService();
                        RegistrationRequests registerationModel = registerationService.getRequestByApplicant(ID);
                        if (registerationModel != null)
                        {
                            registerationID.Value = registerationModel.registerationID.ToString();
                        }
                    }

                    this.fillExamSchedulesSelect();
                }
                catch (Exception ex)
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = ex.Message;
                }
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
                scheduledExam.DataValueField = "examScheduleID";
                scheduledExam.DataBind();
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
                DBModel.ExamReservation reservation = new ExamReservation();
                reservation.applicantID = int.Parse(applicantID.Value);
                reservation.examScheduleID = int.Parse(scheduledExam.Value.ToString());
                reservation.registerationID = int.Parse(registerationID.Value.ToString());

                ExamReservationController controller = new ExamReservationController();

                int reservationID = controller.addExamReservation(reservation);
                if (reservationID != 0)
                {
                    // Verify the registeration request at this step
                    DBService.RegistrationRequestService regService = new DBService.RegistrationRequestService();

                    if (regService.verifyRegisterationRequest(reservation.registerationID))
                    {
                        // Send email to the user to for exam date time confirmation

                        ApplicantController applicantController = new ApplicantController();

                        List<DBModel.Applicant> applicantList = applicantController.getApplicants(int.Parse(applicantID.Value));
                        if (applicantList.Count > 0)
                        {
                            DBModel.Applicant applicant = applicantList[0];
                            this.sendEmailConfirmation(applicant);
                        }
                        successMsgDiv.Style.Remove("display");
                        successMsg.Text = "Exam Schedule Saved successfuly!";
                    }
                }
                else
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error saving Exam Schedule!";
                }
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }

        private void sendEmailConfirmation(Applicant addedApplicant)
        {

            using (MailMessage mm = new MailMessage("loopsolutions2015@gmail.com",
                addedApplicant.email))
            {

                mm.Subject = " الحساب";
                string body = "  مرحبا " + addedApplicant.firstname + " , ";
                body += "<br /><br />الرجاء الضغط على الرابط التالي لتفعيل حسابك";
                body += "<br /><br /><a href = 'http://localhost:50867/Login.aspx?ActivationCode=" + addedApplicant.activationCodeToken + "'>انقر هنا لتفعيل حسابك.</a>";
                body += "<br /><br />شكرا";



                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("loopsolutions2015@gmail.com", "loops@2015");
                // smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}