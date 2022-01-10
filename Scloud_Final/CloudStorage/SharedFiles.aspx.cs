using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CloudStorage
{
    public partial class SharedFiles : System.Web.UI.Page
    {
        FileStorage obj_extension = new FileStorage();
     
        string username;
        static List<string> list_file_paths = new List<string>();
        static List<string> list_folder_paths = new List<string>();
        SqlConnection con = new SqlConnection("Server=199.79.62.22;uid=training;pwd=Training@786;database=cmp");
        string tablename;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]== null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
               
                path_exists();
                Listoffiles_shared();
                Session["currentpath_shared"] = "";
            }

        }

        protected void Listoffolders_shared()
        {
            DataTable dt1 = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                             //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  

            dt1.Columns.Add("File");
            dt1.Columns.Add("Owner");

            foreach (string str in list_folder_paths) //Directory.GetFiles Method is used to Get the files from the Folder  
            {


                int index = str.IndexOf(@"\");
                string owner = str.Substring(0, index);
                dt1.Rows.Add(str, owner);
            }
            GridView2.DataSource = dt1; // Setting the Values of DataTable to be Shown in Gridview  
            GridView2.DataBind(); // Binding the Data 
        }

        protected void Listoffiles_shared()
        {

            DataTable dt1 = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                             //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
            dt1.Columns.Add("File");
            dt1.Columns.Add("Size");
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Owner");
            foreach (string str in list_file_paths) //Directory.GetFiles Method is used to Get the files from the Folder  
            {


                FileInfo fileinfo1 = new FileInfo(Server.MapPath("~\\MyUploads\\" + str));
                string filename_ex = fileinfo1.Name; //Getting the Name of the File  
                string filesize_ex = (fileinfo1.Length / 1024).ToString(); //Getting the Size of the file and Converting it into KB from Bytes  
                string filetype_ex = obj_extension.GetFileTypeByFileExtension(fileinfo1.Extension); //Getting file Extension and Calling Custom Method  
                int index = str.IndexOf(@"\");
                string owner = str.Substring(0, index);
                dt1.Rows.Add(filename_ex, filesize_ex, filetype_ex, owner);
            }
            GridView1.DataSource = dt1; // Setting the Values of DataTable to be Shown in Gridview  
            GridView1.DataBind(); // Binding the Data  
            Listoffolders_shared();
        }

        protected void path_exists()
        {
            list_file_paths.Clear();
            list_folder_paths.Clear();
            List<string> invalid_paths = new List<string>();
            tablename = Session["username"].ToString() + "_shared";
            SqlCommand cmd_file_path_exists = new SqlCommand("select * from " + tablename + " where filetype='file'", con);
            SqlCommand cmd_folder_path_exists = new SqlCommand("select * from " + tablename + " where filetype='folder'", con);

            con.Open();
            SqlDataReader data_file_paths = cmd_file_path_exists.ExecuteReader();
            while (data_file_paths.Read())
            {


                if (File.Exists(Server.MapPath("~\\MyUploads\\" + data_file_paths[2].ToString())))
                {
                    list_file_paths.Add(data_file_paths[2].ToString());
                }

                else
                {
                    invalid_paths.Add(data_file_paths[2].ToString());
                }


            }
            con.Close();
            con.Open();
            SqlDataReader data_folder_paths = cmd_folder_path_exists.ExecuteReader();
            while (data_folder_paths.Read())
            {

                if (Directory.Exists(data_folder_paths[2].ToString()))
                {
                    var path = data_folder_paths[2].ToString();
                    var rootpath = Server.MapPath("~") + "\\MyUploads\\";
                    path = path.Substring(rootpath.Length - 1);
                    list_folder_paths.Add(path);
                }

                else
                {
                    invalid_paths.Add(data_folder_paths[2].ToString());
                }
            }
            con.Close();


            if (invalid_paths.Count != 0)
            {
                foreach (string path in invalid_paths)
                {
                    delete_file_folder_path(path);
                }
            }
        }

        protected void delete_file_folder_path(string path)
        {
            SqlCommand cmd_delete_path = new SqlCommand("delete from " + tablename + " where filepath=@path", con);

            cmd_delete_path.Parameters.AddWithValue("@path", path);
            con.Open();
            cmd_delete_path.ExecuteNonQuery();
            con.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) //Is fired when File is Downloaded  
        {

            string filepath = "";
            foreach (string str in list_file_paths)
            {
                if (str.Contains(e.CommandArgument.ToString()))
                {
                    filepath = str;
                }
            }
            username = filepath;
            if (Session["currentpath_shared"].ToString().Length != 0)
            {
                username = Session["currentpath_shared"].ToString() + "\\" + e.CommandArgument.ToString();
            }
            Response.Write(username);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument); //Used to append the filename at the time of Downloading  
            Response.TransmitFile(Server.MapPath("~\\MyUploads\\" + username)); //Used to Fetch the file from the Physical folder of Server  
            Response.End();

        }


        protected void Path_changed()
        {

        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e) //Is fired when File is Downloaded  
        {
            //insidefile = true;
            Back.Visible = true;
            username = e.CommandArgument.ToString();
            Session["currentpath_shared"] = username;
            string currentpath = Server.MapPath("~/MyUploads/" + username + "/");

            DataTable dt_Infolder = new DataTable(); //Datatable is Created to Add Dynamic Columns
            dt_Infolder.Clear();
            dt_Infolder.Columns.Add("File");
            dt_Infolder.Columns.Add("Size");
            dt_Infolder.Columns.Add("Type");
            dt_Infolder.Columns.Add("Owner");
            GridView1.DataSource = dt_Infolder;
            GridView1.DataBind();
            // Response.Write(username);
            if ((Directory.GetFileSystemEntries(currentpath).Length == 0))
            {
                Response.Write("<br><br><br><br><br><br><br> No Files in this folder");
            }
            else
            {
                ListOfData();
            }
        }
        public void ListOfData()
        {


            DataTable dt = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                            //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
            dt.Columns.Add("File");
            dt.Columns.Add("Size");
            dt.Columns.Add("Type");
            dt.Columns.Add("Owner");
            //Looping through Each file available in the MyUploads folder  

            foreach (string str in Directory.GetFiles(Server.MapPath("~/MyUploads/" + username + "/"))) //Directory.GetFiles Method is used to Get the files from the Folder  
            {


                FileInfo fileinfo = new FileInfo(str); //Fileinfo class is used to fetch the information about the Fetched file  


                string filename = fileinfo.Name; //Getting the Name of the File  
                string filesize = (fileinfo.Length / 1024).ToString(); //Getting the Size of the file and Converting it into KB from Bytes  
                string filetype = obj_extension.GetFileTypeByFileExtension(fileinfo.Extension); //Getting file Extension and Calling Custom Method  
                int index = username.IndexOf(@"\");
                string owner = username.Substring(0, index);
                dt.Rows.Add(filename, filesize, filetype, owner); //Adding Rows to the DataTable  


            }


            GridView1.DataSource = dt; // Setting the Values of DataTable to be Shown in Gridview  
            GridView1.DataBind(); // Binding the Data  
            Loop_file_gridview();

        }
        protected void Loop_file_gridview()
        {
            try
            {

                GridView2.DataSource = null;
                GridView2.DataBind();
                string folder = Server.MapPath("~\\MyUploads\\" + Session["currentpath_shared"].ToString());
                DataTable dt_folder = new DataTable(); //Datatable is Created to Add Dynamic Columns  
                                                       //Columns Added with the Same name as that of Eval Expression and the DataField Value of the Gridview  
                dt_folder.Columns.Add("File");
                dt_folder.Columns.Add("Owner");



                foreach (string str in Directory.EnumerateDirectories(folder)) //Directory.GetFiles Method is used to Get the files from the Folder  
                {
                    int index = str.LastIndexOf(@"\");
                    string foldername = str.Substring(index + 1);
                    string path = str.Substring(str.Length - (Session["currentpath_shared"].ToString() + "\\" + foldername).Length);
                    index = path.IndexOf(@"\");
                    string owner = path.Substring(0, index);


                    dt_folder.Rows.Add(path, owner); //Adding Rows to the DataTable

                    GridView2.DataSource = dt_folder; // Setting the Values of DataTable to be Shown in Gridview  
                    GridView2.DataBind();

                }
            }
            catch
            {
                Response.Write("<br>" + Session["currentpath_shared"].ToString() + "<br> No Folder inside current folder");
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            string path_og = Session["currentpath_shared"].ToString();
            int index = path_og.LastIndexOf(@"\");
            string new_path_back = path_og.Substring(0, index);
            //Response.Write(new_path_back);
            foreach (string str in list_folder_paths)
            {

                if (new_path_back.Contains(str))
                {
                    Response.Write(new_path_back);
                    Session["currentpath_shared"] = new_path_back;
                    username = new_path_back;
                    ListOfData();
                }
                else
                {
                    Back.Visible = false;
                    Session["currentpath_shared"] = "";
                    Listoffiles_shared();

                }

            }

        }


    }
}