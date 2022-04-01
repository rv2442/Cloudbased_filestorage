/*  
 *  @file Login.aspx.cs
 *  @created by Rahul Vijan, Vineet Dabholkar
 *  
 **/


/* Including Libraries*/
using System;
using System.Data.SqlClient;

namespace CloudStorage
{
    public partial class Login : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            /* On Page Load Event */
            if (!IsPostBack)
            {
                /*Abandon previous Sessions*/
                Session.Abandon();
            }
        }

        protected void Login_Button_Click(object sender, EventArgs e)
        {
            /* Create connection instance with remote  */
            SqlConnection con = new
            SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select password from cloudlogin where username=@username", con); 
            cmd.Parameters.AddWithValue("@username", txtusername.Text);  /* Maps txtusername.Text into Sql Query attribute @username */
            con.Open(); /* Opened Connection for Operation */
            SqlDataReader dr = cmd.ExecuteReader();    /* executes Select query */
            string dbpwd = null; /* Creating string to save password */
            while (dr.Read())
            {
                dbpwd = dr["password"].ToString(); 
            }
            con.Close(); /* Closed Connection */
            if (dbpwd == txtpassword.Text)  /* Comapring user password with database password */
            {
                /* 
                 * Password matched, assigning entered username to a Session 
                 * This Session variable is used for authentication in upcoming pages                
                 */
                Session["username"] = txtusername.Text; 

                Settings obj = new Settings(); /* Creating object for Settings Page to import function*/
                bool setreturn = obj.sql_check(); /* Checks if user has 2 Factor Authentication on*/
                if (setreturn) 
                {
                    Response.Redirect("FaceRecognition.aspx");
                }
                else  
                {
                    Response.Redirect("MainPage.aspx");
                }
             
            }
            else  /* Password Mismatch, Setting Username and Password field to blank */
            {
                txtusername.Text = "";
                txtpassword.Text = "";
                txtusername.Focus();
                errormsg.Visible = true;
            }
        }


    }
}