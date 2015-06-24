using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace template.Views
{
    public partial class questionWizardResult : System.Web.UI.Page
    {
        public int no_questions = 0 ;
        public int no_correct_answer = 0;
        public int no_worong_answer = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            no_questions = int.Parse(Request.Form["no_questions"].ToString());
            this.checkQuesitons(); 
   
        }

        public void checkQuesitons() 
        {
            DBService.QuestionsBankService questionBankService = new DBService.QuestionsBankService();
            DBService.AnswerService answerService = new DBService.AnswerService(); 
            for (int i = 0; i < no_questions; i++)
            {
                DBModel.QuestionsBank question = questionBankService.getQuestions(int.Parse(Request.Form["question" + (i + 1)]))[0];// get only the first item of the list 
                // get the answer list of this question ... in order to get the correct one ... 
                List<DBModel.Answer> answers = answerService.getAnswers(question.questionsID);
                DBModel.Answer yourAnswer = answerService.getAnswerByID(int.Parse(Request.Form["optradio" + (i + 1)].ToString()));
                int correct_answer_id = 0; 
                foreach (DBModel.Answer answer in answers ) 
                {
                    if (answer.correct == 1)
                    {
                        correct_answer_id = answer.answerID;
                        break;
                    }
                }
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);

                // Create a new cell and add it to the row.
                TableCell questionTxt = new TableCell();
                questionTxt.Text = question.title;
                tRow.Cells.Add(questionTxt);

                TableCell yourAnswertxt = new TableCell();
                yourAnswertxt.Text = yourAnswer.title;
                tRow.Cells.Add(yourAnswertxt);

                if(int.Parse(Request.Form["optradio"+(i+1)].ToString()) == correct_answer_id)
                {
                    no_correct_answer++;
                }
            }
            no_worong_answer = no_questions - no_correct_answer;
        }
    }
}