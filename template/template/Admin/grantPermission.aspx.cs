using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;

namespace template.Admin
{
    public partial class grantPermission : System.Web.UI.Page
    {
        public List<DBModel.Permission> permissions = new List<DBModel.Permission>();
        public List<DBModel.Permission> userPermissions = new List<DBModel.Permission>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getPermissions();
            this.fillUsersSelect();
        }
        public void getPermissions()
        {
            PermissionController permissionController = new PermissionController();
            permissions = permissionController.getPermissions();
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