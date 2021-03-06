﻿using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class Applicant
    {
        public int applicantID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String firstname { get; set; }
        public String middlename { get; set; }
        public String lastname { get; set; }
        public String dateOfBirth { get; set; }
        public String placeOfBirth { get; set; }
        public String gender { get; set; }
        public String email { get; set; }
        public String bloodType { get; set; }
        public String profession { get; set; }
        public String mailAddress { get; set; }
        public String fax { get; set; }
        public String city { get; set; }
        public String registrationNb { get; set; }
        public String applicantAddress { get; set; }
        public String cellular { get; set; }
        public String phone { get; set; }
        public String nationality { get; set; }
        public int accountActivated { get; set; }
        public String activationCodeToken { get; set; }
        public int userActivation { get; set; }
        public Country cnationalityCountry { get; set; }
        public Applicant()
        {

        }
    }
}