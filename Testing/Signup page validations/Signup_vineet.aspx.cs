using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Website_.NET
{
    public partial class Signup_vineet : System.Web.UI.Page
    {
        string finalString;
        public string scrkey;
        public string usrname;
        public string username;
       static bool email_unique;
       static bool username_unique;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                email_unique = false;
                username_unique = false;
            }
 
                this.scrkey = finalString;
                this.usrname = username;

                 
        }
        public string SecretKey(int KeyLength)
        {
            
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            finalString = new String(stringChars);
            return finalString;
        }
        protected void TextFile(string username, string secretkey)
        {
            /*MemoryStream ms = new MemoryStream();
            TextWriter tw = new StreamWriter(ms);
            tw.WriteLine("---Secretkey---");
            tw.WriteLine(secretkey);
            tw.WriteLine("---Secretkey---");
            tw.Flush();
            byte[] bytes = ms.ToArray();
            ms.Close();

            Response.Clear();
            Response.ContentType = "text/plain";
            //Response.AddHeader("Refresh", "3; url=index.html");
            Response.AddHeader("content-disposition", "attachment; filename=" + username + "_secretkey.txt");
            //Response.AppendHeader("Refresh", "3; url=gmail_otp.aspx");
            Response.BinaryWrite(bytes);
            Response.End();*/
            Response.Write(secretkey + "<br>" + username);
            //Response.Redirect("gmail_otp.aspx");
        }
        public bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                return false;
            }
            else
            {
                return true;
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {  
            bool pass = ValidatePassword(txtpassword.Text, out string y);
            Label1.Text = y;
            if (txtpassword.Text != txtconfpass.Text )
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Password and Confirm Password should match";

                txtconfpass.Text = "";
                txtconfpass.Focus();
            }
            else if (email_unique == false)
            {
                email_label.Text = "Email not valid";
                txtemail.Focus();
            }
            else if (username_unique == false)
            {
                uname_label.Text = "Username has already been taken";
                txtusername.Focus();
            }
            else
            {

                SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                SqlCommand cmd = new SqlCommand("insert into cloudlogin values(@username,@password,@email,@secretkey)", con);
                string skey = SecretKey(8);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@secretkey", skey);
                username = txtusername.Text;

                con.Open();
                cmd.ExecuteNonQuery();
                TextFile(username, skey);
                //cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("Sign up Successful");
                Response.Redirect("gmail_otp.aspx");
            }
        }

        public void txtusername_TextChanged(object sender, EventArgs e)
        {
            string a="";
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select * from cloudlogin where username = @username", con);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               a = dr[0].ToString();
            }
            if (dr.HasRows)
            {
                Response.Write(a);
                uname_label.Text = "Username has already been taken";
                txtusername.Focus();
                username_unique = false;
            }
            else
            {
                uname_label.Text = "valid";
                username_unique = true;
                txtemail.Focus();

            }
            con.Close();
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select * from cloudlogin where email = @email", con);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                email_label.Text = "Email not valid";
                txtemail.Focus();
                email_unique = false;
            }
            else
            {
                email_label.Text = "valid";
                email_unique = true;
                txtpassword.Focus();

            }
            con.Close();
        }

        protected void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}