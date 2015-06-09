using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class HuntingClubController
    {
        private HuntingClubService huntingClubService;

        public HuntingClubController()
        {
            this.huntingClubService = new HuntingClubService();
        }

        public bool addHuntingClub(HuntingClub club)
        {
            bool result = false;
            result = this.huntingClubService.add(club);
            return result;
        }

        public List<HuntingClub> getHuntingClubs(int clubID= 0)
        {
            return this.huntingClubService.getClubs(clubID);
        }
    }
}