using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin
{
    public partial class viewClubs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                HuntingClubController controller = new HuntingClubController();

                List<HuntingClub> clubs = controller.getHuntingClubs();

                if (clubs != null)
                {
                    for (int i = 0; i < clubs.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = clubs[i].clubID.ToString();
                        tRow.Cells.Add(nameCell);

                        TableCell descCell = new TableCell();
                        descCell.Text = clubs[i].clubName;
                        tRow.Cells.Add(descCell);

                        TableCell password = new TableCell();
                        password.Text = clubs[i].clubAddress;
                        tRow.Cells.Add(password);

                        TableCell role = new TableCell();
                        role.Text = clubs[i].phoneNb;
                        tRow.Cells.Add(role);

                        TableCell email = new TableCell();
                        email.Text = clubs[i].email;
                        tRow.Cells.Add(email);

                        TableCell adminID = new TableCell();
                        adminID.Text = clubs[i].user.firstName.ToString() + " " + clubs[i].user.lastName.ToString();
                        tRow.Cells.Add(adminID);

                        TableCell editCell = new TableCell();
                        editCell.Text = "<a href='/Admin/addClub.aspx?clubID=" + clubs[i].clubID + "'>Edit</a>";
                        tRow.Cells.Add(editCell);
                    }
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