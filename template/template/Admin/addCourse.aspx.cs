using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin
{
    public partial class addCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errMsgDiv.Style.Add("display", "none");
            successMsgDiv.Style.Add("display", "none");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CourseController controller = new CourseController();

                Course course = new Course();
                course.courseName = courseName.Value.ToString();
                course.courseDesc = courseDesc.Value.ToString();

                if (!controller.addCourse(course))
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving course data!";
                }
                else
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Course data Saved successfuly!";
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