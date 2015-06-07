using System;
using System.Collections.Generic;
using System.Web;

namespace template.Model
{
    public class Question
    {
        public int questionsID { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public List<DBModel.Answer> answers { get; set; }

        public Question() { }
    }
}