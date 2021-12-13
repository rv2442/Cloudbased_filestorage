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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string username = "";
        string FileName;

        //  string username = "user3";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                username = Session["username"].ToString();
            }
            if (!IsPostBack) //Used to Check whether the Page is loaded first time or not  
            {
                ListOfData(); //Custom Method Called  
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) //Is fired when File is Downloaded  
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument); //Used to append the filename at the time of Downloading  
            Response.TransmitFile(Server.MapPath("~/MyUploads/" + username + "/") + e.CommandArgument); //Used to Fetch the file from the Physical folder of Server  
            Response.End();
            // Response.Redirect("MainPage.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (FileUpload1.HasFile) //If the used Uploaded a file  
            {
                FileName = FileUpload1.FileName; //Name of the file is stored in local Variable  
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/MyUploads/" + username + "/") + FileName); //File is saved in the Physical folder  
            }
            ListOfData(); //Custom method is Called  
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
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

                //string filename1 = lastRow[0].ToString();
                //string filesize1 = lastRow[1].ToString();

                SqlConnection con1 = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                SqlCommand cmd1 = new SqlCommand("insert into " + username + " values(@username,@folder,@filename1,@filesize1)", con1);
                cmd1.Parameters.AddWithValue("@username", user);
                cmd1.Parameters.AddWithValue("@filename1", filename1);
                cmd1.Parameters.AddWithValue("@folder", folder);
                cmd1.Parameters.AddWithValue("@filesize1", filesize1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();

                GridView1.DataSource = dt; // Setting the Values of DataTable to be Shown in Gridview  
                GridView1.DataBind(); // Binding the Data  
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
    }
}