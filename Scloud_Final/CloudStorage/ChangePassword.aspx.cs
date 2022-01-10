using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudStorage
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {  
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["username"] = "Vinny636";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select password,secretkey from cloudlogin where username=@username", con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string pwd = null;
            string scrkey = null;
            while (dr.Read())
            {
                pwd = dr["password"].ToString();
                scrkey = dr["secretkey"].ToString();
            }
            con.Close();
            if (txtoldpwd.Text != pwd)
            {
                lblmsg.Text = "Incorrect Old Password";
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
            else if (txtscrkey.Text != scrkey)
            {
                lblmsg.Text = "Secret Key you have entered is not valid";
                txtscrkey.Text = "";
                txtscrkey.Focus();
            }
            else
            {
                SignUp obj = new SignUp();
                bool validate =obj.ValidatePassword_gen(txtnewpwd.Text, out string ErrorMessage);
                if (validate)
                {
                    SqlCommand cmd1 = new SqlCommand("update cloudlogin set password=@password where username=@username", con);

                    cmd1.Parameters.AddWithValue("@password", txtnewpwd.Text);
                    cmd1.Parameters.AddWithValue("@username", Session["username"].ToString());
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    txtoldpwd.Text = "";
                    txtnewpwd.Text = "";
                    txtconfirmpwd.Text = "";
                    txtscrkey.Text = "";
                    lblmsg.Text = "Password Changed Successfuly";
                    lblmsg.ForeColor = Color.Green;
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    lblmsg.Text = ErrorMessage;
                    txtnewpwd.Text = "";
                    txtconfirmpwd.Text = "";
                }
            }
        }
    }
    }