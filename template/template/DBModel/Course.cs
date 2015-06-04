using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class Course
    {
        public int courseID { get; set; }
        public String courseName { get; set; }
        public String courseDesc { get; set; }

        public Course()
        {
        }
    }
}