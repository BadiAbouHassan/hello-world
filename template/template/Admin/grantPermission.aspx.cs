using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Admin
{
    public partial class grantPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fillUsersSelect();
        }

        public void fillUsersSelect()
        {

            DBService.UserService userService = new DBService.UserService();
            DataSet ds = userService.getUsersDataSet();
            // must combine first name and last name in the ds . 
            // so we  will generate a new column to the data set .. 
            ds.Tables[0].Columns.Add("firstAndLast", typeof(string), "firstName +' '+ lastName");
            Users.DataSource = ds;
            Users.DataTextField = "firstAndLast";
            Users.DataValueField = "userID";
            Users.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}