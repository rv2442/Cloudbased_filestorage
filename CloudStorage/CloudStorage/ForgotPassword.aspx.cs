﻿using System;
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
    {
        static string dbpwd, email, secanswer;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select * from cloudlogin where username=@user", con);
            cmd.Parameters.AddWithValue("@user", txtusername.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    secanswer = dr["secretkey"].ToString();
                    email = dr["email"].ToString();
                    dbpwd = dr["password"].ToString();
                }
                Panel1.Visible = true;
                lbluser.Visible = false;
            }
            else
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
            if (txtsecanswer.Text == secanswer)
            {
                lblmsg.Text = "Your Password is " + dbpwd;

                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("cloudstorage636@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add(email);
                Msg.Subject = "Your Password ";
                Msg.Body = "Hi Your Password is " + dbpwd;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("cloudstorage636@gmail.com", "cloudstorage123");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
            }
            else
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