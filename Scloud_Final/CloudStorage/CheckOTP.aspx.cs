/*
*    @author: Vineet Dabholkar, Rahul Vijan
*
*    This Page is used to Check OTP and create a database for the user where file information will be stored at
*
*/

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
        /* 
        * Assign an empty string otp to store the OTP (One Time Password)
        */
        string otp = "";
  
        protected void Page_Load(object sender, EventArgs e)
        {
            
            /* Session state is an ASP.NET Core scenario for storage of user data while the user browses a web app */
            if (Session["username"] != null)
            {
                /* Store session's OTP in string "otp" */
                otp = Session["OTP"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                /* Send an alert when the OTP is sent to the Email ID provided by the user */
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('OTP sent to the given Email ID.');", true);

            }
        }
        /* 
        *   This function will check whether the OTP matches the users input or not
        */
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (otp == txtOTP.Text)
            {
                /*if the OTP entered by the user in the textbox matches the OTP generated redirect the user to the Main Page */
                status_otp.Text = "Otp match";
                sql_operation();
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                /* else display that the entered OTP mismatches and user needs to re-enter it*/
                status_otp.Text = "Otp mismatch";
            }
        }
        
        /* 
        *   This function will perform the sql operations required for storing the user information in the database
        */
        protected void sql_operation()
        {
            /*Make a SQL Connection to the database*/
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");

            try
            {
                /* Insert the username, password, email and the secret key generated into the database */
                SqlCommand cmd = new SqlCommand("insert into cloudlogin values(@username,@password,@email,@secretkey)", con);

                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@password", Session["password"].ToString());
                cmd.Parameters.AddWithValue("@email", Session["email"].ToString());
                cmd.Parameters.AddWithValue("@secretkey", Session["scrkey"].ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                /* Insert into the databse the username and value "no" indicating that the user has not yet turned on Face Recognition for this account */
                SqlCommand cmd1 = new SqlCommand("insert into Cloudlogin_2FactorAuth values(@username,'no')", con);
                cmd1.Parameters.AddWithValue("@username", Session["username"].ToString());

                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();

                /* Create a table for the user which contains:
                * username- the name of the user with which he/she signed up
                * filetype- the file type that the user has stored in his storage,
                * filepath- the path where the file is stored in the cloud storage,
                * fileowner- Owner of the file can be the user or the another user who shares his file with the user
                */
                SqlCommand cmd2 = new SqlCommand("create table " + Session["username"].ToString() + "_shared (username varchar(50),filetype varchar(10) ,filepath varchar(1000) ,fileowner varchar(50) )", con);

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();


            }
            catch
            {

                con.Close();
            }

        }
    }
}
