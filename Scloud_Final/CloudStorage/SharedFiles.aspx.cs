/*
*    @file: SharedFiles.aspx.cs
*    @author: Vineet Dabholkar, Rahul Vijan
*    This Page is used to View and Manage Files shared by other users to logged in user
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;co
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CloudStorage
{
    public partial class SharedFiles : System.Web.UI.Page
    {
        FileStorage obj_extension = new FileStorage(); /* creating global object to for FileStorage.aspx.cs */
     
        /* global definitions */
        string username;
        static List<string> list_file_paths = new List<string>();
        static List<string> list_folder_paths = new List<string>();
        SqlConnection con = new SqlConnection("Server=YOUR_SERVER_IP;uid=YOUR_UID;pwd=YOUR_PASSWORD;database=YOUR_DBNAME");
        string tablename;



        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]== null) /* if user session is not maintained then redirect to login.aspx */
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack) /* on 1st page load event, check if all paths of files and folders shared to a user exists on the owners account */
            {
                path_exists(); /* check if path all in user_shared table for logged in user exist, if not remove those entries */
                Listoffiles_shared(); /* update grids */
                Session["currentpath_shared"] = ""; /* init */
            }
        }



        protected void Listoffolders_shared() /* set inital folder grid for folder paths in user_shared table */
        {
            DataTable dt1 = new DataTable(); /* Datatable is Created to Add Dynamic Columns */
            
            /* Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview */
            dt1.Columns.Add("File");
            dt1.Columns.Add("Owner");

            foreach (string str in list_folder_paths) /* for each folderpath in list */ 
            {
                int index = str.IndexOf(@"\"); /* getting index of \ in path string of format username/... */
                string owner = str.Substring(0, index); /* extracting username of folder owner by string slicing */
                dt1.Rows.Add(str, owner);
            }
            GridView2.DataSource = dt1; /* Setting the Values of Datasource */
            GridView2.DataBind(); /* binding datasource to grid2 (folder grid) */
        }




        protected void Listoffiles_shared() /* set inital file grid for file paths in user_shared table */
        {
            DataTable dt1 = new DataTable(); /* Datatable is Created to Add Dynamic Columns */  
            
            /* Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview (file grid) */
            dt1.Columns.Add("File");
            dt1.Columns.Add("Size");
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Owner");
            
            foreach (string str in list_file_paths)  
            {
                FileInfo fileinfo1 = new FileInfo(Server.MapPath("~\\MyUploads\\" + str)); /* file object */
                string filename_ex = fileinfo1.Name; /* Getting the Name of the File */
                string filesize_ex = (fileinfo1.Length / 1024).ToString(); /* Getting the Size of the file and Converting it into KB from Bytes */  
                string filetype_ex = obj_extension.GetFileTypeByFileExtension(fileinfo1.Extension); /* Getting file Extension and Calling Custom Method */  
                int index = str.IndexOf(@"\"); /* getting index of \ in path string of format username/... */
                string owner = str.Substring(0, index); /* extracting username of file owner by string slicing */
                dt1.Rows.Add(filename_ex, filesize_ex, filetype_ex, owner);
            }
            GridView1.DataSource = dt1; /* Setting the Values of Datasource */ 
            GridView1.DataBind(); /* binding datasource to grid1 (file grid) */  
            
            Listoffolders_shared(); /* update folder grid */
        }


        
        
        /*  check if file/folder exists on the owner's storage,
        *   if yes add to list,
        *   if not delete entry from user_shared sql table
        */
        protected void path_exists() 
        {
            /* list init */
            list_file_paths.Clear();
            list_folder_paths.Clear();
            List<string> invalid_paths = new List<string>(); /* invalid paths will be stored here */
            
            tablename = Session["username"].ToString() + "_shared";
            SqlCommand cmd_file_path_exists = new SqlCommand("select * from " + tablename + " where filetype='file'", con); /* file query */
            SqlCommand cmd_folder_path_exists = new SqlCommand("select * from " + tablename + " where filetype='folder'", con); /* folder query */

            con.Open();
            SqlDataReader data_file_paths = cmd_file_path_exists.ExecuteReader(); /* execute file query */
            while (data_file_paths.Read()) /* executes for all entries found */
            {
                if (File.Exists(Server.MapPath("~\\MyUploads\\" + data_file_paths[2].ToString()))) /* [2] is for path (column 3 in sql table) */
                {
                    list_file_paths.Add(data_file_paths[2].ToString()); /* add to valid list */
                }
                else
                {
                    invalid_paths.Add(data_file_paths[2].ToString()); /* add to invalid list */
                }
            }
            con.Close();
            
            con.Open();
            SqlDataReader data_folder_paths = cmd_folder_path_exists.ExecuteReader(); /* execute folder query */
            while (data_folder_paths.Read()) /* executes for all entries found */
            {
                if (Directory.Exists(data_folder_paths[2].ToString())) /* [2] is for path (column 3 in sql table) */
                {
                    var path = data_folder_paths[2].ToString(); /* path of folder w.r.t system root */
                    var rootpath = Server.MapPath("~") + "\\MyUploads\\"; /* getting path till MyUploads w.r.t system root */
                    path = path.Substring(rootpath.Length - 1); /* returns path - rootpath */
                    list_folder_paths.Add(path); /* add to valid list */
                }
                else
                {
                    invalid_paths.Add(data_folder_paths[2].ToString()); /* add to invalid llst */
                }
            }
            con.Close();

            /* if invalid_path list has atleast 1 element */
            if (invalid_paths.Count != 0)
            {
                foreach (string path in invalid_paths) /* delete all paths in invalid list from shared_user table for logged in user */
                {
                    delete_file_folder_path(path); /* delete path from shared_user table for logged in user */
                }
            }
        }




        protected void delete_file_folder_path(string path) /* delete path from shared_user table for logged in user */
        {
            SqlCommand cmd_delete_path = new SqlCommand("delete from " + tablename + " where filepath=@path", con); /* delete query */

            cmd_delete_path.Parameters.AddWithValue("@path", path);
            con.Open();
            cmd_delete_path.ExecuteNonQuery();
            con.Close();
        }
        
        
        
        
        /* 
        *   Is fired when File is clicked in grid1 (file grid) 
        *   GridViewCommandEventArgs e, here 'e' has the name of file which is clicked
        *   if any of the filepaths in file list has the filename (e) in it then, use that path to force download that file to the user
        */
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            /* local variable */
            string filepath = "";
            
            foreach (string str in list_file_paths)
            {
                if (str.Contains(e.CommandArgument.ToString())) /* if filepath in list has clicked file's filename */
                {
                    filepath = str;
                }
            }
            
            username = filepath; /* local variable */
            if (Session["currentpath_shared"].ToString().Length != 0) /* will not trigger on 1st page load event, and when it does username gets assigned the currentpath_shared */
            {
                username = Session["currentpath_shared"].ToString() + "\\" + e.CommandArgument.ToString();
            }
            
            Response.Clear(); /* clear buffer */
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument); /* Used to append the filename at the time of Downloading */
            Response.TransmitFile(Server.MapPath("~\\MyUploads\\" + username)); /* Used to Fetch the file from the Physical path of Server */ 
            Response.End();
        }




        protected void Path_changed()
        {
            /* null */
        }
        
        
        
        
        /* 
        *   Is fired when Folder is clicked,
        *   we update currentpath_shared to that of clicked folder 
        */
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Back.Visible = true; /* when we go into a folder we make the back button visible for navigation through the folders */
            username = e.CommandArgument.ToString(); /* folder path w.r.t folder owner's root directory (from MyUploads/) */
            Session["currentpath_shared"] = username;
            string currentpath = Server.MapPath("~/MyUploads/" + username + "/"); /* folder path w.r.t system's root directory */


            /* Datatable is Created to Add Dynamic Columns */
            DataTable dt_Infolder = new DataTable();
            dt_Infolder.Clear(); /* datatable init */
            
            /* column fields */
            dt_Infolder.Columns.Add("File");
            dt_Infolder.Columns.Add("Size");
            dt_Infolder.Columns.Add("Type");
            dt_Infolder.Columns.Add("Owner");
            
            GridView1.DataSource = dt_Infolder; /* setting datasource */
            GridView1.DataBind(); /* binding datasource to grid1 (file grid) */

            
            if ((Directory.GetFileSystemEntries(currentpath).Length == 0)) /* if no files are there inside clicked folder */
            {
                Response.Write("<br><br><br><br><br><br><br> No Files in this folder"); /* notify */
            }
            else /* clicked folder haves atleast 1 file */
            {
                ListOfData(); /* update file grid */
            }
        }
        
        
        
        /*
        *   when a folder in grid2 (folder grid) is clicked path is updated and file grid is updated
        */
        public void ListOfData()
        {
            DataTable dt = new DataTable(); /* Datatable is Created to Add Dynamic Columns */
            
            /* Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview */
            dt.Columns.Add("File");
            dt.Columns.Add("Size");
            dt.Columns.Add("Type");
            dt.Columns.Add("Owner");  

            foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + username + "/"))) /* iterate through all files in clicked folder */  
            {
                FileInfo fileinfo = new FileInfo(str); /* file object */  

                string filename = fileinfo.Name; /* Getting the Name of the File */
                string filesize = (fileinfo.Length / 1024).ToString(); /* Getting the Size of the file and Converting it into KB from Bytes */
                string filetype = obj_extension.GetFileTypeByFileExtension(fileinfo.Extension); /* Getting file Extension by calling Method from FileStorage.aspx */ 
                int index = username.IndexOf(@"\"); /* getting index of \ in path string of format username\... */
                string owner = username.Substring(0, index); /* extracting username of file owner by string slicing */
                dt.Rows.Add(filename, filesize, filetype, owner); /* adding Row fields to the columns of DataTable */
            }
            
            GridView1.DataSource = dt; /* setting datasource */ 
            GridView1.DataBind(); /* binding datasource to grid1 (file grid) */  
            Loop_file_gridview(); /* update grid2 (folder grid) */
        }
        
        
        
        
        /*
        *   when a folder in grid2 (folder grid) is clicked path is updated and folder grid is updated
        */
        protected void Loop_file_gridview()
        {
            try 
            {
                GridView2.DataSource = null; /* grid init */
                GridView2.DataBind(); /* clear older grid (folder) */
                string folder = Server.MapPath("~\\MyUploads\\" + Session["currentpath_shared"].ToString()); /* getting clicked folder path w.r.t system root */
                DataTable dt_folder = new DataTable(); /* Datatable is Created to Add Dynamic Columns */
                
                /* Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview */
                dt_folder.Columns.Add("File");
                dt_folder.Columns.Add("Owner");

                foreach (string str in Directory.EnumerateDirectories(folder)) /* for each directory in clicked folder */  
                {
                    /*
                    *   getting last index of \ in path string of format username\...,
                    *   returns starting index where folders in clicked foldername starts 
                    *   eg: C:\users\user\project\project_name\MyUploads\User_A\MyFiles_and_Folders here index (last index of \ +1) gives index value from 'M' in MyFiles_and_Folders
                    *   this is then used to update Grid2 (folder grid)
                    */
                    int index = str.LastIndexOf(@"\"); /* getting last index of \ in path string of format ~\MyUploads\username\... */
                    string foldername = str.Substring(index + 1); /* foldername of folder inside clicked folder */
                    
                    /* 
                    *   str - > D:/Scloud/CloudStorage/MyUploads/Rv2442/myfolder (48)
                    *   foldername -> myfolder
                    *   session.currentpath + foldername - > MyUploads/Rv2442/myfolder (21)
                    *   path -> Rv2442/myfolder
                    *   index of '/' is returned
                    *   got owner name
                    */
                    string path = str.Substring(str.Length - (Session["currentpath_shared"].ToString() + "\\" + foldername).Length); 
                    index = path.IndexOf(@"\"); 
                    string owner = path.Substring(0, index); /* owner's name of folder */

                    dt_folder.Rows.Add(path, owner); /* Adding column fields of Row to the DataTable */

                    GridView2.DataSource = dt_folder; /* Setting datasource */  
                    GridView2.DataBind(); /* binding datasource to grid2 (folder grid) */
                }
            }
            catch
            {
                Response.Write("<br>" + Session["currentpath_shared"].ToString() + "<br> No Folder inside current folder");
            }
        }



        /*
        *   goes back a directory
        */
        protected void Back_Click(object sender, EventArgs e)
        {
            string path_og = Session["currentpath_shared"].ToString(); /* path of shared folder before back click */
            int index = path_og.LastIndexOf(@"\"); /* getting last index of '/' to go back a directory */
            string new_path_back = path_og.Substring(0, index); /* updating path to a directory backward (cd ..) */
            
            
            /*
            *   *Context*
            *   list_folder_paths is a list which has the folderpaths that were shared by a user to current logged in user
            *   these folders exists on the owner's storage account,
            *   they are imported from the user_shared table from the DB_Server, these entries are created at the time when the owner's shares it to some user
            */
            foreach (string str in list_folder_paths)
            {
                if (new_path_back.Contains(str)) /* checks if the strings in list_folder_paths  are a subset of the new set path */
                {
                    /* updating global vars */
                    Session["currentpath_shared"] = new_path_back; 
                    username = new_path_back;
                    
                    ListOfData(); /* Update grid */
                }
                else
                {
                    Back.Visible = false; /* disable back  */
                    Session["currentpath_shared"] = ""; /* set path back to init state */
                    Listoffiles_shared(); /* Update grid */
                }
            }
        }
    }
}
