using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace CloudStorage
{
    public partial class Settings : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");

        public decimal saze;
        bool auth;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
               
                usernametxt.Text = Session["username"].ToString();
                string email = get_email();
                emailtxt.Text = email;
                displayusernametxt.Text = usernametxt.Text;
            }
            string path = Server.MapPath("~/MyUploads/" + Session["username"].ToString() + "/");
            DirectoryInfo f = new DirectoryInfo(path);
            var saiz = DirSize(f);
            double temp = Convert.ToInt32(saiz) / 1024 / 1024 / 10.24;
            saze = decimal.Round(Convert.ToDecimal(temp), 2, MidpointRounding.AwayFromZero);
           // Response.Write(saze);
            auth = sql_check();
            if (auth)
            {
                disable_button.Visible = true;
                enable_auth.Visible = false;
            }
            else
            {
                disable_button.Visible = false;
                enable_auth.Visible = true;
            }

        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void disable_button_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Cloudlogin_2FactorAuth set status_2f='no' where username =@username", con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            disable_button.Visible = false;
            enable_auth.Visible = true;
        }

        protected void enable_auth_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'>function alert_user() { var response = confirm('You are now going to be redirected for registering your face are you sure you wish to enable 2F Auth?'); if (response) { redirect(); } document.getElementById('HiddenField1').value=response; } function redirect() { window.location.href = 'FaceRegister.aspx'; } alert_user();</script>");
            string response =HiddenField1.Value.ToString();
            if (response.ToLower().Trim() == "true") {
                SqlCommand cmd = new SqlCommand("update Cloudlogin_2FactorAuth set status_2f='yes' where username =@username", con);
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                disable_button.Visible = true;
                enable_auth.Visible = false;
                //Thread.Sleep(2000);
            }

        }

        public bool sql_check()
        {
            SqlCommand cmd = new SqlCommand("select* from Cloudlogin_2FactorAuth where username = @username", con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            string status = "";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            while (data.Read())
            {
                status = data[1].ToString();
            }
            con.Close();
            if (status == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected string get_email()
        {
            SqlCommand cmd = new SqlCommand("select* from cloudlogin where username = @username", con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            string email = "";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            while (data.Read())
            {
                email = data[2].ToString();
            }
            con.Close();
            return email;
        }

        protected void redirect()
        {
            Response.Redirect("FaceRegister.aspx");
        }
    }
}