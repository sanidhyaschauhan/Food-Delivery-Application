using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DisplayActiveSessionCount();  
                LogApplicationShutdown();
            }
        }
        protected void btnMemberLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogin.aspx"); // Redirect to Member Login page
        }

        protected void btnStaffLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffLogin.aspx"); // Redirect to Staff Login page
        }
        private void DisplayActiveSessionCount() // Show current active sessions in terms of logged in and out
        {
            int activeSessions = 0;
            if (Application["TotalUserSessions"] != null)
            {
                activeSessions = (int)Application["TotalUserSessions"];
            }
            //lblActiveSessions.Text = $"Current Active Sessions: {activeSessions}";
        }
        private void LogApplicationShutdown()      
        {
            lblLastaccessed.Text = (string)Application["LastOpened"];
        }
    }
}