
using System;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CloudStorage
{
    public partial class FaceRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void hiddenbtn_Click(object sender, EventArgs e)
        {
            Settings obj = new Settings();
            SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");

            SqlCommand cmd = new SqlCommand("update Cloudlogin_2FactorAuth set status_2f='yes' where username =@username", con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            var ab = hidden_img.Value;
            //Response.Write(ab);
            string filePath = "C:\\inetpub\\wwwroot\\SCloud\\CloudStorage\\face_rec\\faces\\" + Session["username"].ToString() + ".jpg"; 
            File.WriteAllBytes(filePath, Convert.FromBase64String(ab));
            Response.Redirect("FaceRecognition.aspx");


        }
    }
}