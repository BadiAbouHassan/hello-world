using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Admin
{
    public partial class addExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                errMsgDiv.Style.Add("display", "none");
                successMsgDiv.Style.Add("display", "none");

                try
                {
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

                            TextBox input = new TextBox();
                            input.ID = "courseQuestionsNo-" + courses[i].courseID;

                            TableCell inputCell = new TableCell();
                            inputCell.Controls.Add(input);
                            tRow.Cells.Add(inputCell);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ExamController controller = new ExamController();

                Exam exam = new Exam();
                exam.examName = examName.Value.ToString();
                exam.examDescription = examDescription.Value.ToString();
                exam.examDuration = double.Parse(examDuration.Value.ToString());
                exam.numberOfQuestions = int.Parse(numberOfQuestions.Value.ToString());
                exam.passingMark = double.Parse(passingMark.Value.ToString());
                exam.questionMark = double.Parse(questionMark.Value.ToString());

                int examID = controller.addExam(exam);
                if (examID != 0)
                {

                    CourseController coursesController = new CourseController();
                    List<Course> courses = coursesController.getCourses();

                    List<QuestionsPerCourse> questionsPerCourseList = new List<QuestionsPerCourse>();
                    string[] keys = Request.Form.AllKeys;
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (keys[i].Contains("courseQuestionsNo"))
                        {
                            //"ctl00$ContentPlaceHolder1$numberOfQuestions-1
                            string[] keyParts = keys[i].Split('$');
                            if (keyParts.Length > 0)
                            {
                                QuestionsPerCourse questionNo = new QuestionsPerCourse();
                                questionNo.questionsPerCourseNo = int.Parse(Request.Form[keys[i]]);
                                string[] courseID = keyParts[2].Split('-');
                                questionNo.courseID = int.Parse(courseID[1]);
                                questionNo.examID = examID;

                                questionsPerCourseList.Add(questionNo);
                            }
                        }
                    }

                    if (questionsPerCourseList.Count > 0)
                    {
                        for (int i = 0; i < questionsPerCourseList.Count; i++)
                        {
                            QuestionsPerCourseController questionsController = new QuestionsPerCourseController();
                            questionsController.addQuestion(questionsPerCourseList[i]);
                        }
                    }

                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Exam data Saved successfuly!";
                }
                else
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving Exam data!";
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