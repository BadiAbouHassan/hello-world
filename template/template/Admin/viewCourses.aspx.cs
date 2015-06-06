using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.DBModel;
using template.DBService;
using template.Controllers;

namespace template.Admin
{
    public partial class viewCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                CourseController controller = new CourseController();

                List<Course> courses = controller.getCourses();

                if (courses != null)
                {
                    for (int i = 0; i < courses.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = courses[i].courseName;
                        tRow.Cells.Add(nameCell);

                        TableCell descCell = new TableCell();
                        descCell.Text = courses[i].courseDesc;
                        tRow.Cells.Add(descCell);

                        TableCell editCell = new TableCell();
                        editCell.Text = "<a href='/Admin/addCourse.aspx?courseID=" + courses[i].courseID + "'>Edit</a>";
                        tRow.Cells.Add(editCell);

                        TableCell deleteCell = new TableCell();
                        deleteCell.Text = "<a href='/Admin/deleteCourse.aspx?courseID=" + courses[i].courseID + "'>Delete</a>";
                        tRow.Cells.Add(deleteCell);
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