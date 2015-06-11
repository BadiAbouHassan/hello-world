using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
namespace template.Admin.User
{
    public partial class viewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                UserController controller = new UserController();

                List<DBModel.User> users = controller.getUsers();

                if (users != null)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = users[i].userID.ToString(); 
                        tRow.Cells.Add(nameCell);

                        TableCell descCell = new TableCell();
                        descCell.Text = users[i].username;
                        tRow.Cells.Add(descCell);

                        TableCell password = new TableCell();
                        password.Text = users[i].password;
                        tRow.Cells.Add(password);

                        TableCell firstname = new TableCell();
                        firstname.Text = users[i].firstName;
                        tRow.Cells.Add(firstname);

                        TableCell lastname = new TableCell();
                        lastname.Text = users[i].lastName;
                        tRow.Cells.Add(lastname);

                        TableCell email= new TableCell();
                        email.Text = users[i].email;
                        tRow.Cells.Add(email);

                        TableCell role = new TableCell();
                        role.Text = users[i].role.roleName;
                        tRow.Cells.Add(role);
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