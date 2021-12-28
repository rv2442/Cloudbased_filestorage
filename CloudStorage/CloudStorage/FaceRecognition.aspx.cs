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
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "User1";
        }

        protected void hiddenbtn_Click(object sender, EventArgs e)
        {
            var ab = hidden_img.Value;
            Response.Write(ab);
            string filePath = @"C:\Users\vinee\source\repos\CloudStorage\CloudStorage\face_rec\test.jpg";
            File.WriteAllBytes(filePath, Convert.FromBase64String(ab));
            var stdOutput = new StringBuilder();
            var stderror = new StringBuilder();

            try
            {
                var p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = @"/c cd C:\Users\vinee\source\repos\CloudStorage\CloudStorage\face_rec && python face_rec.py ";
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
                Response.Write("<br><br> data: " + stdOutput.ToString());
                Response.Write("<br><br> error: " + stderror.ToString());

            }
            catch
            {
                Response.Write("<br><br> error");
            }
            finally
            {
                if (stdOutput.ToString().Trim().ToLower() == Session["username"].ToString().ToLower())
                {
                    Response.Write("<script type='text/javascript'>alert('Logged in Sucessfully');</script>");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('Unknown Face');</script>");
                }
            }
        }
    }
}