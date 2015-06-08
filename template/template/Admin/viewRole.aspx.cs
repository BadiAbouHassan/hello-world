using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin.User
{
    public partial class viewRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                RoleController controller = new RoleController();

                List<Role> roles = controller.getRole();

                if (roles != null)
                {
                    for (int i = 0; i < roles.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = roles[i].roleID.ToString();
                        tRow.Cells.Add(nameCell);

                        TableCell descCell = new TableCell();
                        descCell.Text = roles[i].roleName;
                        tRow.Cells.Add(descCell);

                        TableCell durationCell = new TableCell();
                        durationCell.Text = roles[i].predefined == 0 ? "False": "True";
                        tRow.Cells.Add(durationCell);
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