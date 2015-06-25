﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using System.Data;
using System.Net.Mail;
using System.Net;
using template.DBService;

namespace template.Admin
{
    public partial class assignExamSchedule : System.Web.UI.Page
    {
        DBModel.Applicant applicant;
        ApplicantController Appcontroller;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    errMsgDiv.Style.Add("display", "none");
                    successMsgDiv.Style.Add("display", "none");

                    int ID = int.Parse(Request.QueryString["applicantID"].ToString());

                    Appcontroller = new ApplicantController();

                    List<DBModel.Applicant> applicantList = Appcontroller.getApplicants(ID);
                    if (applicantList.Count > 0)
                    {
                         applicant = applicantList[0];

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

<<<<<<< HEAD
                        applicant = ((new ApplicantController()).getApplicants(int.Parse(Request.QueryString["applicantID"].ToString())))[0];

                        RegistrationRequests req = (new RegistrationRequestService()).getRequestByID(reservation.registerationID);
                        ExamSchedule sched = (new ExamScheduleService()).getExamSchedules(0, reservation.examScheduleID)[0];
                        HuntingClub club = (new HuntingClubService()).getClubofID(sched.clubID);
                        sendEmailConfirmation(applicant,club,sched,req);
=======
                        ApplicantController applicantController = new ApplicantController();

                        List<DBModel.Applicant> applicantList = applicantController.getApplicants(int.Parse(applicantID.Value));
                        if (applicantList.Count > 0)
                        {
                            DBModel.Applicant applicant = applicantList[0];
                            this.sendEmailConfirmation(applicant);
                        }
>>>>>>> d238f288bf2c9d245730237d595297d5c9a7bb5e
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

<<<<<<< HEAD
        private void sendEmailConfirmation(Applicant addedApplicant,HuntingClub club, ExamSchedule sched, RegistrationRequests req)
=======
        private void sendEmailConfirmation(Applicant addedApplicant)
>>>>>>> d238f288bf2c9d245730237d595297d5c9a7bb5e
        {

            using (MailMessage mm = new MailMessage("loopsolutions2015@gmail.com",
                addedApplicant.email))
            {

<<<<<<< HEAD
                mm.Subject = "تحديد  موعد امتحان الصيد ";
                string body = "  مرحبا " + addedApplicant.firstname + " , ";
                body += "<br /><br/>"+" لقد تم تعيين امتحان الصيد الخاص بك الذي تم التقديم اليه في التاريخ";
                body += req.registrationRequestsDate;
                body += "<br/> : على النحو التالي  ";
                body += "<br /><br/>  : تاريخ الامتحان";
                body +=sched.scheduleDateTime;
                body += "<br/> :  النادي";
                body += club.clubName;
                body += "<br /><br /> يرجى أن تكون في الوقت المحدد";
                body += "<br /> حظا موفقا";
                body += "<br /><br />شكرا";
=======
                mm.Subject = " الحساب";
                string body = "  مرحبا " + addedApplicant.firstname + " , ";
                body += "<br /><br />الرجاء الضغط على الرابط التالي لتفعيل حسابك";
                body += "<br /><br /><a href = 'http://localhost:50867/Login.aspx?ActivationCode=" + addedApplicant.activationCodeToken + "'>انقر هنا لتفعيل حسابك.</a>";
                body += "<br /><br />شكرا";



>>>>>>> d238f288bf2c9d245730237d595297d5c9a7bb5e
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
<<<<<<< HEAD

=======
>>>>>>> d238f288bf2c9d245730237d595297d5c9a7bb5e
    }
}