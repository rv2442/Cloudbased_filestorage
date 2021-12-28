using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudStorage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new
            SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd = new SqlCommand("select password from cloudlogin where username=@username", con);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string dbpwd = null;
            while (dr.Read())
            {
                dbpwd = dr["password"].ToString();
            }
            con.Close();
            if (dbpwd == txtpassword.Text)
            {
                Session["username"] = txtusername.Text;
                Session["password"] = txtpassword.Text;
                Session["user"]=Session["username"].ToString();
                Response.Redirect("Mainpage.aspx");
            }
            else
            {
                txtusername.Text = "";
                txtpassword.Text = "";
                txtusername.Focus();
                lblmsg.Visible = true;
            }
        }

   
    }
}