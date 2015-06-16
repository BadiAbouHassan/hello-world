using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin.User
{
    public partial class addPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["permissionID"] != null)
                {
                    int permissionID = int.Parse(Request.QueryString["permissionID"]);
                    fillpermission(permissionID);
                }
            }
        }
        private void fillpermission(int permissionID)
        {
            PermissionController permissionController = new PermissionController();
            Permission permission = permissionController.getPermissions(permissionID)[0];
            permissionCode.Value = permission.code;
            permissionName.Value = permission.name; 
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(permissionName.Value.ToString() == String.Empty || permissionCode.Value.ToString() == String.Empty )
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Permission Name and Code can not be empty !!!";
                }
                PermissionController controller = new PermissionController();

                Permission permission = new Permission();
                permission.name = permissionName.Value.ToString();
                permission.code = permissionCode.Value.ToString();
                if (Request.QueryString["permissionID"] != null)
                {
                    permission.permissionID = int.Parse(Request.QueryString["permissionID"]);
                    controller.updatePermission(permission);
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Permission data Updated successfuly!";

                }
                else if (!controller.addPermission(permission))
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving Permission data!";
                }
                else
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Permission data Saved successfuly!";
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