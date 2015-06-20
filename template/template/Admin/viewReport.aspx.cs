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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void fillClubSelect()
        {
            DBService.HuntingClubService huntingClubService = new DBService.HuntingClubService();
            DataSet ds = huntingClubService.getClubsDataSet();
            clubs = huntingClubService.getClubs();

        }

    }
}