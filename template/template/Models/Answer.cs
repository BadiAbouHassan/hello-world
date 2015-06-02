using System;
using System.Collections.Generic;
using System.Web;

namespace template.Models
{
    public class Answer
    {
        public int answerID { get; set; }
        public String title { get; set; }
        public int correct { get; set; }
        public int questionID { get; set; }


        public Answer()
        {
        }

    }
}