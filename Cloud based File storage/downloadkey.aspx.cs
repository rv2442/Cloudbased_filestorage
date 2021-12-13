using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPass
{
    public partial class WebForm9 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = "Username";
            HiddenField2.Value = "This is text in the file ";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}