using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin.User
{
    public partial class viewPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                PermissionController controller = new PermissionController();

                List<Permission> permissions = controller.getPermissions();

                if (permissions != null)
                {
                    for (int i = 0; i < permissions.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = permissions[i].permissionID.ToString();
                        tRow.Cells.Add(nameCell);

                        TableCell descCell = new TableCell();
                        descCell.Text = permissions[i].name;
                        tRow.Cells.Add(descCell);

                        TableCell durationCell = new TableCell();
                        durationCell.Text = permissions[i].code;
                        tRow.Cells.Add(durationCell);

                        TableCell editCell = new TableCell();
                        editCell.Text = "<a href='/Admin/addPermission.aspx?permissionID=" + permissions[i].permissionID+ "'>Edit</a>";
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