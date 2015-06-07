using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Views
{
    public partial class logoutApplicant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // must only destroy the session that corresponds to the applicant 
            Session["logged_applicat"] = null;
            Response.Redirect("../Login.aspx");
        }
    }
}