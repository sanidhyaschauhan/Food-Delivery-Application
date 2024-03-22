using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace TryIt
{
    public partial class Deliver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the "AuthCookie" does not exist, redirect to the login page (Default.aspx)
            if (Request.Cookies["AuthCookie"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnGetDeliveryDetails_Click(object sender, EventArgs e)
        {
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();
            string user_address = txtUserAddress.Text;
            string restaurantadd = txtRestaurantAddress.Text;
            WSDLservicereference.DeliveryDeatils deliveryDeatils = client.GetDeliveryDetails(user_address, restaurantadd);
            lblDeliverydetails.Text = $"Distance: {deliveryDeatils.Distance}, Time: {deliveryDeatils.Time}";
        }

        private string GetUserAddress(string username)
        {
            string filepath = Server.MapPath("~/App_Data/EaterUsers.xml");
            XDocument doc = XDocument.Load(filepath);
            var user = doc.Descendants("User")
                          .FirstOrDefault(u => u.Element("Username")?.Value == username);
            return user?.Element("Address")?.Value;
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Check if there are active user sessions and decrement the total count
            if ((int)Application["TotalUserSessions"] > 0)
            {
                Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            }

            // Clear the session data
            Session.Clear();

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
