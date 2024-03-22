using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TryIt.WSDLservicereference;

namespace TryIt
{
    public partial class PayNow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Get the input values from TextBox8, TextBox9, and TextBox10
            string cardNumber = TextBox8.Text;
            string expiry = TextBox9.Text;
            string cvv = TextBox10.Text;

            // Call the service reference operation DoPayment
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();
           
            string result = client.DoPayment(cardNumber, expiry, cvv);

            // Display the result in TextBox11
            

            // Close the service client
            

            if(result== "Card number has been validated. Your transaction is successful.")
            {
                string restaurantadd = Request.QueryString["Address"];
                string restaurantName = Request.QueryString["name"];
                string emailaddress = Request.QueryString["email"];
                string orderID = Request.QueryString["orderID"];
                //client.PlaceOrder(emailaddress);
                client.NotifyPayment(emailaddress, restaurantName);
                //Response.Redirect($"Deliver.aspx?address={restaurantadd}&orderID={orderID}");
                HttpCookie myCookie = Request.Cookies["AuthCookie"];
                string username = myCookie["LoggedInUserName"];
                string user_address = GetUserAddress(username);
                WSDLservicereference.DeliveryDeatils deliveryDeatils = client.GetDeliveryDetails(user_address, restaurantadd);
                lblDeliverydetails.Text = $"Order is successfully placed. The order will be delivered in Time: {deliveryDeatils.Time}, distance to be travelled: {deliveryDeatils.Distance}";
            }

            else
            {
                Label11.Text = result;
            }

            client.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();
            if ((int)Application["TotalUserSessions"] > 0)
            {
                Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            }
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

        private string GetUserAddress(string username)
        {
            string filepath = Server.MapPath("~/App_Data/EaterUsers.xml");
            XDocument doc = XDocument.Load(filepath);
            var user = doc.Descendants("User")
                          .FirstOrDefault(u => u.Element("Username")?.Value == username);
            return user?.Element("Address")?.Value;
        }



    }
}