using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;

namespace template.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserController controller = new UserController();
                String username = user_name.Value.ToString();
                String pass = password.Value.ToString();
                DBModel.User user = controller.checkUserAuthentication(username, pass);
                if (user == null)
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Wrong user name or password";
                    return;
                }
                else
                {
                    Session["logged_user"] = user;
                    Response.Redirect("index.aspx");
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