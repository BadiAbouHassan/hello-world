using System;
using System.Collections.Generic;
using System.Web;

namespace template.Models
{
    public class RegistrationRequests
    {
        public int referenceID { get; set; }
        public int userID { get; set; }
        public int clubID { get; set; }
        public String registrationRequestsDate { get; set; }
        public int verifiedByAdmin { get; set; }
        public String verificationDate { get; set; }

        public RegistrationRequests()
        {
        }

    }

}