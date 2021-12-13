using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;



namespace LoginPass
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string SecretKey(int KeyLength)

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
        protected void TextFile(string username,string secretkey)
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
            Response.AddHeader("content-disposition", "attachment; filename="+username+"_secretkey.txt");
            Response.BinaryWrite(bytes);
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
           // bool pass = ValidatePassword(txtpassword.Text, out string y);
          
            if (txtpassword.Text != txtconfpass.Text)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Password and Confirm Password should match";

                txtconfpass.Text = "";
                txtconfpass.Focus();
            }
            else
            {


                
                string skey = SecretKey(10);
                SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                SqlCommand cmd = new SqlCommand("insert into cloudlogin values(@username,@password,@email,@secretkey)", con);

                string username = txtusername.Text;
                string password = txtpassword.Text;
                string email = txtemail.Text;



                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@secretkey", skey);
                con.Open();
                TextFile(username,skey);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("Sign up Successful");
                Response.Redirect("GmailFunc.aspx");
            }
        }

        protected void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}