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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnSignUpEater_Click(object sender, EventArgs e)
        {
            SaveUser("eater", txtUsername.Text, txtPassword.Text, txtEmail.Text, txtAddress.Text);
        }

        protected void btnSignUpDeliveryPartner_Click(object sender, EventArgs e)
        {
            SaveUser("deliveryPartner", txtUsername.Text, txtPassword.Text, txtEmail.Text, txtAddress.Text);
        }

        private void SaveUser(string userType, string username, string password, string email, string address)
        {
            Project5dll.Authentication authentication = new Project5dll.Authentication();
            // Use the DLL to encrypt the password
            string encryptedPassword = authentication.Encrypt(password); 

            // Path to XML files
            string eaterXmlPath = Server.MapPath("~/App_Data/EaterUsers.xml");
            string deliveryPartnerXmlPath = Server.MapPath("~/App_Data/DeliveryPartnerUsers.xml");

            // Choose the correct file based on the user type
            string filePath = userType == "eater" ? eaterXmlPath : deliveryPartnerXmlPath;

            // Load or create the XML document
            XDocument xmlDoc = File.Exists(filePath) ? XDocument.Load(filePath) : new XDocument(new XElement("Users"));

            // Add the new user
            xmlDoc.Root.Add(new XElement("User",
                new XElement("Username", username),
                new XElement("Password", encryptedPassword),
                new XElement("Email", email),
                new XElement("Address", address)));

            // Save the document
            xmlDoc.Save(filePath);
        }
        private void DisplayActiveSessionCount()
        {
            int activeSessions = 0;
            if (Application["TotalUserSessions"] != null)
            {
                activeSessions = (int)Application["TotalUserSessions"];
            }
            //lblActiveSessions.Text = $"Current Active Sessions: {activeSessions}";
        }
    }
}