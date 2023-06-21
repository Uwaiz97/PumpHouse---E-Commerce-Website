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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            var hashed = Secrecy.HashPassword(User_Password.Value);
            int tempID = sc.UserLogin(Email.Value, hashed);

            if (tempID != 0)
            {
                var tempUser = sc.GetUser(tempID);
                Session["UName"] = tempUser.User_Name.ToString();
                Session["UType"] = tempUser.User_Type.ToString();
                Session["UID"] = tempUser.User_Id.ToString();
                Response.Redirect("Home.aspx");
            }
        }
    }
}