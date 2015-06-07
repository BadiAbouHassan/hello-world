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
                //throw new Exception("testing error message and exception how will be ");
                lbl1.Text = "";
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
                    lbl1.Text = "اسم المستخدم أو كلمة المرور خاطئة";
                }
                else
                {
                    lbl1.Text = " نجاح الدخول ";
                    Session["logged_applicant"] = loggedClient;
                    Response.Redirect("~/Views/homePage.aspx", false);

                    // label1.Text = "Succcessfully added";
                }

            }
            catch (Exception exc)
            {
                lbl1.Text = exc.Message;
            }

        }

    }
}