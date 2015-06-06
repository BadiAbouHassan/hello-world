using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using template.DBModel;
using template.DBService;

namespace template.Admin
{
    public partial class addQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errMsgDiv.Style.Add("display", "none");
            successMsgDiv.Style.Add("display", "none");

            this.fillCourseSelect();
        }

        public void fillCourseSelect()
        {
            DBService.CourseService courseSerivce = new DBService.CourseService();
            DataSet ds = courseSerivce.getCourseDataSet();
            courses.DataSource = ds;
            courses.DataTextField = "courseName";
            courses.DataValueField = "ID";
            courses.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                QuestionsBank question = new QuestionsBank();
                question.courseID = int.Parse(courses.Value.ToString());
                question.title = questionTitle.Value.ToString();
                question.description = questionDesc.Value.ToString();

                QuestionsBankService serviceDB = new QuestionsBankService();
                int questionID = serviceDB.addQuestion(question);

                if (questionID != 0)
                {
                    AnswerService answerService = new AnswerService();

                    Answer answerModel = new Answer();
                    if (answer1.Value.ToString().Trim() != "")
                    {
                        answerModel.questionID = questionID;
                        answerModel.title = answer1.Value.ToString();
                        answerModel.correct = (correctAnswer.Value.ToString() == "1") ? 1 : 0;
                        answerService.addAnswer(answerModel);
                    }

                    if (answer2.Value.ToString().Trim() != "")
                    {
                        answerModel.questionID = questionID;
                        answerModel.title = answer2.Value.ToString();
                        answerModel.correct = (correctAnswer.Value.ToString() == "2") ? 1 : 0;
                        answerService.addAnswer(answerModel);
                    }

                    if (answer3.Value.ToString().Trim() != "")
                    {
                        answerModel.questionID = questionID;
                        answerModel.title = answer3.Value.ToString();
                        answerModel.correct = (correctAnswer.Value.ToString() == "3") ? 1 : 0;
                        answerService.addAnswer(answerModel);
                    }

                    if (answer4.Value.ToString().Trim() != "")
                    {
                        answerModel.questionID = questionID;
                        answerModel.title = answer4.Value.ToString();
                        answerModel.correct = (correctAnswer.Value.ToString() == "4") ? 1 : 0;
                        answerService.addAnswer(answerModel);
                    }

                    if (answer5.Value.ToString().Trim() != "")
                    {
                        answerModel.questionID = questionID;
                        answerModel.title = answer5.Value.ToString();
                        answerModel.correct = (correctAnswer.Value.ToString() == "5") ? 1 : 0;
                        answerService.addAnswer(answerModel);
                    }

                    if (answer6.Value.ToString().Trim() != "")
                    {
                        answerModel.questionID = questionID;
                        answerModel.title = answer6.Value.ToString();
                        answerModel.correct = (correctAnswer.Value.ToString() == "6") ? 1 : 0;
                        answerService.addAnswer(answerModel);
                    }

                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Question Saved successfuly!";
                }
                else
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error Saving Question!";
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