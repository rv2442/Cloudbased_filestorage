/*
*    @file: FileStorage.aspx.cs
*    @author: Vineet Dabholkar, Rahul Vijan
*    This Page is used to Store files uploaded by the user and to share it to other users 
*/

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
        /* Global Variables */
        string username = "";
        string FileName;
        string oldpath;
        string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            *   If page loads for the first time and a directory named with the username does not exists,
            *   then try to create a table in the remote sql server with the username, if table already exists just create the directory with username
            */
            if (!IsPostBack) 
            {
                if (!Directory.Exists(Server.MapPath("~/MyUploads/" + Session["username"].ToString()))) /* All userfiles are created under a directory called MyUploads */
                {
                    SqlConnection con = new SqlConnection("Server=YOUR_SERVER_IP;uid=YOUR_UID;pwd=YOUR_PASSWORD;database=YOUR_DBNAME");
               try
                    {
                        SqlCommand cmd = new SqlCommand("create table " + Session["username"].ToString() + " (username varchar(25),filepath varchar(1000),userfile varchar(100),sizefile varchar(255))", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Directory.CreateDirectory(Server.MapPath("~/MyUploads/" + Session["username"].ToString()));
                    }
                    catch /* If query execution fails, close connection and create folder */
                    {
                        con.close();
                        Directory.CreateDirectory(Server.MapPath("~/MyUploads/" + Session["username"].ToString()));
                    }
                }
            }
            Label1.Text = ""; /* Emptying Field Showing Storage Full Message when Storage is full */
            
                if (Session["username"] != null) /* We check if username session is maintained, if not redirect to login page */
            {
                /*
                *   We check size by calling the function storage_used() which returns the percentage of storage used
                *   If percentage used >= 100.00 then hide 'upload' and 'select file' button and show notification telling storage is full
                *   If not then make sure 'upload' and 'select file' buttons are visible and Notification field is empty
                */
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
                if (!IsPostBack) /* On first page load event get username from usersession and create new session saving currentpath in it */
                {
                    username = Session["username"].ToString();
                    Session["currentpath"] = Session["username"].ToString(); /* using session as a global static variable */
                }
            }
            else
            {
                Response.Redirect("Login.aspx");  /* Redirect to login page for */
            }
            if (!IsPostBack) /* On first page load event call ListOfData and Loop_file_gridview */
            {
                ListOfData();  /* gets all data of folders and files from root directory of each user */
                Loop_file_gridview(); /* fills 2 Grids (files and folders) using available data of folders and files */
            }
        }
        
        

        /* 
        *   This function gets the total space in the directory named after username of user in bytes.
        *   That size in bytes is converted to Mega bytes (MB), is rounded to a decimal data type and then returned
        */
        protected decimal storage_used() 
        {
            string path_forsize = Server.MapPath("~/MyUploads/" + Session["username"].ToString() + "/"); /* creating directory path to query its size */
            DirectoryInfo peth = new DirectoryInfo(path_forsize); /* creating directory object */
            var a = Settings.DirSize(peth); /* getting directory size */
            double temp = Convert.ToInt32(a) / 1024 / 1024 / 10.24; /* converting to MB */
            decimal size = decimal.Round(Convert.ToDecimal(temp), 2, MidpointRounding.AwayFromZero); /* converting double to decimal */
            return size;
        }

       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) /* This function is fired when a File is Downloaded from the grid */  
        {
            Path_changed(); /* Update path */
            Response.Clear(); /* clears buffer */
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument); /* Used to append the filename at the time of Downloading */
            Response.TransmitFile(Server.MapPath("~/MyUploads/" + username + "/") + e.CommandArgument); /* Used to Fetch the file from the Physical folder of Server */  
            Response.End();
        }
        
        
        protected void Path_changed() /* Update path when path is changed for a file system UI in browser using Grids */
        {
            username = Session["currentpath"].ToString(); /* Updating path */
        }
        
        
        
        /* 
        *   Function is fired when a Folder is Clicked for setting it as current working directory 
        *   we update the path using the Grid command argument "e", saving it into global staic variable / session currentpath
        *   Grid is then updated using the new path and Displaying the files and folders inside the clicked Folder 
        */
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)   
        {
            path = e.CommandArgument.ToString(); /* getting new folder path from MyUploads folder*/
            oldpath = Server.MapPath("~/MyUploads/" + username + "/"); /* getting the older folder path */
            username = path.Substring(oldpath.Length, path.Length - oldpath.Length); /* subtracting older path from new path to get folder name */
            Session["currentpath"] = username; /* setting foldername */
            string currentpath = Server.MapPath("~/MyUploads/" + username + "/"); /* getting folder path from system root */

            
            DataTable dt_Infolder = new DataTable(); /* Datatable is Created to Add Dynamic Columns */
            dt_Infolder.Clear(); /* Clear table */
            
            /* adding columns */
            dt_Infolder.Columns.Add("File"); 
            dt_Infolder.Columns.Add("Size");
            dt_Infolder.Columns.Add("Type");
            
            GridView1.DataSource = dt_Infolder; /* Adding columns to datasource */
            GridView1.DataBind(); /* Binding datasource with grid */
            
            if ((Directory.GetFiles(currentpath).Length == 0)) /* if no files are there inside clicked folder */
            {
                /* pass */
            }
            else    /* if some files are there inside clicked folder */
            {
                ListOfData(); /* get updated files inside folder */
            }
            if (Directory.GetDirectories(currentpath).Length == 0) /* if no folders are there inside clicked folder */
            {
                GridView2.DataSource = null; /* emptying Datasource for Grid2 (grid used for folders) */
                GridView2.DataBind(); /* Binding datasource to Grid2, making folder grid disappear in UI */
            }
        }
        
        
        
        /*
        *   When a file is selected to be uploaded and the Upload button is clicked this function is triggered,
        *   if current file if saved will not exceed quota of user that is 1 GB then upload if it does then abort upload and inform user of insufficient storage.
        *   if file size exceeds 4GB we show a browser alert, saying maximum upload size exceeded. 
        */
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile) /* checking if the user has Uploaded a file */
            {
                try
                {
                    var file = FileUpload1.FileBytes; /* checking file size */
                    decimal size = decimal.Round(Convert.ToDecimal(Convert.ToInt32(file.Length) / 1024 / 1024 / 10.24), 2, MidpointRounding.AwayFromZero); /* converting to MB and its percentage in 1 GB */
                    decimal current_size = storage_used(); /* getting percentage of size of currently used space by user */
                    if ((size + current_size) < 100.00m) /* if adding current file wont exceed user storage quota save file in users storage */
                    {
                        FileName = FileUpload1.FileName; /* getting name of file */
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/MyUploads/" + Session["currentpath"].ToString() + "/") + FileName); /* File is saved in the current path */  
                        username = Session["currentpath"].ToString();
                    }
                    else /* if adding current file will exceed user storage, abort file upload and show notification */
                    {
                        Label1.Text = "File Size exceeds Storage quota please upgrade to tier 2";
                    }
                }
                catch(Exception ex) /* Alert is shown if a file is above 4GB */
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Size cannot exceed 4 GB "+ex+"');", true);
                }
            }
            ListOfData(); /* Update file data */
        }
        
        
        /* 
        *   Updates the Grid1 (grid containing files)
        */
        private void ListOfData()
        {
            if ((FileName == ("")) || (FileName == null)) /* fires when the upload button is clicked without selecting a file */
            {
                if (Directory.Exists(Server.MapPath("~/MyUploads/" + Session["username"].ToString() + "/"))) /* if currently set path exists on server */
                {
                    DataTable dt1 = new DataTable();  /* Datatable is Created to Add Dynamic Columns */  
                    
                    /* Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview for files */
                    dt1.Columns.Add("File");
                    dt1.Columns.Add("Size");
                    dt1.Columns.Add("Type");
                    
                    /* for all files in current path create row fields and add to datasource */
                    foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + Session["currentpath"].ToString() + "/"))) //Directory.GetFiles Method is used to Get the files from the Folder  
                    {


                        FileInfo fileinfo1 = new FileInfo(str); /* creating file object */
                        string filename_ex = fileinfo1.Name; /* Getting the Name of the File */
                        string filesize_ex = (fileinfo1.Length / 1024).ToString(); /* Getting the Size of the file and Converting it into KB from Bytes */
                        string filetype_ex = GetFileTypeByFileExtension(fileinfo1.Extension); /* Getting file Extension and Calling Custom Method */
                        dt1.Rows.Add(filename_ex, filesize_ex, filetype_ex); /* adding row fields to data source */
                    }
                    GridView1.DataSource = dt1; /* Setting the Values of DataTable to be Shown in Gridview  */
                    GridView1.DataBind(); /* Binding the Datasource to grid */
                    Loop_file_gridview(); /* Doing the same for folders */
                }
                else /* if currently set path does not exist on server, then create table in Database(SQL) for that user and create directory named after the user's username */
                {
                    SqlConnection con = new SqlConnection("Server=YOUR_SERVER_IP; uid=YOUR_UID; pwd=YOUR_PASSWORD; database=YOUR_DBNAME");
                    SqlCommand cmd = new SqlCommand("create table " + username + " (username varchar(25),filepath varchar(1000),userfile varchar(100),sizefile varchar(255))", con);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Directory.CreateDirectory(Server.MapPath("~/MyUploads/" + Session["username"].ToString()));
                }
            }
            else /*  */
            {
                var folder = Server.MapPath("~/MyUploads/" + username);

                DataTable dt = new DataTable(); /* Datatable is Created to Add Dynamic Columns */  
                
                /* Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview */
                dt.Columns.Add("File");
                dt.Columns.Add("Size");
                dt.Columns.Add("Type");
                
                string filename1 = "";
                string filesize1 = "";
                string filetype1 = "";
                
                /* Looping through Each file available in the MyUploads folder and adding them in fields of each row in datasource */
                foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + username + "/")))
                {
                    FileInfo fileinfo = new FileInfo(str); /* file object */ 
                    if (fileinfo.Name == FileName) /* this case is specially for when a new file has been added to update the grid */
                    {
                        filename1 = fileinfo.Name; /* Getting the Name of the File */
                        filesize1 = (fileinfo.Length / 1024).ToString(); /* Getting the Size of the file and Converting it into KB from Bytes */
                        filetype1 = GetFileTypeByFileExtension(fileinfo.Extension); /* Getting file Extension and Calling Custom Method  */
                        dt.Rows.Add(filename1, filesize1, filetype1); /* Adding Rows to the Datasource */
                    }
                    else /* for all files other than the uploaded file */
                    {
                        string filename = fileinfo.Name; /* Getting the Name of the File */ 
                        string filesize = (fileinfo.Length / 1024).ToString(); /* Getting the Size of the file and Converting it into KB from Bytes */
                        string filetype = GetFileTypeByFileExtension(fileinfo.Extension); /* Getting file Extension and Calling Custom Method */
                        dt.Rows.Add(filename, filesize, filetype); /* Adding Rows to the Datasource */
                    }
                }


                string user = Session["username"].ToString(); 

                SqlConnection con1 = new SqlConnection("Server=YOUR_SERVER_IP; uid=YOUR_UID; pwd=YOUR_PASSWORD; database=YOUR_DBNAME");
                SqlCommand cmd1 = new SqlCommand("insert into " + Session["username"].ToString() + " values(@username,@folder,@filename1,@filesize1)", con1);
                cmd1.Parameters.AddWithValue("@username", user);
                cmd1.Parameters.AddWithValue("@filename1", filename1);
                cmd1.Parameters.AddWithValue("@folder", folder);
                cmd1.Parameters.AddWithValue("@filesize1", filesize1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();

                GridView1.DataSource = dt; /* Setting the Values of Datasource to be Shown in Gridview */
                GridView1.DataBind(); /* Binding the Datasource to grid */
                Loop_file_gridview(); /* update folder grid */
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
         //Empty
        
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
                //Empty

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
        
         /* 
        *   A function to get the file data in a list as the users checks the checkbox.
        */
        
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

        /* 
        *   A function to get the folder data in a list as the users checks the checkbox
        */
        protected List<string> getfolderedata()
        {
            List<string> checkboxdataforlist = new List<string>(); /* List to store checkbox inputs*/
            foreach (GridViewRow gvrow in GridView2.Rows)  /*For each folder in Grid view */
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    LinkButton folderpath = (LinkButton)gvrow.FindControl("LinkButton1");

                    checkboxdataforlist.Add(folderpath.Text);
                }
            }

            
            return checkboxdataforlist;
        }
        
        /* 
        *   A function to load up a popup which prompts the user to enter comma seperated vales (csv) the usernames of users
        *   he/she wants to share files to.
        */
        protected void btPopupLoad_Click(object sender, EventArgs e)
        {
            var data = usernames_shared.Value;
            var data_arr = data.Split(',');
            /* Make lists to store the files, folders and invalid users names */
            List<string> list_file = new List<string>();
            list_file = getfiledata();
            List<string> list_folder = new List<string>();
            list_folder = getfolderedata();
            List<string> users = new List<string>();
            List<string> invalid_users = new List<string>();
            foreach (string user in data_arr)
            {
                if (User_exists(user.Trim())) /* Trim the spaces to not cause errors*/
                {
                    users.Add(user.Trim()); 
                }
                else
                {
                    invalid_users.Add(user.Trim());
                }
            }
            if (list_file.Count != 0)  /* If files exist*/
            {

                foreach (string file in list_file)
                {

                    table_share(users, Session["currentpath"].ToString() + "\\" + file, "file");

                }

            }

            if (list_folder.Count != 0) /* If folders exist*/
            {
                foreach (string folder_path in list_folder)
                {
                    table_share(users, Server.MapPath("~\\MyUploads\\" + Session["currentpath"].ToString() + "\\" + folder_path), "folder");
                }
            }

            if ((list_file.Count == 0) && (list_folder.Count == 0)) /* If neither files nor folders are selected*/
            {
                Response.Write("<script type= 'text/javascript'>alert('No files selected')</script>"); /* Send a JavaScript to alert the user */
            }
            else
            {
                /* If there are invalid users from the input which user gave alert the user by displaying their names in an alert*/
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
        
       /* 
        *   A function to create a table while contains the files shared to the user
        */
        
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
                        
                    }
                }
                catch
                {
                    con_share.Close();
                    /* If the path exists in the database dont insert as the file already exists */
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
                       
                    }

                }


            }

        }
        
        /* 
        *   A function to check if the filepath or folderpath exists in the database
        */
        protected bool path_exists(string tablename, string file_path)
        {
            bool exists = false;
            bool inside_folder = false;
            SqlConnection con_share1 = new SqlConnection("Server=YOUR_SERVER_IP; uid=YOUR_UID; pwd=YOUR_PASSWORD; database=YOUR_DBNAME");
            /* Select entries from the table with the filepath we want to check*/
            SqlCommand cmd_share1 = new SqlCommand("select * from " + tablename + " where  filepath=@filepath", con_share1); /
            cmd_share1.Parameters.AddWithValue("@filepath", file_path);
            con_share1.Open();
            SqlDataReader data_share = cmd_share1.ExecuteReader();
            if (data_share.HasRows) /* Update the boolean exists to true or false depending on the file path's existence */
            {
                exists = true;
                con_share1.Close();
            }
            else
            {
                exists = false;
                con_share1.Close();
            }

           
            string file_path_2 = Server.MapPath("~") + "MyUploads\\" + file_path; 
            /* Now select entries from the table with folder path we want to check*/
            SqlCommand cmd_inside_folder = new SqlCommand("select * from " + tablename + " where  filetype='folder'", con_share1);
            con_share1.Open();
            SqlDataReader cmd_data_inside_folder = cmd_inside_folder.ExecuteReader();
            if (cmd_data_inside_folder.HasRows) 
            {

                foreach (var path in cmd_data_inside_folder) /* Go through the paths of folders and update inside_folder to true if folder exists */
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
        
        /* 
        *   A function to check if the user details exists in the database which returns a boolean value
        *   indicating whether the username exists in the database or not
        */
        protected bool User_exists(string user)
        {
            bool exists = false;
            SqlConnection con_user_exists = new SqlConnection("Server=YOUR_SERVER_IP; uid=YOUR_UID; pwd=YOUR_PASSWORD; database=YOUR_DBNAME");
            SqlCommand cmd_user_exists = new SqlCommand("select * from cloudlogin where username=@username", con_user_exists);
            cmd_user_exists.Parameters.AddWithValue("@username", user.Trim());
            con_user_exists.Open();
            SqlDataReader data_user_exists = cmd_user_exists.ExecuteReader();

            if (data_user_exists.HasRows) /* Check the database for the user by calling the HasRows method and update exists variable */
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
