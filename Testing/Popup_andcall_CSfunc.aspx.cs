using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ApplicationServices;
using System.Web.Script.Serialization;

namespace Website_.NET
{
    
    
    public partial class Popup_andcall_CSfunc : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }


        
        
        protected void btPopupLoad_Click(object sender, EventArgs e)
        {
            var a = usernames_shared.Value;
            Response.Write(a);
        }
        
    }
}