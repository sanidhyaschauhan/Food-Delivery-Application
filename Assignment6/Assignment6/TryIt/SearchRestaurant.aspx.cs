using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.Xml.Linq;

namespace TryIt
{
    public partial class SearchRestaurant : System.Web.UI.Page
    {
        int check = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            
             fetch_restaurants();
        }

        async void fetch_restaurants()
        {

            try
            {
                WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();

                string username = Request.QueryString["username"];
                var address = GetUserAddress(username);
                WSDLservicereference.RestaurantDetails[] restaurants = client.GetRestaurantsByAddress(address);
                RepeaterRestaurants.DataSource = restaurants;
                RepeaterRestaurants.DataBind();
            }
            catch (Exception ex)
            {
                litResult.Text = $"Error: {ex.Message}";
            }
        }

        public string GetUserAddress(string username)
        {
            string filepath = Server.MapPath("~/App_Data/EaterUsers.xml");
            XDocument doc = XDocument.Load(filepath);
            var user = doc.Descendants("User")
                          .FirstOrDefault(u => u.Element("Username")?.Value == username);
            return user?.Element("Address")?.Value;
        }

        protected async void btnSearch_Click(object sender, EventArgs e)
        {
            check = 1;
            litResult.Text = string.Empty;
            var address = TextBox1.Text;
            if (string.IsNullOrWhiteSpace(address))
            {
                litResult.Text = "Please enter an address or zipcode.";
                return;
            }

            try
            {
                WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();
                WSDLservicereference.RestaurantDetails[] restaurants = client.GetRestaurantsByAddress(address);
                RepeaterRestaurants.DataSource = restaurants;
                RepeaterRestaurants.DataBind();
            }
            catch (Exception ex)
            {
                litResult.Text = $"Error: {ex.Message}";
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();
            /*if ((int)Application["TotalUserSessions"] > 0)
            {
                Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            }*/
            // Expire the authentication cookie
            if (Request.Cookies["AuthCookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("AuthCookie");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            // Redirect to the login page or home page after logout
            Response.Redirect("Default.aspx");
        }
    }
}