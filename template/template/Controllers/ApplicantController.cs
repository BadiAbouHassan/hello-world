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
            Boolean flag = false;
            if ((new RegistrationRequestService()).deleteRequestByApplicantID(ID))
            {
                flag = (new ApplicantService()).deleteApplicant(ID);
            }
             return flag;
        }

        public List<Applicant> getAllApplicants()
        {
            return (new ApplicantService()).getAllApplicants();
        }

        public List<Applicant> getAllApplicantsOfAdminClub(User user)
        {
            return (new ApplicantService()).getAllApplicantsOfAdminClub(user);
        }
    }
}