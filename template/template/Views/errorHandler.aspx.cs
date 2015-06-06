using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Views
{
    public partial class errorHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            redirect_location.HRef = Request.Params["redirect_locaiton"];
            lblValues.InnerText = Request.Params["exceptoin_msg"] ;

        }
    }
}