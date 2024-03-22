using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class ServeImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imagePath = Server.MapPath("~/App_Data/flow.png");

            // Set the appropriate ContentType.
            Response.ContentType = "image/png"; 
            Response.WriteFile(imagePath);
            Response.End();
        }
    }
}