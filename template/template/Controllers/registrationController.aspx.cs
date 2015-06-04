using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template.Controlers
{
    public partial class registrationController : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             try
            {
                User user = new User();

                String password = Request.Form["password"];
                String confPass = Request.Form["confpasswd"];
                if (!password.Equals(confPass))
                {
                   // label1.Text = "Passwords don't match !!";
                    return;
                }
                else
                {


                    String Hashed_pass = MD5Hash.GetHash(password); //hash the password

                    user.email = Request.Form["email"];
                    user.lastname = Request.Form["lastname"];
                    user.firstname = Request.Form["firstname"];
                   // user.mobileNb = Request.Form["mobile"];
                   // user.phoneNb = Request.Form["phone"];
                   // user.nationalID = Request.Form["nationalID"];
                    user.nationality = Request.Form["nationality"];
                    user.userAddress = Request.Form["address"];
                    user.username = Request.Form["username_txt"]; 
                    user.password = password;
                    user.roleID = 0;
                    


                    UserController user_controller = new UserController();
                    Boolean addedsuccessfully = user_controller.addUser(user);
                    if (addedsuccessfully)
                    {
                       // label1.Text = "Succcessfully added";
                    }
                    else
                    {
                       // label1.Text = "Error";

                    }
                }
                }
            
            catch (Exception exp)
            {
               // label1.Text = exp.Message;
            }
        
        }
    }
}