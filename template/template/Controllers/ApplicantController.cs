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

        public Boolean updateApplicant(Applicant applicant)
        {
            Boolean flag = false;
            
           flag = (new ApplicantService()).updateApplicant(applicant);
            
            return flag;
        }

        public Boolean deleteApplicant(int ID)
        {
            Boolean flag = false;
            if ((new RegistrationRequestService()).deleteRequestByApplicantID(ID))
            {
                flag = (new ApplicantService()).deleteApplicant(ID);
            }
             return flag;
        }

        public List<Applicant> getApplicants(int applicantID = 0)
        {
            return (new ApplicantService()).getApplicants(applicantID );
        }

        public List<Applicant> getAllApplicantsOfAdminClub(User user)
        {
            return (new ApplicantService()).getAllApplicantsOfAdminClub(user);
        }
    }
}