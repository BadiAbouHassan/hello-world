using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class ApplicantReportClass
    {
        public Applicant applicant { get; set; }
        public String referenceNb { get; set; }
        public String registrationDate { get; set; }
        public double fieldExamResult { get; set; }
        public Exam applicantExam { get; set; }
        public String examDate { get; set; }
        public double instanceExamResult { get; set; }
        public double totalMarks { get; set; }
        public String resultStatus { get; set; }
        public HuntingClub applicantClub { get; set; }

        public ApplicantReportClass()
        {
        }
    }
}