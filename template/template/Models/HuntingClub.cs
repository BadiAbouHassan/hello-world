using System;
using System.Collections.Generic;
using System.Web;

namespace template.Models
{
    public class HuntingClub
    {
        public int clubID { get; set; }
        public String clubName{ get; set; }
        public String clubAddress { get; set; }
        public String phoneNb { get; set; }
        public String email { get; set; }
        public int userID { get; set; }

        public HuntingClub()
        {
        }

    }
}