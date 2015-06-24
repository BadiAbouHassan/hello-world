using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class RegistrationRequests
    {
        public int registerationID { get; set; }
        public int applicantID { get; set; }
        public int clubID { get; set; }
        public String registrationRequestsDate { get; set; }
        public int verifiedByAdmin { get; set; }
        public String verificationDate { get; set; }
        public String referenceNo { get; set; }

        public RegistrationRequests()
        {
        }

    }

}