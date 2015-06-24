using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using template.DBService;

namespace template.Admin
{
    public partial class editApplicant : System.Web.UI.Page
    {
        public List<HuntingClub> clubs = new List<HuntingClub>();
         string ID  ;
         public String DOB; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    fillClubSelect();
                    ID = Request.QueryString["applicantID"];
                    fillApplicantToView(ID);
                    errMsgDiv.Style.Add("display", "none");
                    successMsgDiv.Style.Add("display", "none");
                }
                catch (Exception exc)
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = exc.Message;
                }
            }
        }

        private void fillApplicantToView(string ID)
        {
            
            ApplicantService client_controller = new ApplicantService();
            Applicant applicant = client_controller.getApplicantOfID(Int32.Parse(ID));
           if (applicant != null)
           {
               firstname.Value = applicant.firstname;
               lastname.Value = applicant.lastname;
               middlename.Value = applicant.middlename;
               mail.Value = applicant.mailAddress;
               DOB = applicant.dateOfBirth;
               email.Value = applicant.email;
               place_ofBirth.Text = applicant.placeOfBirth;
               nationality.Value = applicant.nationality;
               city.Value = applicant.city;
               cellular.Value = applicant.cellular;
               phone.Value = applicant.phone;
               profession.Value = applicant.profession;
               bloodType.Value = applicant.bloodType;
               address.Value = applicant.applicantAddress;
               username.Value = applicant.username;
               fax_number.Value = applicant.fax;
               registratoin_nb.Value = applicant.registrationNb;
               if (applicant.gender == "male")
               {
                   gender.SelectedIndex = 0;
               }
               else
               {
                   gender.SelectedIndex = 1;
               }

               //get hunting club 
               HuntingClub ApplicantClub = (new HuntingClubService()).getHuntingClubByApplicant(applicant);
               clubs.Clear();
               clubs.Add(ApplicantClub);


           }else{
                errMsgDiv.Style.Remove("display");
                errMsg.Text = "User not found";
           }
               
         }
      

        public void fillClubSelect()
        {
            DBService.HuntingClubService huntingClubService = new DBService.HuntingClubService();
            DataSet ds = huntingClubService.getClubsDataSet();
            clubs = huntingClubService.getClubs();

        }

        public void edit_click(object sender, EventArgs e)
        {
            try
            {
                ApplicantController controller = new ApplicantController();

                Applicant applicant = new Applicant();
                applicant.firstname = firstname.Value; 
                applicant.lastname =lastname.Value ;
                applicant.middlename = middlename.Value ;
                applicant.mailAddress =mail.Value ;
                applicant.dateOfBirth = Request.Form["datepicker"];
                applicant.email = email.Value;
                applicant.placeOfBirth = place_ofBirth.Text.ToString();
                applicant.nationality = nationality.Value ;
                applicant.city =city.Value ;
                applicant.cellular = cellular.Value ;
                applicant.phone =phone.Value ;
                applicant.profession = profession.Value ;
                applicant.bloodType =bloodType.Value ;
                applicant.applicantAddress = address.Value ;
                applicant.username = username.Value ;
                applicant.fax =fax_number.Value ;
                applicant.registrationNb =registratoin_nb.Value ;
                applicant.applicantID = Int32.Parse(Request.QueryString["applicantID"]);
                applicant.gender = gender.Value;
                
                

                if (!controller.updateApplicant(applicant))
                {
                    errMsgDiv.Style.Remove("display");
                    errMsg.Text = "Error updating Applicant !";
                }
                else
                {
                    successMsgDiv.Style.Remove("display");
                    successMsg.Text = "Applicant updated successfuly!";
                }
            }
            catch (Exception ex)
            {
                errMsgDiv.Style.Remove("display");
                errMsg.Text = ex.Message;
            }
        }
    }
}