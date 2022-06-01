using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudStorage
{
    public partial class ForgotPassword : System.Web.UI.Page
    {   //Making a Connection to the database
        SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
        static string dbpwd, email, secanswer;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

           //Select the username from database
            SqlCommand cmd = new SqlCommand("select * from cloudlogin where username=@user", con);
            cmd.Parameters.AddWithValue("@user", txtusername.Text);
            con.Open();

            //The data reader provides an easy way for the programmer to read data from a database as if it were coming from a stream
            //The DataReader provides a read-only, forward-only mechanism to access data via ADO
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) //if the datareader has rows go ahead
            {

                while (dr.Read())
                {
                    //Get the security answer, email and password from the datareader
                    secanswer = dr["secretkey"].ToString();
                    email = dr["email"].ToString();
                    dbpwd = dr["password"].ToString();
                }
                Panel1.Visible = true;
                lbluser.Visible = false;
            }
            else //else display "Incorrect User Name"
            {
                lbluser.Visible = true;
                Panel1.Visible = false;
                txtusername.Text = "";
                txtusername.Focus();
            }


            con.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtsecanswer.Text == secanswer) //if the security answer matches the with the one entered by the user go ahead
            {
               //Sending a mail to user's account with user's password in it
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("cloudstorage636@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(email);
                Msg.Subject = "Your Password ";
                Msg.Body = "Your Password for accessing SCloud is " + dbpwd;

                //Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP)
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("cloudstorage636@gmail.com", "cloudstorage123");
                smtp.EnableSsl = true;
                smtp.Send(Msg);

                //set face recognition login as off 
                SqlCommand cmd1 = new SqlCommand("update Cloudlogin_2FactorAuth set status_2f='no' where username='@username'", con);
                cmd1.Parameters.AddWithValue("@username", txtusername.Text);

                Response.Write("<script type='text/javascript'>alert('Your password has been sent to you on your registered email'); window.location.href='Login.aspx';</script>");
            }
            else  //else display "Incorrect Security Answers"
            {
                lblmsg.Text = "Incorrect Security Answer";
                txtsecanswer.Text = "";
                txtsecanswer.Focus();
            }
        }

        protected void txtsecanswer_TextChanged(object sender, EventArgs e)
        {

        }
    } }
