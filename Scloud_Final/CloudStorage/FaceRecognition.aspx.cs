/*
*    @author: Vineet Dabholkar, Rahul Vijan
*
*    This Page is used for Face Recognition if enabled by the user
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Diagnostics;
namespace CloudStorage
{
    public partial class FaceRecognition : System.Web.UI.Page
    {
        /* Global Variables */
        int count;
        static string data;
        static string data2;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                count = 0; /* Set Counter to 0 on when Loading Page for the First time */
                Session["TempUsername"] = Session["username"] /* On 1st Page Load Event save username in Temp session  */
                Session["username"].Abandon()/* Freeing Resources */
            }
            
            /* If the username is not defined yet due to some reason return to Login Page */
            if (Session["TempUsername"] == null || Session["TempUsername"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            /* If the system fails to recognize the user then :
             * a) After 3 attempts pop up a alert letting the user know he/she has exceeded the number of attempts and 
             * he/she needs to change the password for security reasons.
             * b) Redirect the user to the Change Password Page 
             */
            if (count >= 3)
            {
                Response.Write("<script type = 'text/javascript'> function attempts_exceeded() { alert('3 attempts exceeded please provide key and new password to disable face auth'); redirect() }function redirect() { window.location.href = 'ChangePassword.aspx'; }attempts_exceeded();</script>");
                /* 
                    <script type = 'text/javascript'>
                    function attempts_exceeded() {
                        alert('3 attempts exceeded please provide key and new password to disable face auth'); 
                        redirect() 
                    }
                    function redirect() {
                        window.location.href = 'ChangePassword.aspx';
                    }
                    attempts_exceeded();
                    </script>
                *
                * Above Function is used to redirect user to Reset Password Page when there are 3 or more Failed Face Recognitions
                */
            }
        }

        /* 
        * Pre-requisite
        * (This Function is Used when a button is clicked on the page to capture the face,
        * When that button is clicked it activates a function in JS called abcd() which captures the image and saves it as a base64 string
        * This string is saved in a hidden field 
        * abcd() clicks a hidden button  which activates this function) 
        *
        * This Function extracts that base64 string from clients browser (Html) to Server (C#)
        * String is built back to image and Face Recognition Operation is done via a Python Script
        * If face is recognized then User is redirected to MainPage (Dashboard) 
        */
        protected void hiddenbtn_Click(object sender, EventArgs e)
        {

            var base64imgstring = hidden_img.Value; /* extracts base64 string from Hiddden Field */

            string filePath = "C:\\inetpub\\wwwroot\\SCloud\\CloudStorage\\face_rec\\test.jpg";  /* Path where Image which is to be recognized is Saved */
            File.WriteAllBytes(filePath, Convert.FromBase64String(base64imgstring)); /* Converting Base64 string to Image */
            var stdOutput = new StringBuilder(); /* Object to save string got from Command line */
            var stderror = new StringBuilder();

            try /* To Avoid Stopping of App */
            {
                var p = new Process(); /* Object to access executables */
                p.StartInfo.FileName = "cmd.exe"; /* Executable which wer are going to access */
                p.StartInfo.Arguments = @"/k cd /d C:\\inetpub\\wwwroot\\SCloud\\CloudStorage\\face_rec && python face_rec.py "; /* Command to Execute given as an argument */
                p.StartInfo.CreateNoWindow = true; /* Do not open CL Interface */ 
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.UseShellExecute = false;
                p.OutputDataReceived += (a, b) => stdOutput.AppendLine(b.Data); /* Saves stdoutput */
                p.ErrorDataReceived += (a, b) => stderror.AppendLine(b.Data); /* Saves stderror log */
                p.Start();                                                      /* Executes command in Command Line */
                p.BeginErrorReadLine();                                         /* Begin reading error from CL */
                p.BeginOutputReadLine();                                        /* Begin reading Output from CL */
                p.WaitForExit(15000);                                           /* Wait time in ms uptill where we have to read */   
                p.Kill();                                                       /* Kill Process */

                data = stderror.ToString(); /* String Saves log of error in case any occur (for debugging) */
                data2 = stdOutput.ToString(); /* String Saves Output of Face Recognition which is a string with Username saved during Face Registration  (for debugging) */
            }
            catch
            {
                Response.Write("<br><br> error"); /* For Debugging */
            }
            finally
            {
                /* Check if Facerecognition Output Tag (username) matches current username */
                if (stdOutput.ToString().Trim().ToLower() == Session["TempUsername"].ToString().ToLower()) 
                {
                    Session["username"]=Session["TempUsername"] /* Re-establish User Session */
                    Session["TempUsername"].Abandon() /* Freeing Resources */
                    Response.Redirect("MainPage.aspx"); /* Redirect to Dashboard */

                }
                else
                {
                    Response.Write(stdOutput.ToString());  /* Write Invalid User on Top of Page */
                    count++;                               /* Increment Recognition Fail Counter */
                    
                }
            }
        }
    
    }
}
