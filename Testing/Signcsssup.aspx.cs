using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPass
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string SecretKey()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        protected void TextFile(string username, string secretkey)
        {
            MemoryStream ms = new MemoryStream();
            TextWriter tw = new StreamWriter(ms);
            tw.WriteLine("---Secretkey--- ");
            tw.WriteLine(secretkey);
            tw.WriteLine("---Secretkey--- ");
            tw.Flush();
            byte[] bytes = ms.ToArray();
            ms.Close();

            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment; filename=" + username + "_secretkey.txt");
            Response.BinaryWrite(bytes);
            Response.End();
        }
        public bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;
            Label1.Visible = true;
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
            if (pass)
            {
                Label1.Visible = false;
                if (txtpassword.Text != txtconfpass.Text)
                {
                    Label1.Visible = true;
                    Label1.Text = "Password and Confirm Password should match";

                    txtconfpass.Text = "";
                    txtconfpass.Focus();
                }
                else
                {
                    
                    SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                    SqlCommand cmd = new SqlCommand("Select * from cloudlogin where username= @username", con);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        Label1.Text = string.Format("Username '{0}' already exists", txtusername.Text);
                        Label1.Visible = true;
                        con.Close();
                    }
                    else
                    {
                        con.Close();

                        SqlCommand cmd1 = new SqlCommand("insert into cloudlogin values(@username,@password,@email,@secretkey)", con);
                        string skey = SecretKey();
                        cmd1.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd1.Parameters.AddWithValue("@password", txtpassword.Text);
                        cmd1.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd1.Parameters.AddWithValue("@secretkey", skey);
                        string username = txtusername.Text;

                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        TextFile(username, skey);

                        Response.Redirect("GmailFunc.aspx");
                    }
                }
            }
        }

        protected void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
