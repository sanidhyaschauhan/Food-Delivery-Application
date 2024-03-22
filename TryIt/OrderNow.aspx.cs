using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TryIt.WSDLservicereference;

namespace TryIt
{
    public partial class OrderNow : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string restaurantName = Request.QueryString["Name"];
            string restaurantAddress = Request.QueryString["Address"];
            lblName.Text = restaurantName;
            

            // Check if the "AuthCookie" does not exist, redirect to the login page (Default.aspx)
            if (Request.Cookies["AuthCookie"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnViewMenu_Click(object sender, EventArgs e)
        {
            string restaurantID = Request.QueryString["id"];
            // Create a client to access the OrderNowServiceReference web service
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();

            // Get the menu items from the web service and bind them to a GridView
            Dictionary<string, double> menuItems = client.GetMenu(restaurantID);

            grdMenu.DataSource = menuItems;
            grdMenu.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Create a client to access the OrderNowServiceReference web service
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();

            try
            {
                string itemName = txtItemName.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                // Add the selected item to the shopping cart via the web service
                client.AddToCart(itemName, price, quantity);
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error: " + ex.Message;
            }
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            // Create a client to access the OrderNowServiceReference web service
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();

            try
            {
                // Retrieve the shopping cart items from the web service and display them in a GridView
                List<CartItem> cartItems = client.ViewCart().ToList();

                CartGridView.DataSource = cartItems;
                CartGridView.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error: " + ex.Message;
            }
        }

        protected void GetTotalAmountButton_Click(object sender, EventArgs e)
        {
            // Create a client to access the OrderNowServiceReference web service
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();
            // Assuming the GetTotalAmount() method returns the total amount.
            double totalAmount = client.GetTotalAmount();

            // Display the total amount in the TotalAmountLabel
            TotalAmountLabel.Text = "Total Amount: $" + totalAmount.ToString("F2");
        }

        protected void ApplyCouponButton_Click(object sender, EventArgs e)
        {
            // Create a client to access the OrderNowServiceReference web service
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();
            string couponCode = CouponCodeTextBox.Text;
            // Assuming the ApplyCoupon() method returns the discounted amount.
            double discountedAmount = client.ApplyCoupon(couponCode);

            // Display the discounted amount and clear the TotalAmountLabel
            CouponAmountLabel.Text = "Discounted Amount: $" + discountedAmount.ToString("F2");
            TotalAmountLabel.Text = string.Empty;
        }

        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {

            HttpCookie myCookie = Request.Cookies["AuthCookie"];
            string username = myCookie["LoggedInUserName"];
            string emailAddress = GetUserEmail(username);
            string restaurantAddress = Request.QueryString["Address"];
            //Create a client to access the OrderNowServiceReference web service
            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();

            Random random = new Random();
            double totalamount = client.GetTotalAmount();
            int threeDigitNumber = random.Next(100, 1000);
            string orderID = "o" + threeDigitNumber;
            string restaurantName = Request.QueryString["Name"];
  
            if (CouponAmountLabel.Text != string.Empty)
            {
                totalamount = 0.9 * totalamount;
            }
            client.StoreOrder(orderID, username, restaurantName, GetUserAddress(username), totalamount);
            //Assuming the PlaceOrder() method places the order and returns a confirmation message.
            // Display a confirmation message for the successfully placed order
            ResultLiteral1.Text = "Order Successfully Placed. OrderId: o123";
            string restaurantadd = Request.QueryString["Address"];
            client.PlaceOrder(emailAddress);
            Response.Redirect($"PayNow.aspx?address={restaurantadd}&name={restaurantName}&email={emailAddress}&orderID={orderID}");
        }

        private string GetUserEmail(string username)
        {
            string filepath = Server.MapPath("~/App_Data/EaterUsers.xml");
            XDocument doc = XDocument.Load(filepath);
            var user = doc.Descendants("User")
                          .FirstOrDefault(u => u.Element("Username")?.Value == username);
            return user?.Element("Email")?.Value;
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
            // Clear the session data
            Session.Clear();

            // Check if there are active user sessions and decrement the total count
            /*
            if ((int)Application["TotalUserSessions"] > 0)
            {
                Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            }
            */
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
