using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            lbl1.Text = "";
            fillClubSelect();
        }

        public void fillClubSelect()
        {
            DBService.HuntingClubService huntingClubService = new DBService.HuntingClubService();
            DataSet ds= huntingClubService.getClubsDataSet();
            club.DataSource = ds;
            club.DataTextField = "clubname";
            club.DataValueField = "ID";
            club.DataBind();
            
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

                UserController user_controller = new UserController();
                User loggedUser = user_controller.checkUserAuthentication(username_login, loginHashed);
                if (loggedUser == null)
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