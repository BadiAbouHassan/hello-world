using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using template.Controllers;
using template.DBModel;

namespace template
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lbl1.Text = "";

        }

        //sign up click
        public void signUp(object sender, EventArgs e)
        {
            try
            {

                
                String email = email_txt.Value.ToString();
                String firstname = firstname_txt.Value.ToString();
                String lastname = lastname_txt.Value.ToString();
                String address = address_txt.Value.ToString();
                String username = username_txt.Value.ToString();
                String nationality = nationality_txt.Value.ToString();
                String nationalID = nationalID_txt.Value.ToString();
                String phoneNB = phone_txt.Value.ToString();
                String mobile = mobile_txt.Value.ToString();
                String password = passwrd_txt.Value.ToString();
                String confPass = confirm_pass_txt.Value.ToString();
                if (!password.Equals(confPass))
                {
                    
                    return;
                }


                String Hashed_pass = MD5Hash.GetHash(password); //hash the password


                User user = new User();
                user.email = email;
                user.lastname = lastname;
                user.firstname = firstname;
                user.mobileNb = mobile;
                user.phoneNb = phoneNB;
                user.nationalID = nationalID;
                user.nationality = nationality;
                user.userAddress = address;
                user.username = username;
                user.password = password;
                user.roleID = 0;
                UserController user_controller = new UserController();
                Boolean addedsuccessfully = user_controller.addUser(user);
                if (addedsuccessfully)
                {
                    lbl1.Text = "Succcessfully added";
                }
                else
                {
                    lbl1.Text = "Error";

                }
            }
            catch (Exception exp)
            {
                lbl1.Text = exp.Message;
            }

        }

        //sign in click
        public void signIn(object sender, EventArgs e)
        {
            lbl1.Text = "textss";
            try
            {
                String username_login = login_username.Value.ToString();
                String pass = login_password.Value.ToString();

                String loginHashed = MD5Hash.GetHash(pass);

                UserController user_controller = new UserController();
                User loggedUser = user_controller.checkUserAuthentication(username_login, loginHashed);
                if (loggedUser == null)
                {
                    lbl1.Text = "Wrong username or password";
                }
                else
                {
                    lbl1.Text = "loggedUser in successfully";
                }

            }
            catch (Exception exc)
            {
                lbl1.Text = exc.Message;
            }

        }

    }
}