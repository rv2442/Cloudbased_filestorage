using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace ironpaithantest
{
    public partial class tastpaithan : System.Web.UI.Page
    {
       

            protected void Page_Load(object sender, EventArgs e)
            {

            }

        protected void hiddenbtn_Click(object sender, EventArgs e)
        {
            var ab= hidden_img.Value;
            Response.Write(ab);
            string filePath = "D:\\face_rec\\face_rec\\test.jpg";
            File.WriteAllBytes(filePath, Convert.FromBase64String(ab));

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            //process.StartInfo = startInfo;
            //process.Start();

            //string strCmdText;
            //strCmdText = "/K cd /d D:\\face_rec\\face_rec && python face_rec.py ";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            try
            {
                var p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = @"/k cd /d D:\\face_rec\\face_rec && python face_rec.py ";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.UseShellExecute = false;
                var stdOutput = new StringBuilder();
                var stderror = new StringBuilder();
                p.OutputDataReceived += (a, b) => stdOutput.AppendLine(b.Data);
                p.ErrorDataReceived += (a, b) => stderror.AppendLine(b.Data);
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                p.WaitForExit(15000);
                p.Kill();
                Response.Write("<br><br> data: "+stdOutput.ToString());
                Response.Write("<br><br> error: "+stderror.ToString());
            }
            catch
            {
                Response.Write("<br><br> error");
            }


            //string fileName = @"D:\face_rec\face_rec\face_rec.py";

            //Process p = new Process();
            //p.StartInfo = new ProcessStartInfo(@"C:\Users\Rahul\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Python 3.7", fileName)
            //{
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = true
            //};
            //p.Start();

            //string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();

            //Response.Write(output);

            //Console.ReadLine();
            // Response.Write("Value received from script: " + myString);
        }
    }
}
