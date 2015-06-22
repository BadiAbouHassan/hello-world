using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using template.DBService;

namespace template
{
    public partial class Login : System.Web.UI.Page
    {
        public List<HuntingClub> clubs = new List<HuntingClub>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                fillClubSelect();
                
                if (Request.QueryString["ActivationCode"] != null)
                {
                    ApplicantService client_controller = new ApplicantService();
                    Applicant app = client_controller.getApplicantOfActivationCode(Request.QueryString["ActivationCode"]);
                    client_controller.activateApplicantByID(app.applicantID);
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "تم تفعيل حسابك بنجاح";
                }
            }
            catch(Exception exc)
            {
                String redirect_Location = "../Login.aspx";
                Response.Redirect("Views/errorHandler.aspx?exceptoin_msg=" + exc.Message + "&redirect_locaiton=" + redirect_Location);
            }
        }

        public void fillClubSelect()
        {
            DBService.HuntingClubService huntingClubService = new DBService.HuntingClubService();
            DataSet ds = huntingClubService.getClubsDataSet();
            clubs = huntingClubService.getClubs();

        }


        public void btn_signup_reg_Click(object sender, EventArgs e)
        {

        }

        //sign in click
        public void signIn(object sender, EventArgs e)
        {
            try
            {
                String username_login = login_username.Value.ToString();
                String pass = login_password.Value.ToString();

                String loginHashed = MD5Hash.GetHash(pass);

                ApplicantService client_service = new ApplicantService();
                Applicant loggedClient = client_service.checkApplicantAuthentication(username_login, loginHashed);
                if (loggedClient == null)
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "اسم المستخدم أو كلمة المرور خاطئة";
                }
                else
                {
                    if (loggedClient.accountActivated == 1)
                    {
                        successMsg.Style.Remove("display");
                        successMsg.Text = " نجاح الدخول ";
                        Session["logged_applicant"] = loggedClient;
                        Response.Redirect("~/Views/homePage.aspx", false);
                    }
                    else
                    {
                        errMsgDiv.Style.Remove("display");
                        errMsg.Text = " لم يتم تنشيط الحساب الخاص بك حتى الآن، يرجى التحقق من عنوان البريد الإلكتروني الخاص بك للنقر على الرابط لتفعيل حسابك";
                    }

                }

            }
            catch (Exception exc)
            {
                String redirect_Location = "../Login.aspx";
                Response.Redirect("Views/errorHandler.aspx?exceptoin_msg=" + exc.Message + "&redirect_locaiton=" + redirect_Location);

            }

        }

    }
}