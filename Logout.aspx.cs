using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PumpHouse
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UName"] = null;
            Session["UType"] = null;
            Session["UID"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}