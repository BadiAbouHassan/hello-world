using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.DBModel;
using template.Controllers;
using template.DBService;

namespace template.Admin
{
    public partial class viewExamSchedules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");
                List<ExamSchedule> examSchedules = new List<ExamSchedule>() ;
               
                ExamScheduleController controller = new ExamScheduleController();

               
               

                    examSchedules = controller.getExamSchedules();
              
                if (examSchedules != null)
                {
                    for (int i = 0; i < examSchedules.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = examSchedules[i].examName;
                        tRow.Cells.Add(nameCell);

                        TableCell clubNameCell = new TableCell();
                        clubNameCell.Text = examSchedules[i].clubName;
                        tRow.Cells.Add(clubNameCell);

                        TableCell scheduledTimeCell = new TableCell();
                        scheduledTimeCell.Text = examSchedules[i].scheduleDateTime.ToString();
                        tRow.Cells.Add(scheduledTimeCell);

                        TableCell numberOfSeatsCell = new TableCell();
                        numberOfSeatsCell.Text = examSchedules[i].numberOfSeats.ToString();
                        tRow.Cells.Add(numberOfSeatsCell);

                        TableCell editCell = new TableCell();
                        editCell.Text = "<a href='/Admin/addExam.aspx?examID=" + examSchedules[i].examScheduleID + "'>Edit</a>";
                        tRow.Cells.Add(editCell);

                        TableCell deleteCell = new TableCell();
                        deleteCell.Text = "<a href='/Admin/deleteExam.aspx?examID=" + examSchedules[i].examScheduleID + "'>Delete</a>";
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