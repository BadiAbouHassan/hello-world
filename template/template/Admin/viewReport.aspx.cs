using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.DBModel;

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
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                fillClubSelect();
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text =ex.Message;
            }
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
            int clubID = Int32.Parse(Request.Form["club"].ToString());
            String resultSort = Request.Form["club"].ToString();
            String nationalitySort = Request.Form["nationality"].ToString();

            if (checkDates(fromDate, toDate))
            {
                           
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

            double lebanese_passed = (totalLebanesePassed / totalLebanse) * 100;
            lebanese_percentage_txt.Text = lebanese_passed.ToString();

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


    }
}