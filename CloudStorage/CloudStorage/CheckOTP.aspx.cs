using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudStorage
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //otp= Request.QueryString["name"].ToString();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (Session["sRandomOTP"].ToString() == txtOTP.Text)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('OTP confirmed');", true);
                Label2.Text = "OTP matched";
                Response.Redirect("MainPage.aspx");

            }
            else
            {
                Label2.Text = "OTP mismatched";
                //Label2.Visible = true;
            }
        }
    }
}