using System;
using System.Collections.Generic;
using System.Web;
using template.DBModel;
using template.DBService;

namespace template.Controllers
{
    public class ApplicantController
    {
        public ApplicantController()
        {
        }


        public Boolean deleteApplicant(int ID)
        {
             return (new ApplicantService()).deleteApplicant(ID);
        }

        public List<Applicant> getAllApplicants()
        {
            return (new ApplicantService()).getAllApplicants();
        }
    }
}