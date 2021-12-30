using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Website_.NET
{
    public partial class OTP : System.Web.UI.Page
    {
        string otp = "";
        string temp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //otp = Request.QueryString["name"].ToString();
            if (Session["username"] != null)
            {
                otp = Session["OTP"].ToString();
            }
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('OTP sent to the given Email ID.');", true);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (otp == TextBox1.Text)
            {

                status_otp.Text = "Otp match";
                sql_operation();
                string uname = Session["username"].ToString();
                Session.Abandon();
                Session["username"] = uname;
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                status_otp.Text = "Otp mismatch";
            }
        }

        protected void sql_operation()
        {
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");

            try
            {
                SqlCommand cmd = new SqlCommand("insert into cloudlogin values(@username,@password,@email,@secretkey)", con);

                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@password", Session["password"].ToString());
                cmd.Parameters.AddWithValue("@email", Session["email"].ToString());
                cmd.Parameters.AddWithValue("@secretkey", Session["scrkey"].ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd1 = new SqlCommand("insert into Cloudlogin_2FactorAuth values(@username,'no')", con);
                cmd1.Parameters.AddWithValue("@username", Session["username"].ToString());

                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                con.Close();
            }
            // Adding to Cloudlogin_2FactorAuth

            
        }
    }
}