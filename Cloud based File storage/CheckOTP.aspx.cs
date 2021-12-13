using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LoginPass
{
    public partial class CheckOTP : System.Web.UI.Page
    {
    

        protected void Page_Load(object sender, EventArgs e)
        {
          
            //otp= Request.QueryString["name"].ToString();
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            
              if (Session["sRandomOTP"].ToString() == txtOTP.Text)
              {
                 // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('OTP confirmed');", true);
                // Response.Redirect("MainPage.aspx");
                Label2.Text = "OTP matched";

              }
              else
              {
                Label2.Text = "OTP mismatched";
               // Label2.Visible = true;
              } 
        }
    }
}