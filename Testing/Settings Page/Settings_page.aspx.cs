using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;

namespace Website_.NET
{
    public partial class Settings_page : System.Web.UI.Page
    {
        public decimal saze;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["username"] = "User1";
            }
            string path = Server.MapPath("~/MyUploads/"+Session["username"].ToString()+"/");
            DirectoryInfo f = new DirectoryInfo(path);
            var saiz = DirSize(f);
            double temp = Convert.ToInt32(saiz)/1024/1024/10.24;
            saze = decimal.Round(Convert.ToDecimal(temp), 2, MidpointRounding.AwayFromZero);
            Response.Write(saze);
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
    }
}