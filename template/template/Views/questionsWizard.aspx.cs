using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Views
{
    public partial class questionsWizard : System.Web.UI.Page
    {
        public DBModel.Applicant loggedApplicant;
        public List<DBModel.ExamQuestions> examQuestionsList;
        public List<Model.Question> questionsToView; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // to make the default date display in the system in this format ....
                CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
                ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
                Thread.CurrentThread.CurrentCulture = ci; 
                loggedApplicant = new DBModel.Applicant();
                examQuestionsList = new List<DBModel.ExamQuestions>();
                questionsToView = new List<Model.Question>() ; 
                // get the logged applicant 
                 
                loggedApplicant = (DBModel.Applicant)Session["logged_applicant"];
                if (loggedApplicant != null)
                {
                    // examQuestionList is being filled in the below fuction ... but only the questions to view is returned ...
                    questionsToView = getExamQuestions();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                 
            }
            catch (Exception exc)
            {
                String redirect_Location = "Views/homePage.aspx";
                Response.Redirect("../Views/errorHandler.aspx?exceptoin_msg=Internal Error Occured&redirect_locaiton=" + redirect_Location);
            }
        }
        /// <summary>
        /// function to check if the exam has been approved by admin and if yes return the exam question list... 
        /// </summary>
        /// <returns></returns>
        public List<Model.Question> getExamQuestions()
        {
            // get the registration request and check if it has been approbed by admin or not ... 
            DBService.ExamInstanceService examInstanceService = new DBService.ExamInstanceService();

            DBModel.ExamInstance examInstance = examInstanceService.getExamInstanceByApplicantID(loggedApplicant.applicantID);

            //intialize the list of Exam Question 
            List<DBModel.ExamQuestions> examQuestionsList = new List<DBModel.ExamQuestions>();
            List<Model.Question> questionsList = new List<Model.Question>();
            // must get the question by Course of this exam ... 
            DBService.QuestionsPerCourseService questionPerCourseService = new DBService.QuestionsPerCourseService();
            List<DBModel.QuestionsPerCourse> questionsPerCourseList = questionPerCourseService.getQuestionsByExam(examInstance.examID);
            foreach (DBModel.QuestionsPerCourse questionPerCourse in questionsPerCourseList)
            {
                // get course of exam question per course obj 
                DBService.CourseService courseService = new DBService.CourseService();
                DBModel.Course course = courseService.getCourseById(questionPerCourse.courseID);

                // go to the question bank and return questoins randomly ... 
                DBService.QuestionsBankService questionBankService = new DBService.QuestionsBankService();
                List<DBModel.QuestionsBank> questionBankList = questionBankService.getQuestionsByCourseID(questionPerCourse.courseID);
                List<DBModel.QuestionsBank> shuffledQuestions = this.ShuffleList(questionBankList);
                // looping on the number of question percourse in order to take questions from the shuffled question
                // add it to the examquestionlist ... 
                for (int i = 0; i < questionPerCourse.questionsPerCourseNo; i++)
                {
                    // filling into the exam quesiton List 
                    DBModel.ExamQuestions examQuestion = new DBModel.ExamQuestions();
                    examQuestion.examInstanceID = examInstance.instanceID;
                    examQuestion.questionID = shuffledQuestions[i].questionsID;
                    examQuestionsList.Add(examQuestion);
                    // filling qustion to view 
                    Model.Question question = new Model.Question();
                    question.description = shuffledQuestions[i].description;
                    question.questionsID = shuffledQuestions[i].questionsID;
                    question.title = shuffledQuestions[i].title;
                    DBService.AnswerService answerService = new DBService.AnswerService();
                    List<DBModel.Answer> answerList = answerService.getAnswers(question.questionsID);
                    question.answers = answerList;
                    questionsList.Add(question);
                }
            }
            this.examQuestionsList = examQuestionsList;
            return questionsList;
            
        }
   
        /// <summary>
        /// function to shuffle the list order ... 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="inputList"></param>
        /// <returns></returns>
        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}