using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace TryIt
{
    public partial class StaffLoginHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myCookie = Request.Cookies["AuthCookie"];

            // Check if the "AuthCookie" does not exist, redirect to the login page (Default.aspx)
            if (Request.Cookies["AuthCookie"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            string username = myCookie["LoggedInUserName"];
            labelWelcomeName.Text = "Welcome " + username.ToUpper();

            WSDLservicereference.WsdlServicesClient client = new WSDLservicereference.WsdlServicesClient();
            WSDLservicereference.Order[] allOrders = client.LoadOrders();

            // Populate the table with order data
            foreach (var order in allOrders)
            {
                TableRow row = new TableRow();

                TableCell cellOrderId = new TableCell();
                cellOrderId.Text = order.OrderId.ToString();
                row.Cells.Add(cellOrderId);

                TableCell cellCustomerName = new TableCell();
                cellCustomerName.Text = order.CustomerName;
                row.Cells.Add(cellCustomerName);

                TableCell cellRestaurantName = new TableCell();
                cellRestaurantName.Text = order.RestaurantName;
                row.Cells.Add(cellRestaurantName);

                TableCell cellCustomerAddress = new TableCell();
                cellCustomerAddress.Text = order.CustomerAddress;
                row.Cells.Add(cellCustomerAddress);

                TableCell cellAmount = new TableCell();
                cellAmount.Text = order.Amount.ToString("C"); // Format as currency
                row.Cells.Add(cellAmount);

                OrdersTable.Rows.Add(row);
            }
        }

        protected void btnAddCredentials_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCredentials.aspx");
        }

        private void SaveStaff(string username, string password)
        {
            Project5dll.Authentication authentication = new Project5dll.Authentication();
            // Use the DLL to encrypt the password
            string encryptedPassword = authentication.Hash(password);


            // Choose the correct file based on the user type
            string filePath = Server.MapPath("~/App_Data/StaffUsers.xml");

            // Load or create the XML document
            XDocument xmlDoc = File.Exists(filePath) ? XDocument.Load(filePath) : new XDocument(new XElement("Staff"));

            // Add the new user
            xmlDoc.Root.Add(new XElement("User",
                new XElement("Username", username),
                new XElement("Password", encryptedPassword)));

            // Save the document
            xmlDoc.Save(filePath);
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if ((int)Application["TotalUserSessions"] > 0)
            {
                Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            }
            // Clear the session
            Session.Clear();

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