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
        String courseID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["courseID"] != null)
                {
                    courseID = Request.QueryString["courseID"];
                    fillCourse(courseID);
                }


            }
            errMsgDiv.Style.Add("display", "none");
            successMsgDiv.Style.Add("display", "none");
        }

        private void fillCourse(string courseID)
        {
             CourseController controller = new CourseController();
             try
             {
                 Course course = controller.getCourses(Int32.Parse(courseID))[0];
                 courseName.Value =course.courseName ;
                 courseDesc.Value =course.courseDesc ;
             }
             catch (Exception exc)
             {
                 errMsgDiv.Style.Remove("display");
                 errMsg.Text = exc.Message;
             }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CourseController controller = new CourseController();

                Course course = new Course();
                course.courseName = courseName.Value.ToString();
                course.courseDesc = courseDesc.Value.ToString();
                if (Request.QueryString["courseID"] != null)
                {
                    course.courseID = Int32.Parse(Request.QueryString["courseID"]);
                    if (!controller.updateCourse(course))
                    {
                        errMsgDiv.Style.Remove("display");
                        errMsg.Text = "Error Saving Course data!";
                    }

                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Course data updated successfuly!";
                }else if (!controller.addCourse(course))
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