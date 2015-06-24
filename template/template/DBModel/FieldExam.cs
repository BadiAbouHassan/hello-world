using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class FieldExam
    {
        public int fieldExamID { get; set; }
        public int examInstanceID { get; set; }
        public decimal result { get; set; }
        public string notes { get; set; }
    }
}