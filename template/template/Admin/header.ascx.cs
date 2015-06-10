using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Admin
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBModel.User user = (DBModel.User)Session["logged_user"];
            if (user == null)
            {
                Response.Redirect("login.aspx");
            }

        }
    }
}