using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Admin
{
    public partial class activateExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // to make the default date display in the system in this format ....
                CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
                ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
                Thread.CurrentThread.CurrentCulture = ci; 
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                int ID = int.Parse(Request.Params["applicantID"].ToString());

                if (ID != 0)
                {
                    // get the registration request and check if it has been approbed by admin or not ... 
                    DBService.RegistrationRequestService registrationService = new DBService.RegistrationRequestService();
                    DBModel.RegistrationRequests registrationRequest = registrationService.getRequestByApplicant(ID);
                    if (registrationRequest.verifiedByAdmin == 0)
                    {
                        // still not verified 
                        Response.Redirect("~/Login.aspx");
                    }
                    // if request have been varified by Admin ...
                    // first must get the exam .. active exam ... 
                    DBService.ExamService examService = new DBService.ExamService();
                    List<DBModel.Exam> exams = examService.getExams();
                    if (exams.Count > 0)
                    {
                        DBModel.Exam exam = exams[0];
                        // must first create an exam instance 
                        DBModel.ExamInstance examInstance = new DBModel.ExamInstance();
                        examInstance.elapsedTime = 0;
                        examInstance.staringTime = DateTime.Now;
                        examInstance.examDuration = exam.examDuration;
                        examInstance.examID = exam.examID;

                        // Get Exam Reservation information by applicantID
                        Controllers.ExamReservationController controller = new Controllers.ExamReservationController();
                        List<DBModel.ExamReservation> reservation = controller.getExamReservations(0, 0, ID);
                        if (reservation.Count > 0)
                        {
                            examInstance.reservationID = reservation[0].reservationID;
                            examInstance.active = 1;
                            examInstance.activationTime = DateTime.Now;// must be changed later 
                            // add exam instance to the db in order to create instance id ... used later ... 
                            DBService.ExamInstanceService examInstanceService = new DBService.ExamInstanceService();
                            examInstance.instanceID = examInstanceService.addExamInstance(examInstance);

                            if (examInstance.instanceID != 0)
                            {
                                successMsg.Style.Remove("display");
                                successMsg.Text = "Exam Activated successfuly";
                            }
                            else
                            {
                                errMsgDiv.Style.Remove("display");
                                errMsg.Text = "Failed to activate the exam";
                            }
                        }
                        else
                        {
                            errMsgDiv.Style.Remove("display");
                            errMsg.Text = "There is no exam reservation for this Applicant, please assign an exam schedule to this Applicant first";
                        }
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
}