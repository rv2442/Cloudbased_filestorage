using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPass
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        string username = "";
        string FileName;
        string oldpath;
        string path;

        //  string username = "user3";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "User1";
            if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    username = Session["username"].ToString();
                    Session["currentpath"] = Session["username"].ToString();
                }
            }
            Response.Write(username + "<br>");
            if (!IsPostBack) //Used to Check whether the Page is loaded first time or not  
            {
                ListOfData(); //Custom Method Called
                Loop_file_gridview();
            }
            Response.Write(username);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) //Is fired when File is Downloaded  
        {
            Path_changed();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument); //Used to append the filename at the time of Downloading  
            Response.TransmitFile(Server.MapPath("~/MyUploads/" + username + "/") + e.CommandArgument); //Used to Fetch the file from the Physical folder of Server  
            Response.End();
            // Response.Redirect("MainPage.aspx");
        }
        protected void Path_changed()
        {
            username = Session["currentpath"].ToString();
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e) //Is fired when File is Downloaded  
        {
            //insidefile = true;
            path = e.CommandArgument.ToString();
            oldpath = Server.MapPath("~/MyUploads/" + username + "/");
            username = path.Substring(oldpath.Length, path.Length - oldpath.Length);
            Session["currentpath"] = username;
            string currentpath = Server.MapPath("~/MyUploads/" + username + "/");
            Response.Write(path + "<br><br>" + oldpath + "<br><br>" + username + "<br><br>" + currentpath + "<br><br>" + Session["username"].ToString());

            //Response.Write(currentpath);
            DataTable dt_Infolder = new DataTable(); //Datatable is Created to Add Dynamic Columns
            dt_Infolder.Clear();
            dt_Infolder.Columns.Add("File");
            dt_Infolder.Columns.Add("Size");
            dt_Infolder.Columns.Add("Type");
            GridView1.DataSource = dt_Infolder;
            GridView1.DataBind();
            // Response.Write(username);
            if (Directory.GetFiles(currentpath).Length == 0)
            {
                Response.Write("<br><br><br><br><br><br><br> No Files in this folder");
            }
            else
            {
                ListOfData();
            }
        }
        
        //Custom Methods used in the Above Code  
        private void ListOfData()
        {
            if ((FileName == ("")) || (FileName == null))
            {
                DataTable dt1 = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                                 //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
                dt1.Columns.Add("File");
                dt1.Columns.Add("Size");
                dt1.Columns.Add("Type");
                foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + username + "/"))) //Directory.GetFiles Method is used to Get the files from the Folder  
                {


                    FileInfo fileinfo1 = new FileInfo(str);
                    string filename_ex = fileinfo1.Name; //Getting the Name of the File  
                    string filesize_ex = (fileinfo1.Length / 1024).ToString(); //Getting the Size of the file and Converting it into KB from Bytes  
                    string filetype_ex = GetFileTypeByFileExtension(fileinfo1.Extension); //Getting file Extension and Calling Custom Method  
                    dt1.Rows.Add(filename_ex, filesize_ex, filetype_ex);
                }
                GridView1.DataSource = dt1; // Setting the Values of DataTable to be Shown in Gridview  
                GridView1.DataBind(); // Binding the Data  
                Loop_file_gridview();
            }
            else
            {

                var folder = Server.MapPath("~/MyUploads/" + username);

                ///  SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                // SqlCommand cmd = new SqlCommand("create table @username(username varchar(25)," +
                //  "filepath varchar(255),userfile varchar(255),sizefile varchar(255),)", con);
                if (!Directory.Exists(folder))
                {

                    SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                    SqlCommand cmd = new SqlCommand("create table " + username + " (username varchar(25),filepath varchar(100),userfile varchar(100),sizefile varchar(255))", con);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //string user = username;
                    Directory.CreateDirectory(folder);

                }

                DataTable dt = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                                //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
                dt.Columns.Add("File");
                dt.Columns.Add("Size");
                dt.Columns.Add("Type");
                //Looping through Each file available in the MyUploads folder  
                string filename1 = "";
                string filesize1 = "";
                string filetype1 = "";
                foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + username + "/"))) //Directory.GetFiles Method is used to Get the files from the Folder  
                {


                    FileInfo fileinfo = new FileInfo(str); //Fileinfo class is used to fetch the information about the Fetched file  
                    if (fileinfo.Name == FileName)
                    {
                        filename1 = fileinfo.Name; //Getting the Name of the File  
                        filesize1 = (fileinfo.Length / 1024).ToString(); //Getting the Size of the file and Converting it into KB from Bytes  
                        filetype1 = GetFileTypeByFileExtension(fileinfo.Extension); //Getting file Extension and Calling Custom Method  
                        dt.Rows.Add(filename1, filesize1, filetype1); //Adding Rows to the DataTable
                    }
                    else
                    {
                        string filename = fileinfo.Name; //Getting the Name of the File  
                        string filesize = (fileinfo.Length / 1024).ToString(); //Getting the Size of the file and Converting it into KB from Bytes  
                        string filetype = GetFileTypeByFileExtension(fileinfo.Extension); //Getting file Extension and Calling Custom Method  
                        dt.Rows.Add(filename, filesize, filetype); //Adding Rows to the DataTable  
                    }

                }


                string user = Session["username"].ToString();
                //DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

                //string filename1 = lastRow[0].ToString();
                //string filesize1 = lastRow[1].ToString();
//***************************************************************************************
                SqlConnection con1 = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                SqlCommand cmd1 = new SqlCommand("Select * from" + Session["username"].ToString() , con1);
                SqlDataReader reader = cmd1.ExecuteReader();
              
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();
//****************************************************************************************************************
                GridView1.DataSource = reader; // Setting the Values of DataTable to be Shown in Gridview  
                GridView1.DataBind(); // Binding the Data  
                Loop_file_gridview();
            }
        }
        protected void Loop_file_gridview()
        {
            try
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                string folder = Server.MapPath("~/MyUploads/" + Session["currentpath"].ToString() + "/");
                DataTable dt_folder = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                                       //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
                dt_folder.Columns.Add("File");
                dt_folder.Columns.Add("Type");

                string filename;
                string filetype;

                foreach (string str in Directory.EnumerateDirectories(folder)) //Directory.GetFiles Method is used to Get the files from the Folder  
                {

                    filename = str; //Getting the Name of the File    
                    filetype = "folder"; //Getting file Extension and Calling Custom Method  
                    dt_folder.Rows.Add(filename, filetype); //Adding Rows to the DataTable

                    GridView2.DataSource = dt_folder; // Setting the Values of DataTable to be Shown in Gridview  
                    GridView2.DataBind();

                }
            }
            catch (Exception e)
            {
                Response.Write(e + "<br><br> No Folder inside current folder");
            }
        }

        private string GetFileTypeByFileExtension(string fileExtension)
        {
            switch (fileExtension.ToLower()) //Checking the file Extension and Showing the Hard Coded Values on the Basis of Extension Type  
            {
                case ".doc":
                case ".docx":
                    return "Microsoft Word Document";
                case ".xls":
                case ".xlsx":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text File";
                case ".png":
                case ".jpg":
                    return "Windows Image file";
                default:
                    return "Unknown file type";
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Back_Click(object sender, EventArgs e)
        {

            path = Session["currentPath"].ToString();
            int lastSlash = path.LastIndexOf('\\');
            path = (lastSlash > -1) ? path.Substring(0, lastSlash) : path;
            Session["currentPath"] = path;
            username = path;
            ListOfData();
        }

       
        
    }
}