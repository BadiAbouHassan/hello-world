using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBService;

namespace template.Admin
{
    public partial class addClub : System.Web.UI.Page
    {
        String clubID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.fillUsersSelect();
                if (Request.QueryString["clubID"] != null)
                {
                    clubID = Request.QueryString["clubID"];
                    fillClub(clubID);
                }

               
            }
        }

        private void fillClub(string clubID)
        {
            try
            {
                HuntingClubController controller = new HuntingClubController();


                DBModel.HuntingClub huntingClub = controller.getHuntingClubByID(Int32.Parse(clubID));
                clubAddress.Value = huntingClub.clubAddress;
                clubName.Value = huntingClub.clubName;
                email.Value = huntingClub.email ;
                clubPhone.Value = huntingClub.phoneNb;
               // huntingClub.adminUserID = int.Parse(Users.Value.ToString()); 
                //get hunting club 
                DBModel.User userClub = (new UserController()).getUserByID(huntingClub.adminUserID);

                //ListItem li = Users.Items.FindByText("Three");
                ListItem li = Users.Items.FindByValue(userClub.userID.ToString());
                li.Selected = true;
               // Users.SelectedValue = userClub.firstName + "" + userClub.lastName;
      
            }
            catch (Exception exc)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = exc.Message;
            }
        }

        public void fillUsersSelect()
        {

            DBService.UserService userService = new DBService.UserService();
            DataSet ds = userService.getUsersDataSet();
            // must combine first name and last name in the ds . 
            // so we  will generate a new column to the data set .. 
            ds.Tables[0].Columns.Add("firstAndLast", typeof(string), "firstName +' '+ lastName");
            Users.DataSource = ds;
            Users.DataTextField = "firstAndLast" ;
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

                if (Request.QueryString["clubID"] != null)
                {
                    huntingClub.clubID = Int32.Parse(Request.QueryString["clubID"]);
                    if (!controller.updateHuntingClub(huntingClub))
                    {
                        errMsgDiv.Style.Remove("display");
                        errMsg.Text = "Error Saving Club data!";
                    }

                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Club data updated successfuly!";
                }else if (!controller.addHuntingClub(huntingClub))
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