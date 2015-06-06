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
                throw new Exception("testing error message and exception how will be ");
                lbl1.Text = "";
                fillClubSelect();
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
            clubs = huntingClubService.getClubs();
            //DataSet ds= huntingClubService.getClubsDataSet();
            //club.DataSource = ds;
            //club.DataTextField = "clubname";
            //club.DataValueField = "ID";
            //club.DataBind();
            
        }

        public void btn_signup_reg_Click(object sender, EventArgs e)
        {

        }

        //sign in click
        public void signIn(object sender, EventArgs e)
        {
            lbl1.Text = "textss";
            try
            {
                String username_login = login_username.Value.ToString();
                String pass = login_password.Value.ToString();

                String loginHashed = MD5Hash.GetHash(pass);

                ClientService client_service = new ClientService();
                Client loggedClient = client_service.checkClientAuthentication(username_login, loginHashed);
                if (loggedClient == null)
                {
                    lbl1.Text = "Wrong username or password";
                }
                else
                {
                    lbl1.Text = "loggedUser in successfully";
                }

            }
            catch (Exception exc)
            {
                lbl1.Text = exc.Message;
            }

        }

    }
}