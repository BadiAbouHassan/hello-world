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
    public partial class addUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fillRoleSelect();
        }
        public void fillRoleSelect()
        {

            DBService.RoleService roleSerivce = new DBService.RoleService();
            DataSet ds = roleSerivce.getRoleDataSet();
            roles.DataSource = ds;
            roles.DataTextField = "roleName";
            roles.DataValueField = "roleId";
            roles.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserController controller = new UserController();

                if (pass.Value.ToString() != confirmPass.Value.ToString())
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Password do not match!";
                    return;
                }
                DBModel.User user = new DBModel.User();
                user.username = userName.Value.ToString();
                user.password = pass.Value.ToString();
                Role role = new Role();
                role.roleID = int.Parse(roles.Value.ToString());
                user.role = role;
                user.roleID = role.roleID;

                if (!controller.addUser(user))
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving user data!";
                }
                else
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "User data Saved successfuly!";
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