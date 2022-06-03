/*
*    @author: Vineet Dabholkar, Rahul Vijan
*
*    The Login Page of the website
*
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudStorage
{
    public partial class Login : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*Make a SQL Connection to the database*/
            SqlConnection con = new
            SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            /* Select the password from cloudlogin table where username matches */
            SqlCommand cmd = new SqlCommand("select password from cloudlogin where username=@username", con);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string dbpwd = null;
            while (dr.Read())
            {
                /* Read the password from the database into variable dbpwd */
                dbpwd = dr["password"].ToString();
            }
            con.Close();
            
            /* Checks if the dbpwd matches with the one entered by the user if not sets the textfield blank and 
            *  displays the "Incorrect userame or Password" message */
            if (dbpwd == txtpassword.Text)
            {
                Session["username"] = txtusername.Text;
                
                /* Perform the sql_check function from the Settings page which checks if the face detection mode is on and redirects
                *  the user to the Face Recognition Page to perform security check else redirects to Main Page
                */
                Settings obj = new Settings();
                bool setreturn = obj.sql_check();
                
                if (setreturn)
                {
                    Response.Redirect("FaceRecognition.aspx");
                }
                else
                {
                    Response.Redirect("MainPage.aspx");
                }
             
            }
            else
            {
                txtusername.Text = "";
                txtpassword.Text = "";
                txtusername.Focus();
                lblmsg.Visible = true;
            }
        }


    }
}
