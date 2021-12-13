using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using

namespace LoginPass
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassBut_Click(object sender, EventArgs e)
        {
            SqlConnection con = new 
                SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            string username = Session["username"].ToString();
            string dbpwd = Session["password"].ToString();
            if (OldPass.Text != dbpwd)
            {
                Color.Text = "Incorrect Old Password";
                Color.ForeColor = Color.Red;
            }
            else if (NewPass.Text == dbpwd)
            {
                Color.Text = "New password can not be same as Old Password";
                Color.ForeColor = Color.Red;
            }
            else if (NewPass.Text != ConfPass.Text)
            {
                Color.Text = "Password and Confirm Password Doesnot Match";
                Color.ForeColor = Color.Red;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update registration set password=@pwd where username = @user", con);
               
                cmd.Parameters.AddWithValue("@pwd", NewPass.Text);
                cmd.Parameters.AddWithValue("@user", username);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Color.Text = "Password Changed Successfully";
                Color.ForeColor = Color.Green;
            }
        }
    }
}