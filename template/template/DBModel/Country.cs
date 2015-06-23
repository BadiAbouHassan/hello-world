using System;
using System.Collections.Generic;
using System.Web;

namespace template.DBModel
{
    public class Country
    {
        public int countryID { get; set; }
        public String countryCode {get;set;}
        public String countryName { get; set; }
        public String countryNameAr { get; set; }

        public Country()
        {
        }
    }
}