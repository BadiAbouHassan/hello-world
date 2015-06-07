using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Views
{
    public partial class questionsWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the logged applicant 
            DBModel.Applicant loggedApplicant = (DBModel.Applicant)Session["logged_applicant"];
            // first must get registration request for this applicant ... 
        }
    }
}