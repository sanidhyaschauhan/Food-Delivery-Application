using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TryIt
{
    public partial class EaterHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the "AuthCookie" does not exist, redirect to the login page (Default.aspx)
            if (Request.Cookies["AuthCookie"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            // Check if the user is logged in using a session variable
            if (Session["LoggedInUserName"] != null)
            {
                // Display a welcome message with the logged-in username in uppercase
                labelWelcomeName.Text = "Welcome " + ((string)Session["LoggedInUserName"]).ToUpper();
            }
            else
            {
                // Retrieve the username from the authentication cookie and display a welcome message
                HttpCookie myCookie = Request.Cookies["AuthCookie"];
                string username = myCookie["LoggedInUserName"];
                labelWelcomeName.Text = "Welcome " + username.ToUpper();
            }
        }

        protected void btnSearchRestaurant_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["AuthCookie"];
            string username = myCookie["LoggedInUserName"];
            // Redirect to the "SearchRestaurant.aspx" page when the button is clicked
            Response.Redirect($"SearchRestaurant.aspx?username={username}");
        }

        /*protected void btnOrderNow_Click(object sender, EventArgs e)
        {
            // Redirect to the "OrderNow.aspx" page when the button is clicked
            Response.Redirect("OrderNow.aspx");
        }*/

        protected void btnTrackOrder_Click(object sender, EventArgs e)
        {
            // Redirect to the "PayNow.aspx" page when the button is clicked
            Response.Redirect("Deliver.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session data
            Session.Clear();

            // Check if there are active user sessions and decrement the total count
            //if ((int)Application["TotalUserSessions"] > 0)
            //{
              //  Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            //
            //
            //}

            // Expire the authentication cookie by setting its expiration date to the past
            if (Request.Cookies["AuthCookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("AuthCookie");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            // Redirect to the login page (Default.aspx) or home page after logout
            Response.Redirect("Default.aspx");
        }
    }
}
