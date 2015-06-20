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
            // get the role of the selected User in order to get the granted permissions  
            UserController userController = new UserController();
            DBModel.User selectedUser = userController.getUserByID(int.Parse(Users.Value.ToString()));
            GrantedPermissionController grantedPermissionController = new GrantedPermissionController();
            List<DBModel.GrantedPermission> selectedUserGrantedPermission = grantedPermissionController.getGrantedPermission(selectedUser.role);

            // first check if the item (permission check box is selected or not ) 
            // it it is selected check if this permission is already in the old grated permission in order not to add it again ... 
            foreach (ListItem item in PermissionsList.Items)
            {
                if (item.Selected == true)
                {
                    // check if this user has already permission or not ... 
                    if (selectedUserGrantedPermission.Count > 0)
                    {
                        for (int i = 0; i < selectedUserGrantedPermission.Count; i++)
                        {
                            if (selectedUserGrantedPermission[i].permissionID != int.Parse(item.Value.ToString()))
                            {
                                // if does not equal that means the permission is not granted so must be add to the new list 
                                PermissionController permissionController = new PermissionController();
                                Permission permission = (permissionController.getPermissions(int.Parse(item.Value.ToString())))[0];
                                // intialize new GrantedPermission Object in order to be added to the new granted permission list 
                                GrantedPermission newGrantedPermission = new GrantedPermission();
                                newGrantedPermission.permissionID = int.Parse(item.Value.ToString());
                                newGrantedPermission.role = selectedUser.role;
                                newGrantedPermission.roleID = selectedUser.roleID;
                                newGrantedPermission.permission = permission;
                                // add the new granted permission to the DB .. 
                                grantedPermissionController.addGrantedPermission(newGrantedPermission);
                                //newGrantedPermissions.Add(newGrantedPermission); 
                            }
                        }
                    }
                    else
                    {
                        // if does not equal that means the permission is not granted so must be add to the new list 
                        PermissionController permissionController = new PermissionController();
                        Permission permission = (permissionController.getPermissions(int.Parse(item.Value.ToString())))[0];
                        // intialize new GrantedPermission Object in order to be added to the new granted permission list 
                        GrantedPermission newGrantedPermission = new GrantedPermission();
                        newGrantedPermission.permissionID = int.Parse(item.Value.ToString());
                        newGrantedPermission.role = selectedUser.role;
                        newGrantedPermission.roleID = selectedUser.roleID;
                        newGrantedPermission.permission = permission;
                        // add the new granted permission to the DB .. 
                        grantedPermissionController.addGrantedPermission(newGrantedPermission);
                    }
                }
                else 
                {
                    // if item is not selected must check if it is in the old granted permission or not .. 
                    // if yes must be deleted from the granted permission table ... 
                    for (int j = 0; j < selectedUserGrantedPermission.Count; j++)
                    {
                        if (selectedUserGrantedPermission[j].permissionID == int.Parse(item.Value.ToString()))
                        {
                            // remove the granted permission from db 
                            grantedPermissionController.deleteGrantedPermission(selectedUserGrantedPermission[j]);
                        }
                    }
                }
            }
            successMsgDiv.Style.Remove("display");
            successMsg.Text = "Permission data updated successfuly!";
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
                PermissionsList.Items[j].Value = permission.permissionID.ToString();
                if (checkPermission)
                {
                    PermissionsList.Items[j].Selected = true;
                }
            }
        }
    }
}