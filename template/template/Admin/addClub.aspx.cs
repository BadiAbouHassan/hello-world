using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;

namespace template.Admin
{
    public partial class addClub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fillUsersSelect();
        }

        public void fillUsersSelect()
        {

            DBService.UserService userService = new DBService.UserService();
            DataSet ds = userService.getUsersDataSet();
            Users.DataSource = ds;
            Users.DataTextField = "firstName" ;
            Users.DataValueField = "userID";
            Users.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HuntingClubController controller = new HuntingClubController();

                
                DBModel.HuntingClub huntingClub = new DBModel.HuntingClub();
                huntingClub.clubAddress = clubAddress.Value.ToString();
                huntingClub.clubName = clubName.Value.ToString();
                huntingClub.email = email.Value.ToString();
                huntingClub.phoneNb = clubPhone.Value.ToString();
                huntingClub.adminUserID = int.Parse(Users.Value.ToString()); 
                if (!controller.addHuntingClub(huntingClub))
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving Club data!";
                }
                else
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Club data Saved successfuly!";
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