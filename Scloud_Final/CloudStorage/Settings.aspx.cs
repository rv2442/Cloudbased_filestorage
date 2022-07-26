
/*
*    @author: Vineet Dabholkar, Rahul Vijan
*
*    This Page is used for Settings Page where user can toggle 2F Auth 
*
*/

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
        SqlConnection con = new SqlConnection("//Enter your DB credentials//");

        public decimal saze;
        bool auth;
        
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            /*
             *  Display the username, email_id in the settings page
             */
            if (!IsPostBack)
            {
               
                usernametxt.Text = Session["username"].ToString();
                string email = get_email();
                emailtxt.Text = email;
                displayusernametxt.Text = usernametxt.Text;
            }
            
            /*
            *   Show the remaining space left in the cloud storage for user (Tier 1 = 1GB). The user can contact the admin to 
            *   upgrade his/her tier
            */
            string path = Server.MapPath("~/MyUploads/" + Session["username"].ToString() + "/");
            DirectoryInfo f = new DirectoryInfo(path);
            var saiz = DirSize(f);
            double temp = Convert.ToInt32(saiz) / 1024 / 1024 / 10.24; //Convert size to show storage in the progress bar
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
        
        /*
        *   Get the Total Directory Size of the user's storage
        */
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
                //Empty
        }
           
        /*
         *   If the 2F Auth is disabled the change the disable button to enable when clicked
         */
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
        
        
        /*
         *  If the 2F Auth is enabled the change the enable button to disable when clicked
         *  and redirect to Face Register Page
         */
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
        
        /*
        *   Check if the 2F AUth is enabled
        */
        
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
        
        /*
        *   Get the email of the user to display on Settings Page
        */
         
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
        
        /*
         * Redirect to the Face Register Page if the user wants to enable 2F Auth for his account
        */
        
        protected void redirect()
        {
            Response.Redirect("FaceRegister.aspx");
        }
    }
}
