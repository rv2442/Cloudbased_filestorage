using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Diagnostics;
namespace CloudStorage
{
    public partial class FaceRecognition : System.Web.UI.Page
    {
        int count;
        static string data;
        static string data2;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(data);
            Response.Write(data2);
            if (!IsPostBack)
            {
                count = 0;
            }
            //Session["username"] = "Rv2442";
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (count >= 3)
            {
                Response.Write("<script type = 'text/javascript'> function attempts_exceeded() { alert('3 attempts exceeded please provide key and new password to disable face auth'); redirect() }function redirect() { window.location.href = 'ChangePassword.aspx'; }attempts_exceeded();</script>");

            }
        }

        protected void hiddenbtn_Click(object sender, EventArgs e)
        {

            var ab = hidden_img.Value;

            string filePath = "C:\\inetpub\\wwwroot\\SCloud\\CloudStorage\\face_rec\\test.jpg";
            File.WriteAllBytes(filePath, Convert.FromBase64String(ab));
            var stdOutput = new StringBuilder();
            var stderror = new StringBuilder();

            try
            {
                var p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = @"/k cd /d C:\\inetpub\\wwwroot\\SCloud\\CloudStorage\\face_rec && python face_rec.py ";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.UseShellExecute = false;
                p.OutputDataReceived += (a, b) => stdOutput.AppendLine(b.Data);
                p.ErrorDataReceived += (a, b) => stderror.AppendLine(b.Data);
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                p.WaitForExit(15000);
                p.Kill();

                data = stderror.ToString();
                data2 = "brr " + stdOutput.ToString() + " brr";
            }
            catch
            {
                Response.Write("<br><br> error");
            }
            finally
            {
                if (stdOutput.ToString().Trim().ToLower() == Session["username"].ToString().ToLower())
                {
                    Response.Redirect("MainPage.aspx");

                }
                else
                {
                    Response.Write(stdOutput.ToString());
                    //Response.Write("<script type='text/javascript'>alert('Unknown Face');</script>");
                    count++;
                    
                }
            }
        }
    
    }
}