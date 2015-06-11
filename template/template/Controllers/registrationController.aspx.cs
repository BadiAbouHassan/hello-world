using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;
using template.DBService;

namespace template.Controlers
{
    public partial class registrationController : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                addApplicant();    
            }
            catch (Exception exp)
            {
                Response.Redirect("../Views/errorHandler.aspx");
                // must redirect to erro page and display the Exception in the erro page ... 
               
            }
        }
        public void addApplicant()
        {
            try{

            Applicant user = new Applicant();
            String password = Request.Form["password"];
            String confPass = Request.Form["confpasswd"];
            if (!password.Equals(confPass))
            {
                String redirect_Location = "../Login.aspx";
                Response.Redirect("Views/errorHandler.aspx?exceptoin_msg=" + "Password doesn't match !" +"&redirect_locaiton=" + redirect_Location);

            }
            else
            {

                String Hashed_pass = MD5Hash.GetHash(password); //hash the password
                user.email = Request.Form["email"];
                user.lastname = Request.Form["lastname"];
                user.firstname = Request.Form["firstname"];
                user.middlename = Request.Form["middlename"];
                user.dateOfBirth = Request.Form["date_of_birth"];
                user.nationality = Request.Form["nationality"];
                user.applicantAddress = Request.Form["address"];
                user.username = Request.Form["username"];
                user.registrationNb = Request.Form["registratoin_nb"];
                user.phone = Request.Form["phone"];
                user.cellular = Request.Form["cellular"];
                user.fax = Request.Form["fax_number"];
                user.mailAddress = Request.Form["mail"];
                user.gender = Request.Form["gender"];
                user.placeOfBirth = Request.Form["place_of_birth"];
                user.bloodType = Request.Form["blood_type"];
                user.profession = Request.Form["profession"];
                user.city = Request.Form["city"];
                user.password = Hashed_pass;

                //create RegistrationRequest object
                RegistrationRequests req = new RegistrationRequests();
                req.clubID = Int32.Parse(Request.Form["club"].ToString());
                req.verifiedByAdmin = 0;
                req.verificationDate = "";
                req.registrationRequestsDate = System.Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");

                ApplicantService client_controller = new ApplicantService();
                Applicant addedApplicant = client_controller.addApplicant(user, req);
                if (addedApplicant != null)
                {
                     Response.Redirect("../Login.aspx",false);

                    // label1.Text = "Succcessfully added";
                }
        
            }
            }catch(Exception exc)
            {
                String  redirect_Location ="../Login.aspx";
                Response.Redirect("Views/errorHandler.aspx?exceptoin_msg=" + exc.Message + "&redirect_locaiton=" + redirect_Location);

                

            }
            

        }
    }
}