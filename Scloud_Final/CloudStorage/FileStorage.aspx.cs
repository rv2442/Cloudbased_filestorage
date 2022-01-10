   
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CloudStorage
{
    public partial class FileStorage : System.Web.UI.Page
    {

        string username = "";
        string FileName;
        string oldpath;
        string path;

        //  string username = "user3";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (!Directory.Exists(Server.MapPath("~/MyUploads/" + Session["username"].ToString())))
                {
               try
                    {
                        SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                        SqlCommand cmd = new SqlCommand("create table " + Session["username"].ToString() + " (username varchar(25),filepath varchar(1000),userfile varchar(100),sizefile varchar(255))", con);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //string user = username;
                        Directory.CreateDirectory(Server.MapPath("~/MyUploads/" + Session["username"].ToString()));
                    }
                    catch
                    {
                        Directory.CreateDirectory(Server.MapPath("~/MyUploads/" + Session["username"].ToString()));
                    }
                }
            }
            Label1.Text = "";
            //string usar111 = Session["username"].ToString();
            //Session["username"] = "Rv2442";
                if (Session["username"] != null)
            {
                var size = storage_used();
                if (size >= 100.00m )
                {
                    FileUpload1.Visible = false;
                    Button1.Visible = false;
                    Label1.Text = "Storage Full please upgrade to Tier 2";
                }
                else
                {
                    FileUpload1.Visible = true;
                    Button1.Visible = true;
                    Label1.Text = "";
                }
                if (!IsPostBack)
                {
                    username = Session["username"].ToString();
                    Session["currentpath"] = Session["username"].ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack) //Used to Check whether the Page is loaded first time or not  
            {
                ListOfData(); //Custom Method Called
                Loop_file_gridview();
            }
            //Response.Write(username);
            Settings obj = new Settings();
        }

        protected decimal storage_used()
        {
            string path_forsize = Server.MapPath("~/MyUploads/" + Session["username"].ToString() + "/");
            DirectoryInfo peth = new DirectoryInfo(path_forsize);
            var a = Settings.DirSize(peth);
            double temp = Convert.ToInt32(a) / 1024 / 1024 / 10.24;
            decimal size = decimal.Round(Convert.ToDecimal(temp), 2, MidpointRounding.AwayFromZero);
            return size;
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
            //Response.Write(path + "<br><br>" + oldpath + "<br><br>" + username + "<br><br>" + currentpath + "<br><br>" + Session["username"].ToString());

            //Response.Write(currentpath);
            DataTable dt_Infolder = new DataTable(); //Datatable is Created to Add Dynamic Columns
            dt_Infolder.Clear();
            dt_Infolder.Columns.Add("File");
            dt_Infolder.Columns.Add("Size");
            dt_Infolder.Columns.Add("Type");
            GridView1.DataSource = dt_Infolder;
            GridView1.DataBind();
            // Response.Write(username);
            if ((Directory.GetFiles(currentpath).Length == 0))
            {
                //GridView1.DataSource = null;
                //GridView1.DataBind();
            }
            else
            {
                ListOfData();
            }
            if (Directory.GetDirectories(currentpath).Length == 0)
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile) //If the used Uploaded a file  
            {
                try
                {
                    var file = FileUpload1.FileBytes;
                    decimal size = decimal.Round(Convert.ToDecimal(Convert.ToInt32(file.Length) / 1024 / 1024 / 10.24), 2, MidpointRounding.AwayFromZero);
                    decimal current_size = storage_used();
                    if ((size + current_size) < 100.00m)
                    {
                        FileName = FileUpload1.FileName; //Name of the file is stored in local Variable  
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/MyUploads/" + Session["currentpath"].ToString() + "/") + FileName); //File is saved in the Physical folder  
                                                                                                                                            //Response.Write("<br><br><br><br>" + username);
                        username = Session["currentpath"].ToString();
                    }
                    else
                    {
                        Label1.Text = "File Size exceeds Storage quota please upgrade to tier 2";
                    }
                }
                catch(Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Size cannot exceed 4 GB "+ex+"');", true);
                }
            }
            ListOfData(); //Custom method is Called  
        }
        //Custom Methods used in the Above Code  
        private void ListOfData()
        {
            if ((FileName == ("")) || (FileName == null))
            {
                if (Directory.Exists(Server.MapPath("~/MyUploads/" + Session["username"].ToString() + "/")))
                {
                    DataTable dt1 = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                                     //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
                    dt1.Columns.Add("File");
                    dt1.Columns.Add("Size");
                    dt1.Columns.Add("Type");
                    foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + Session["currentpath"].ToString() + "/"))) //Directory.GetFiles Method is used to Get the files from the Folder  
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
                    SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                    SqlCommand cmd = new SqlCommand("create table " + username + " (username varchar(25),filepath varchar(1000),userfile varchar(100),sizefile varchar(255))", con);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //string user = username;

                    Directory.CreateDirectory(Server.MapPath("~/MyUploads/" + Session["username"].ToString()));
                }
            }
            else
            {

                var folder = Server.MapPath("~/MyUploads/" + username);

                ///  SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                // SqlCommand cmd = new SqlCommand("create table @username(username varchar(25)," +
                //  "filepath varchar(255),userfile varchar(255),sizefile varchar(255),)", con);
                

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

                SqlConnection con1 = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
                SqlCommand cmd1 = new SqlCommand("insert into " + Session["username"].ToString() + " values(@username,@folder,@filename1,@filesize1)", con1);
                cmd1.Parameters.AddWithValue("@username", user);
                cmd1.Parameters.AddWithValue("@filename1", filename1);
                cmd1.Parameters.AddWithValue("@folder", folder);
                cmd1.Parameters.AddWithValue("@filesize1", filesize1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();

                GridView1.DataSource = dt; // Setting the Values of DataTable to be Shown in Gridview  
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
            catch 
            {
                //  Response.Write("<br><br> No Folder inside current folder");
            }
        }

        public string GetFileTypeByFileExtension(string fileExtension)
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
                case ".pdf":
                    return "PDF Document";
                default:
                    return "Unknown file type";
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Back_Click(object sender, EventArgs e)
        {

            path = Session["currentpath"].ToString();
            int lastSlash = path.LastIndexOf('\\');
            path = (lastSlash > -1) ? path.Substring(0, lastSlash) : path;
            Session["currentPath"] = path;
            username = path;
            ListOfData();
        }

        protected void New_folder_Click(object sender, EventArgs e)
        {


        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {

            string directoryPath = Server.MapPath(string.Format("~/MyUploads/" + Session["currentpath"] + "/{0}/", txtFolderName.Text.Trim()));
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
            ListOfData();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> list_file = new List<string>();
            list_file = getfiledata();
            List<string> list_folder = new List<string>();
            list_folder = getfolderedata();
            if (list_file.Count != 0)
            {
                foreach (string file_name in list_file)
                {
                    string filePath = Server.MapPath(string.Format("~/MyUploads/" + Session["currentpath"] + "/" + file_name));

                    File.Delete(filePath);
                }
            }

            if (list_folder.Count != 0)
            {
                foreach (string folder_path in list_folder)
                {
                    //string folderpath = Server.MapPath(folder_path);
                    if (Directory.Exists(Server.MapPath("~\\MyUploads\\" + Session["currentpath"] + "\\" + folder_path)))
                    {
                        Directory.Delete(Server.MapPath("~\\MyUploads\\" + Session["currentpath"] + "\\" + folder_path), true);

                    }

                }
            }

            if ((list_file.Count == 0) && (list_folder.Count == 0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory does not exist.');", true);
            }
            ListOfData();
        }

        protected List<string> getfiledata()
        {
            List<string> checkboxdata = new List<string>();
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    LinkButton filename = (LinkButton)gvrow.FindControl("LinkButton1");

                    checkboxdata.Add(filename.Text);
                }
            }

            return checkboxdata;
        }

        protected List<string> getfolderedata()
        {
            List<string> checkboxdataforlist = new List<string>();
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    LinkButton folderpath = (LinkButton)gvrow.FindControl("LinkButton1");

                    checkboxdataforlist.Add(folderpath.Text);
                }
            }

            // Label1.Text = checkboxdataforlist.Count.ToString();
            return checkboxdataforlist;
        }
        protected void btPopupLoad_Click(object sender, EventArgs e)
        {
            var data = usernames_shared.Value;
            var data_arr = data.Split(',');
            List<string> list_file = new List<string>();
            list_file = getfiledata();
            List<string> list_folder = new List<string>();
            list_folder = getfolderedata();
            List<string> users = new List<string>();
            List<string> invalid_users = new List<string>();
            foreach (string user in data_arr)
            {
                if (User_exists(user.Trim()))
                {
                    users.Add(user.Trim());
                }
                else
                {

                    invalid_users.Add(user.Trim());
                }
            }
            if (list_file.Count != 0)
            {

                foreach (string file in list_file)
                {

                    table_share(users, Session["currentpath"].ToString() + "\\" + file, "file");

                }

            }

            if (list_folder.Count != 0)
            {
                foreach (string folder_path in list_folder)
                {
                    table_share(users, Server.MapPath("~\\MyUploads\\" + Session["currentpath"].ToString() + "\\" + folder_path), "folder");
                }
            }

            if ((list_file.Count == 0) && (list_folder.Count == 0))
            {
                Response.Write("<script type= 'text/javascript'>alert('No files selected')</script>");
            }
            else
            {
                if (invalid_users.Count != 0)
                {
                    string inv_users = "Invalid users found: \\n\\n";
                    for (int i = 0; i < invalid_users.Count; i++)
                    {
                        inv_users += invalid_users.ElementAt(i) + "\\n";
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + inv_users + "')", true);
                }
            }

        }

        public void table_share(List<string> data_list, string path_share, string type)
        {


            SqlConnection con_share = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");

            foreach (string user in data_list)
            {


                string user_shared = user.Trim() + "_shared";
                try
                {
                    SqlCommand cmd_share = new SqlCommand("create table " + user_shared + " (username varchar(25),filetype varchar(10),filepath varchar(1000),fileowner varchar(25))", con_share);
                    con_share.Open();
                    cmd_share.ExecuteNonQuery();
                    con_share.Close();
                    if (path_exists(user_shared, path_share))
                    {

                    }
                    else
                    {

                        SqlCommand cmd_share_add = new SqlCommand("insert into " + user_shared + " values(@username,@filetype,@filepath,@fileowner)", con_share);
                        cmd_share_add.Parameters.AddWithValue("@username", user);
                        cmd_share_add.Parameters.AddWithValue("@filetype", type);
                        cmd_share_add.Parameters.AddWithValue("@filepath", path_share);
                        cmd_share_add.Parameters.AddWithValue("@fileowner", Session["username"].ToString());
                        con_share.Open();
                        cmd_share_add.ExecuteNonQuery();
                        con_share.Close();
                        //Response.Write("data added");
                    }
                }
                catch
                {
                    con_share.Close();

                    if (path_exists(user_shared, path_share))
                    {

                    }
                    else
                    {
                        con_share.Close();
                        SqlCommand cmd_share = new SqlCommand("insert into " + user_shared + " values(@username,@filetype,@filepath,@fileowner)", con_share);
                        cmd_share.Parameters.AddWithValue("@username", user);
                        cmd_share.Parameters.AddWithValue("@filetype", type);
                        cmd_share.Parameters.AddWithValue("@filepath", path_share);
                        cmd_share.Parameters.AddWithValue("@fileowner", Session["username"].ToString());
                        con_share.Open();
                        cmd_share.ExecuteNonQuery();
                        con_share.Close();
                        //Response.Write("data added");
                    }

                }


            }

        }
        protected bool path_exists(string tablename, string file_path)
        {
            bool exists = false;
            bool inside_folder = false;
            SqlConnection con_share1 = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd_share1 = new SqlCommand("select * from " + tablename + " where  filepath=@filepath", con_share1);
            cmd_share1.Parameters.AddWithValue("@filepath", file_path);
            con_share1.Open();
            SqlDataReader data_share = cmd_share1.ExecuteReader();
            if (data_share.HasRows)
            {
                exists = true;
                con_share1.Close();
            }
            else
            {
                exists = false;
                con_share1.Close();
            }

            //string file_path_2 = Server.MapPath("~\\MyUploads\\"+file_path.Trim());
            string file_path_2 = Server.MapPath("~") + "MyUploads\\" + file_path;
            SqlCommand cmd_inside_folder = new SqlCommand("select * from " + tablename + " where  filetype='folder'", con_share1);
            con_share1.Open();
            SqlDataReader cmd_data_inside_folder = cmd_inside_folder.ExecuteReader();
            if (cmd_data_inside_folder.HasRows)
            {

                foreach (var path in cmd_data_inside_folder)
                {
                    if (file_path_2.Contains(cmd_data_inside_folder[2].ToString()))
                    {
                        inside_folder = true;

                    }
                }
                con_share1.Close();
            }
            else
            {
                con_share1.Close();
            }
            return (exists || inside_folder);

        }
        protected bool User_exists(string user)
        {
            bool exists = false;
            SqlConnection con_user_exists = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
            SqlCommand cmd_user_exists = new SqlCommand("select * from cloudlogin where username=@username", con_user_exists);
            cmd_user_exists.Parameters.AddWithValue("@username", user.Trim());
            con_user_exists.Open();
            SqlDataReader data_user_exists = cmd_user_exists.ExecuteReader();

            if (data_user_exists.HasRows)
            {
                exists = true;
                con_user_exists.Close();
            }
            else
            {
                exists = false;
                con_user_exists.Close();
            }

            return exists;
        }
    }
}