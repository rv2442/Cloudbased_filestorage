using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPass
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pwd = Session["password"].ToString();
            if (txtoldpwd.Text != pwd)
            {
                lblmsg.Text = "Incoreect Old Password";
                txtoldpwd.Text = "";
                txtoldpwd.Focus();
            }
            else if (txtoldpwd.Text == txtnewpwd.Text)
            {
                lblmsg.Text = "New Password Can not be same as Old Password";
                txtnewpwd.Text = "";
                txtnewpwd.Focus();
            }
            else if (txtnewpwd.Text != txtconfirmpwd.Text)
            {
                lblmsg.Text = "New Password and Confirm Password should match";
                txtnewpwd.Text = "";
                txtconfirmpwd.Text = "";
                txtnewpwd.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                SqlCommand cmd = new SqlCommand("update vintable set password=@password where username=@username", con);
                cmd.Parameters.AddWithValue("@password", txtnewpwd.Text);
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                txtoldpwd.Text = "";
                txtnewpwd.Text = "";
                txtconfirmpwd.Text = "";
                lblmsg.Text = "Password Changed Successfuly";
                lblmsg.ForeColor = Color.Green;
            }
        }
    }
}