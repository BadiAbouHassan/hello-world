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

                if (!controller.addPermission(permission))
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