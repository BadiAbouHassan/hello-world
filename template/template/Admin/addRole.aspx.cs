using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin.User
{
    public partial class addRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["roleID"] != null)
                {
                    int roleID = int.Parse(Request.QueryString["roleID"]);
                    fillRole(roleID);
                }
            }
            
        }
        protected void fillRole(int roleID)
        {
            RoleController roleController = new RoleController();
            Role role = roleController.getRole(roleID)[0];
            rolesName.Value = role.roleName; 
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBService.RoleService controller = new DBService.RoleService();
                DBModel.Role role = new DBModel.Role();
                role.roleName = rolesName.Value.ToString();
                role.predefined = 0; // 0 means false  
                if (Request.QueryString["roleID"] != null)
                {
                    role.roleID = int.Parse(Request.QueryString["roleID"]);
                    controller.updateRole(role);
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Role data Updated successfuly!";
                }
                else if (!controller.add(role))
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving Role data!";
                }
                else
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Role data Saved successfuly!";
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