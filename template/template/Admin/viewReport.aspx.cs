using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.DBModel;
using template.DBService;

namespace template.Admin
{
    public partial class viewReport : System.Web.UI.Page
    {
        public List<HuntingClub> clubs = new List<HuntingClub>();

        int totalApplicants=0;
        int totalPassedResults=0;
        int totalFailedResults=0;
        int totalLebanesePassed=0;
        int totalNotLebanesePassed=0;
        int totalLebanse = 0;
        int totalNotLebanese = 0;
        ApplicantService appService;
        ExamReservationService resService;
        ExamInstanceService examInstanceService;
        FieldExamService fieldExamService;
        List<ExamReservation> resList;
        List<Applicant> appList;
        List<FieldExam> fieldList;
        List<RegistrationRequests> reqList;
        List<ApplicantReportClass> reportList;

        double totalExp, totalField;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                examInstanceService = new ExamInstanceService();
                resService = new ExamReservationService();
                appService = new ApplicantService();
                fieldExamService = new FieldExamService();
                reportList = new List<ApplicantReportClass>();
                fillClubSelect();

                //initially get all data the sort in case user wnt to
                getAllReportResults();
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text =ex.Message;
            }
        }

        public void getAllReportResults()
        {
            resList = resService.getExamReportReservation();
            if (resList.Count > 0)
            {
                List<ApplicantReportClass> list = fillReportResults(resList);
                filltable(list);
            }
        }

        private List<ApplicantReportClass> fillReportResults(List<ExamReservation>resList)
        {
            List<ApplicantReportClass> reportList = new List<ApplicantReportClass>();
            //get applicants list
            foreach (ExamReservation ex in resList)
            {
                ApplicantReportClass arc = new ApplicantReportClass();
                Applicant app = appService.getApplicantOfID(ex.applicantID);
                arc.applicant = app;

                ExamSchedule sched = (new ExamScheduleService()).getExamSchedules(0,ex.examScheduleID)[0];
                arc.examDate = sched.scheduleDateTime.ToShortDateString();

                HuntingClub club = (new HuntingClubService()).getClubofID(sched.clubID);
                arc.applicantClub = club;

                ExamInstance inst = examInstanceService.getExamInstanceByApplicantID(app.applicantID);
                arc.instanceExamResult = inst.result;
                int examID = inst.examID;

                Exam exm = (new ExamService()).getExamByID(examID);
                arc.applicantExam = exm;

                List<FieldExam> fieldList = fieldExamService.getFieldExamResult(inst.instanceID);
                if (fieldList.Count > 0)
                {
                    FieldExam field = fieldList[0];
                    arc.fieldExamResult = (double)field.result;
                }
                reportList.Add(arc);
              
            }

            totalApplicants = reportList.Count;
            //get the total marks of two exams for each applicant
            foreach (ApplicantReportClass arc in reportList)
            {
                arc.totalMarks = arc.fieldExamResult + arc.instanceExamResult;
                //get the result status according  the passing mark fo the exam for exam applicant

                if (arc.applicantExam.passingMark >= arc.totalMarks)
                {
                    arc.resultStatus = "PASSED";
                    totalPassedResults++;
                }
                else
                {
                    arc.resultStatus = "FAILED";
                    totalFailedResults++;
                }
            }
            return reportList;
        }

        public void fillClubSelect()
        {
            DBService.HuntingClubService huntingClubService = new DBService.HuntingClubService();
            DataSet ds = huntingClubService.getClubsDataSet();
            clubs = huntingClubService.getClubs();

        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            String fromDate = fromDate_txt.Value.ToString();
            String toDate = toDate_txt.Value.ToString();
            int clubID;
            if (Request.Form["club"].ToString() == "")
            {
                clubID = 0;
            }
            else
            {
                 clubID = Int32.Parse(Request.Form["club"].ToString());
            }
            String nationalitySort = Request.Form["nationality"].ToString();

            String resultSort = result_Sorting.Value.ToString();

             
            if ((fromDate != "") && (toDate != ""))
            {
                if (checkDates(fromDate, toDate))
                {
                    resList = resService.getExamReportReservation(fromDate,toDate);
                }
            }
            else
            {
                resList = resService.getExamReportReservation();
            }
            List<ApplicantReportClass> allList = fillReportResults(resList);
            List<ApplicantReportClass> sortedList = new List<ApplicantReportClass>();
            foreach (ApplicantReportClass arc in allList)
            {
                if (clubID != 0)
                {
                    if (arc.applicantClub.clubID == clubID)
                    {
                        if (resultSort != "all")
                        {
                            if (arc.resultStatus.ToLower().Equals(resultSort.ToLower()))
                            {
                                if (nationalitySort == "")
                                {
                                    sortedList.Add(arc);
                                }
                                else if (nationalitySort.Equals("lebanese"))
                                {
                                    if (arc.applicant.nationality.Equals("LB"))
                                    {
                                        sortedList.Add(arc);
                                    }

                                }
                                else
                                {
                                    if (!arc.applicant.nationality.Equals("LB"))
                                    {
                                        sortedList.Add(arc);
                                    }
                                }

                            }
                        }
                        else
                        {
                            if (nationalitySort == "")
                            {
                                sortedList.Add(arc);
                            }
                            else if (nationalitySort.Equals("lebanese"))
                            {
                                if (arc.applicant.nationality.Equals("LB"))
                                {
                                    sortedList.Add(arc);
                                }

                            }
                            else
                            {
                                if (!arc.applicant.nationality.Equals("LB"))
                                {
                                    sortedList.Add(arc);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (resultSort != "all")
                    {
                        if (arc.resultStatus.ToLower().Equals(resultSort.ToLower()))
                        {
                            if (nationalitySort == "")
                            {
                                sortedList.Add(arc);
                            }
                            else if (nationalitySort.Equals("lebanese"))
                            {
                                if (arc.applicant.nationality.Equals("LB"))
                                {
                                    sortedList.Add(arc);
                                }

                            }
                            else
                            {
                                if (!arc.applicant.nationality.Equals("LB"))
                                {
                                    sortedList.Add(arc);
                                }
                            }

                        }
                    }
                    else
                    {
                        if (nationalitySort == "")
                        {
                            sortedList.Add(arc);
                        }
                        else if (nationalitySort.Equals("lebanese"))
                        {
                            if (arc.applicant.nationality.Equals("LB"))
                            {
                                sortedList.Add(arc);
                            }

                        }
                        else
                        {
                            if (!arc.applicant.nationality.Equals("LB"))
                            {
                                sortedList.Add(arc);
                            }
                        }
                    }
                }
            }
            if (sortedList.Count > 0)
            {
                     
                totalApplicants = sortedList.Count;
                filltable(sortedList);
            }
                
            
            
        }

        private void filltable(List<ApplicantReportClass> reportList)
        {
           try
           {
                if (reportList != null)
                {
                    for (int i = 0; i < reportList.Count; i++)
                    {
                        TableRow tRow = new TableRow();
                        Table1.Rows.Add(tRow);

                        // Create a new cell and add it to the row.
                       // TableCell nameCell = new TableCell();
                        TableCell1.Text = reportList[i].applicant.applicantID.ToString();
                        tRow.Cells.Add(TableCell1);

                        //TableCell descCell = new TableCell();
                        TableCell2.Text = reportList[i].applicant.firstname + " " + reportList[i].applicant.middlename +" "+ reportList[i].applicant.lastname;
                        tRow.Cells.Add(TableCell2);

                        TableCell4.Text = reportList[i].applicant.gender;
                        tRow.Cells.Add(TableCell4);

                        //TableCell questionNoCell = new TableCell();
                        TableCell5.Text = Age(reportList[i].applicant.dateOfBirth);
                        tRow.Cells.Add(TableCell5);

                       // TableCell questionMarkCell = new TableCell();
                        TableCell6.Text =getNationality(reportList[i].applicant.nationality);
                        tRow.Cells.Add(TableCell6);

                       /// TableCell passingMarkCell = new TableCell();
                        TableCell7.Text = reportList[i].applicantClub.clubName;
                        tRow.Cells.Add(TableCell7);

                        TableCell8.Text = reportList[i].applicant.placeOfBirth;
                        tRow.Cells.Add(TableCell8);
                        
                       // TableCell dateCell = new TableCell();
                        TableDateCell.Text = reportList[i].examDate;
                        tRow.Cells.Add(TableDateCell);

                       // TableCell intanceCell = new TableCell();
                        TableCell10.Text = reportList[i].instanceExamResult.ToString();
                        tRow.Cells.Add(TableCell10);

                       // TableCell fieldCell = new TableCell();
                        TableCell11.Text = reportList[i].fieldExamResult.ToString();
                        tRow.Cells.Add(TableCell11);

                        //TableCell markCell = new TableCell();
                        TableCell12.Text = reportList[i].totalMarks.ToString();
                        tRow.Cells.Add(TableCell12);

                       // TableCell statusCell = new TableCell();
                        TableCell13.Text = reportList[i].resultStatus.ToString();
                        tRow.Cells.Add(TableCell13);

                        totalExp = reportList[i].instanceExamResult;
                         totalField = reportList[i].fieldExamResult;

                         numberCell.Text = totalApplicants.ToString();
                        
                    }

                    double avrgeExp = (double)totalExp / totalApplicants;
                    average_theory.Text = avrgeExp.ToString();

                    double fieldAvrg = (double)totalField / totalApplicants;
                    average_experimental.Text = fieldAvrg.ToString();

                    foreach (ApplicantReportClass arc in reportList)
                    {
                        if (arc.applicant.nationality.Equals("LB"))
                        {
                            totalLebanse++;
                            if (arc.resultStatus.Equals("PASSED"))
                            {
                                totalLebanesePassed++;
                            }
                        }
                        else
                        {
                            totalNotLebanese++;
                            if (arc.resultStatus.Equals("PASSED"))
                            {
                                totalNotLebanesePassed++;
                            }
                        }
                    }
                    setResultSummaryData();
                }
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }
         
        public void setResultSummaryData()
        {

            //get average passed people
            double passed = (totalPassedResults / totalApplicants) * 100;
            passed_percentage_txt.Text = passed.ToString();

            //get average failed people
            double failed = (totalFailedResults / totalApplicants) * 100;
            failed_percentage_txt.Text = failed.ToString();

            if (totalLebanse == 0)
            {
                totalLebanse = 1;
            }
            double lebanese_passed = (totalLebanesePassed / totalLebanse) * 100;
            lebanese_percentage_txt.Text = lebanese_passed.ToString();

            if (totalNotLebanese == 0)
            {
                totalNotLebanese = 1;
            }
            double notLeba_passed = (totalNotLebanesePassed / totalNotLebanese) * 100;
            notLeb_percentage_txt.Text = notLeba_passed.ToString();
        }



        private bool checkDates(string fromDate, string toDate)
        {
            DateTime dateFrom = Convert.ToDateTime(fromDate);
            DateTime dateTo = Convert.ToDateTime(toDate);
            DateTime nowdate = DateTime.Today;

            if (DateTime.Compare(dateFrom, nowdate) > 0)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = " تاريخ البحث من هو بعد تاريخ اليوم";
                return false;
            }

            if (DateTime.Compare(dateTo, dateFrom) < 0)
            {
                 errMsgDiv.Style.Remove("display");
                 errMsg.Text = " تاريخ البحث الى هو قبل تاريخ البحث من";
                 return false;
            }
            if (DateTime.Compare(dateTo, nowdate) > 0)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = " تاريخ البحث من هو بعد تاريخ اليوم ";
                return false;
            }

            return true;
        }

        public  string Age(String birthdayStr)
        {
            DateTime now = DateTime.Today;
            DateTime birthday = DateTime.Parse(birthdayStr);
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age.ToString();
        }

        public String getNationality(String code)
        {
            return (new CountryService()).getCountryByCode(code).countryNameAr;
        }
    }
}