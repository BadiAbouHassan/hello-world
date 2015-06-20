using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin
{
    public partial class grantPermission : System.Web.UI.Page
    {
        public List<DBModel.Permission> permissions = new List<DBModel.Permission>();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.fillUsersSelect();
            }
            this.getPermissions();
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

        protected void GetPermissions_Click(object sender, EventArgs e)
        {
            PermissionsList.Items.Clear();
            // get the role of the selected User in order to get the granted permissions  
            UserController userController = new UserController();
            DBModel.User selectedUser = userController.getUserByID(int.Parse(Users.Value.ToString()));
            GrantedPermissionController grantedPermissionController = new GrantedPermissionController() ;
            List<DBModel.GrantedPermission> selectedUserGrantedPermission = grantedPermissionController.getGrantedPermission(selectedUser.role);

            for (int j = 0; j < permissions.Count; j++ )
            {
                Permission permission = permissions[j];
                // Must check if the permission is granted to this role ... 
                Boolean checkPermission = false;
                for (int i = 0; i < selectedUserGrantedPermission.Count; i++)
                {
                    GrantedPermission grantedPermission = selectedUserGrantedPermission[i];
                    if (grantedPermission.permissionID == permission.permissionID)
                    {
                        checkPermission = true;
                    }
                }
                PermissionsList.Items.Add(permission.name.ToString());
                if (checkPermission)
                {
                    PermissionsList.Items[j].Selected = true;
                }
            }
        }
    }
}