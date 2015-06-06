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

                checkApplicant();    
            }
            catch (Exception exp)
            {
                Response.Redirect("../Views/errorHandler.aspx");
                // must redirect to erro page and display the Exception in the erro page ... 
               // label1.Text = exp.Message;
            }
        }
        public void checkApplicant()
        {
            Applicant user = new Applicant();
            String password = Request.Form["password"];
            String confPass = Request.Form["confpasswd"];
            if (!password.Equals(confPass))
            {
                // label1.Text = "Passwords don't match !!";
                Response.Redirect("../Views/errorHandler.aspx", false);
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
                user.registrationNb = Request.Form["registration_nb"];
                user.phone = Request.Form["phone"];
                user.cellular = Request.Form["cellular"];
                user.fax = Request.Form["fax_nb"];
                user.mailAddress = Request.Form["mail"];
                user.gender = Request.Form["gender"];
                user.placeOfBirth = Request.Form["place_of_birth"];
                user.bloodType = Request.Form["blood_type"];
                user.profession = Request.Form["profession"];
                user.city = Request.Form["city"];
                user.password = Hashed_pass;
                ApplicantService client_controller = new ApplicantService();
                Boolean addedsuccessfully = client_controller.addApplicant(user);
                if (addedsuccessfully)
                {
                    Response.Redirect("../Login.aspx", false);
                    // label1.Text = "Succcessfully added";
                }
                else
                {
                    Response.Redirect("../Login.aspx", false);
                    // label1.Text = "Error";

                }
            }
        }
    }
}