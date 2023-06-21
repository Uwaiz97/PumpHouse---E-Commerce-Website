using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PumpHouse.ServiceReference1;

namespace PumpHouse
{
    public partial class Products : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            String display = " ";
            dynamic prod = sc.getAllProducts();

            foreach(Product p in prod)
            {
                display += "";
                display += "";
                display += "";
                display += "";
            }
        }
    }

}