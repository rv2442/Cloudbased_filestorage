using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPass
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                string sRandomOTP =  GenerateRandomOTP(4, saAllowedCharacters);
                // Sender's Email address here
                Msg.From = new MailAddress("cloudstorage636@gmail.com");
                // Recipient's Email address herw.
                Msg.To.Add(txtTo.Text);
                Msg.Subject = "Cloud Storage OTP";
                Msg.Body ="Your OTP is " + sRandomOTP;

                if (fileUpload1.HasFile)
                {
                    String FileName = fileUpload1.PostedFile.FileName;
                    Msg.Attachments.Add(new Attachment(fileUpload1.PostedFile.InputStream, FileName));
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("cloudstorage636@gmail.com", "cloudstorage123");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent to the given Email ID.');", true);
                Label1.Text = sRandomOTP;
                Label1.Visible= true;
                // Set Session values during button click  
               
                    Session["OTP"] = sRandomOTP;
                    Response.Redirect("CheckOTP.aspx");
               
                //Response.Redirect("CheckOTP.aspx?name=" + sRandomOTP );
             //   Server.Transfer("CheckOTP.aspx?name=" + sRandomOTP);
                
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

      
    }
}