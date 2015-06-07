using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin
{
    public partial class viewExams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                ExamController controller = new ExamController();

                List<Exam> exams = controller.getExams();

                if (exams != null)
                {
                    for (int i = 0; i < exams.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                        TableCell nameCell = new TableCell();
                        nameCell.Text = exams[i].examName;
                        tRow.Cells.Add(nameCell);

                        TableCell descCell = new TableCell();
                        descCell.Text = exams[i].examDescription;
                        tRow.Cells.Add(descCell);

                        TableCell durationCell = new TableCell();
                        durationCell.Text = exams[i].examDuration.ToString();
                        tRow.Cells.Add(durationCell);

                        TableCell questionNoCell = new TableCell();
                        questionNoCell.Text = exams[i].numberOfQuestions.ToString();
                        tRow.Cells.Add(questionNoCell);

                        TableCell questionMarkCell = new TableCell();
                        questionMarkCell.Text = exams[i].questionMark.ToString();
                        tRow.Cells.Add(questionMarkCell);

                        TableCell passingMarkCell = new TableCell();
                        passingMarkCell.Text = exams[i].passingMark.ToString();
                        tRow.Cells.Add(passingMarkCell);

                        TableCell editCell = new TableCell();
                        editCell.Text = "<a href='/Admin/addExam.aspx?examID=" + exams[i].examID + "'>Edit</a>";
                        tRow.Cells.Add(editCell);

                        TableCell deleteCell = new TableCell();
                        deleteCell.Text = "<a href='/Admin/deleteExam.aspx?examID=" + exams[i].examID + "'>Delete</a>";
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