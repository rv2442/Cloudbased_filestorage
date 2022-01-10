using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CloudStorage
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        string otp = "";
  
        protected void Page_Load(object sender, EventArgs e)
        {
            //otp = Request.QueryString["name"].ToString();
            if (Session["username"] != null)
            {
                otp = Session["OTP"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('OTP sent to the given Email ID.');", true);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (otp == txtOTP.Text)
            {

                status_otp.Text = "Otp match";
                sql_operation();
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

                SqlCommand cmd2 = new SqlCommand("create table " + Session["username"].ToString() + "_shared (username varchar(50),filetype varchar(10) ,filepath varchar(1000) ,fileowner varchar(50) )", con);

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

                //SqlCommand cmd3 = new SqlCommand("create table " + Session["username"].ToString() + " (username varchar(25),filepath varchar(1000),userfile varchar(100),sizefile varchar(255))", con);


                //con.Open();
                //cmd3.ExecuteNonQuery();
                //con.Close();

                //string directoryPath = Server.MapPath("~/MyUploads/" + Session["username"].ToString().Trim()) ;

                //Directory.CreateDirectory(directoryPath);
                

            }
            catch
            {

                con.Close();
            }
        


        }
    }
}