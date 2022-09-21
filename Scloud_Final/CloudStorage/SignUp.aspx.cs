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
using System.Net.Mail;

namespace CloudStorage
{
    public partial class SignUp : System.Web.UI.Page
    {
        string finalString;
        public string scrkey;
        public string usrname;
        public string username;
        static bool email_unique;
        static bool username_unique;
        public bool allvalidationpassed;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                email_unique = false;
                username_unique = false;
                SecretKey();
                Session["validity"] = "initial";


            }
            this.scrkey = finalString;
            this.usrname = username;
        }
        
        /*
        *   generates a random secret key which is used by the user to reset password
        */
        public void SecretKey()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@$%#!%&";
            var stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            finalString = new String(stringChars);
            Session["scrkey"] = finalString;
        }


        /*
        *   function checks for regex conditions [A-Z,a-z,0-9,@$%#!%&]
        *   a) 8-15 characters
        *   b) One lowercase and uppercase character
        *   c) One Numeric value
        *   d) One special case character
        *
        *   once conditions are met it checks for a unique user name and a unique email id
        *   if met returns true else returns false
        */
        public bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                /* null */
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                return false;
            }
            else if (txtpassword.Text != txtconfpass.Text)
            {
                
                ErrorMessage = "Password and Confirm Password should match";
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();


                txtconfpass.Text = "";
                txtconfpass.Focus();
                return false;
            }
            else if (email_unique == false)
            {
                
                email_label.Text = "not valid";
                txtemail.Focus();
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                return false;
            }
            else if (username_unique == false)
            {
                uname_label.Text = "not valid";
                uname_label.Visible = true;
                txtusername.Focus();
                allvalidationpassed = false;
                Session["validity"] = allvalidationpassed.ToString();
                
                return false;
            }
            else
            {
                allvalidationpassed = true;
                Session["validity"] = allvalidationpassed.ToString();
                return true;
            }
        }


        /* This function uses Regex to perform password validation. Must contain 
         *  a) 8-15 characters
         *  b) One lowercase and uppercase character
         *  c) One Numeric value
         *  d) One special case character
         *  this function is also called via an object of this class when the user wishes to reset his password
         *  does not check for username and email uniqueness as password is being reset (account already exists)
         */
        public bool ValidatePassword_gen(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Password cant be blank";
                return false;
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


        /*
        *   checks regex condition, username, email uniqueness, once conditions met.
        *   creates session variables for username, passsword, email to access in OTP page
        *   Sends otp
        *   
        *   If conditions not met shosw where the error occured
        */
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool pass = ValidatePassword(txtpassword.Text, out string y);
            Session["validity"] = pass.ToString();
            Label1.Text = y;
            if (pass)
            {

                Session["username"] = txtusername.Text;
                Session["password"] = txtpassword.Text;
                Session["email"] = txtemail.Text;
                send_otp();


            }
            else
            {
                Label1.Visible = true;
            }
        }


        /* 
        *   This function checks if the username is valid or not by checking the database
        *   If not valid it will show the error and prompt the control onto the field where the error occured
        */
        public void txtusername_TextChanged(object sender, EventArgs e)
        {
            string a = "";
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
              
                uname_label.Text = "not valid";
                uname_label.Visible = true;
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

        /* 
        *   This function checks if the user email is valid or not by checking the database
        *   If not valid it will show the error and prompt the control onto the field where the error occured
        */
        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select * from cloudlogin where email = @email", con);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                email_label.Text = "not valid";
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
            /* null */
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            /* null */
        }


        /* 
        *   This function generates a Random OTP after signing up to validate the account used
        *   
        */
        protected string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
        
        /* 
        *   This function sends the otp to the email id which user has entered while signing up
        *   saves otp in session variable to use on the OTP page for validation
        */
        protected void send_otp()
        {
            
                MailMessage Msg = new MailMessage();
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                string sRandomOTP = GenerateRandomOTP(4, saAllowedCharacters);
                
                /* Sender's Email address here */
                Msg.From = new MailAddress("cloudstorage636@gmail.com");
                
                /* Recipient's Email address here. */
                Msg.To.Add(txtemail.Text);
                
                Msg.Subject = "Cloud Storage Account Confirmation";
                Msg.Body = " Your OTP is " + sRandomOTP;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
            smtp.UseDefaultCredentials =false;
            smtp.Credentials = new System.Net.NetworkCredential("cloudstorage636@gmail.com", "cloudstorage123");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;
                Session["OTP"] = sRandomOTP;
            
       
        }
    }
}
