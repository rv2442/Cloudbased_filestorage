/*
*    @author: Vineet Dabholkar, Rahul Vijan
*
*    This Page is used for Face Registeration if 2F Auth is enabled by the user
*
*/
using System;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CloudStorage
{
    public partial class FaceRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* If the username (User Session) is not defined yet due to some reason, return to Login Page */
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    
        
        /* Pre-requisite
        * (On the Settings Page if user Confirms to Start 2F Auth, then he is redirected here
        * This Function is Used when a button is clicked on the page to capture the face,
        * When that button is clicked it activates a function in JS called abcd() which captures the image and saves it as a base64 string
        * This string is saved in a hidden field 
        * abcd() clicks a hidden button  which activates this function)
        *
        * This function extracts the base 64 string from Client (Html) to Server(C#) 
        * String is converted back into image and saved in FileSystem with name <Username>.jpg
        * User is then redirected to Face Recognition Page
        */
        protected void hiddenbtn_Click(object sender, EventArgs e)
        {
            /* Creating SQL connection Object */
            SqlConnection con = new SqlConnection("Server=YOUR_SQL_SERVER_IP;uid=YOUR_UID;pwd=YOUR_PWD;database=YOUR_DB_NAME");

            var ab = hidden_img.Value; /* extracts base64 string from Hiddden Field */
            string filePath = "C:\\inetpub\\wwwroot\\SCloud\\CloudStorage\\face_rec\\faces\\" + Session["username"].ToString() + ".jpg"; /* Setting image path */
            File.WriteAllBytes(filePath, Convert.FromBase64String(ab)); /* Converting Base64 String Back to Image and saving in defined path */
            
            SqlCommand cmd = new SqlCommand("update Cloudlogin_2FactorAuth set status_2f='yes' where username =@username", con);  /* Query */
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            con.Open();
            cmd.ExecuteNonQuery(); /* Execute Query */
            con.Close();

            Response.Redirect("FaceRecognition.aspx"); /* Redirect User to FaceRecognition Page */


        }
    }
}
