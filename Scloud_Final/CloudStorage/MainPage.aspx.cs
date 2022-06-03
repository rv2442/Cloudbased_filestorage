/*
*    @author: Vineet Dabholkar, Rahul Vijan
*
*    This Page is the Main Page of the website.
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudStorage
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileStorage.aspx"); /* Redirect to File Storage Page by clicking on the button on the center of the page */
        }
    }
}
