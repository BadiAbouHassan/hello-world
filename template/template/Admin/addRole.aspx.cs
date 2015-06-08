using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Admin.User
{
    public partial class addRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBService.RoleService controller = new DBService.RoleService();

                DBModel.Role role = new DBModel.Role();
                role.roleName = rolesName.Value.ToString();
                role.predefined = 0; // 0 means false  

                if (!controller.add(role))
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