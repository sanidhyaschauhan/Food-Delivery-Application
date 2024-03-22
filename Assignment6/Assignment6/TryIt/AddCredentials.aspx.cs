using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Project5dll;


namespace TryIt
{
    public partial class AddCredentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthCookie"]!=null && Request.Cookies["AuthCookie"]["StaffLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            SaveStaff(txtUsername.Text, txtPassword.Text);
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