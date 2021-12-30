using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website_.NET
{
    public partial class face_register : System.Web.UI.Page
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
            var ab = hidden_img.Value;
            Response.Write(ab);
            string filePath = "D:\\face_rec\\face_rec\\faces\\"+Session["username"].ToString()+".jpg";
            File.WriteAllBytes(filePath, Convert.FromBase64String(ab));
            Response.Redirect("Face_recognition.aspx");
          


        }
    }
}