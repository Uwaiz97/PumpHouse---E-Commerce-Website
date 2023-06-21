using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PumpHouse.ServiceReference1;
using HashPass;

namespace PumpHouse
{
    
    public partial class Register : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (Password.Value == ConPassword.Value)
            {
                var hashed = Secrecy.HashPassword(Password.Value);
             
                var newUser = new User()
                {
                    User_Name = username.Value,
                    User_Surname = surname.Value,
                    User_Email = email.Value,
                    User_PhoneNo = PhoneNo.Value,
                    User_Password = hashed,
                };
                int result = sc.UserRegistration(newUser.User_Name,newUser.User_Surname,newUser.User_Email,newUser.User_PhoneNo,newUser.User_Password, 1);
                if (result == 1)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (result == 0)
                {
                    
                    
                }
            }
            else
            {
                
            }
        }
    }
}