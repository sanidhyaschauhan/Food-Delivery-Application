using System;
using System.Collections;
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
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if a staff member is already logged in, and if so, redirect to AddCredentials.aspx
            HttpCookie authCookie = Request.Cookies["AuthCookie"];

            if (authCookie != null && authCookie["StaffLoggedIn"] == "true")
            {
                Response.Redirect("StaffLoginHome.aspx");
            }

            // Check if the page is not being loaded due to a postback (e.g., button click)
            if (!IsPostBack)
            {
                // Disable the staff login button and display the count of active user sessions
                setButtonState(false);
                //DisplayActiveSessionCount();
            }
        }

        protected void btnGenerateCaptcha_Click(object sender, EventArgs e)
        {
            // Generate and display a CAPTCHA image
            Project5dll.Authentication captcha = new Project5dll.Authentication();
            Project5dll.CaptchaInfo captchaInfo = captcha.GetCaptchaImage();
            imgCaptcha.ImageUrl = "data:image/jpeg;base64," + captchaInfo.CaptchaImageBase64;
            Session["CaptchaText"] = captchaInfo.CaptchaId;
        }

        protected void btnVerifyCaptcha_Click(object sender, EventArgs e)
        {
            if (txtCaptchaInput.Text == (string)Session["CaptchaText"])
            {
                // Correct CAPTCHA, enable the staff login button
                captchaError.Text = "";
                setButtonState(true);
            }
            else
            {
                // Incorrect CAPTCHA, display an error message and optionally regenerate it
                captchaError.Text = "Invalid Captcha. Please Try Again.";
                setButtonState(false);
                btnGenerateCaptcha_Click(sender, e); // Regenerate the CAPTCHA
            }
        }

        private void setButtonState(bool state)
        {
            // Enable or disable the staff login button based on the provided state
            btnStaffLogin.Enabled = state;
        }

        protected void btnStaffLogin_Click(object sender, EventArgs e)
        {
            // Attempt to authenticate the staff member with the provided username and password
            AuthenticateUser(txtUsername.Text, txtPassword.Text);
        }

        private void AuthenticateUser(string username, string password)
        {
            Project5dll.Authentication authentication = new Project5dll.Authentication();
            string encryptedPassword = authentication.Hash(password);
            string filePath = Server.MapPath("~/App_Data/StaffUsers.xml");

            if (File.Exists(filePath))
            {
                XDocument xmlDoc = XDocument.Load(filePath);
                var user = xmlDoc.Root.Elements("User")
                    .FirstOrDefault(x =>
                        x.Element("Username").Value.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                        x.Element("Password").Value == encryptedPassword);

                if (user != null)
                {
                    // Increase the count of active user sessions, set authentication cookie, and redirect to AddCredentials.aspx
                    signInError.Text = "Authenticated successfully";
                    HttpCookie authCookie = new HttpCookie("AuthCookie");
                    authCookie["StaffLoggedIn"] = "true";
                    authCookie["LoggedInUserName"] = username;
                    authCookie.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(authCookie);
                    Response.Redirect($"StaffLoginHome.aspx?name={txtUsername.Text}");
                }
                else
                {
                    // Display an error message for incorrect username or password
                    signInError.Text = "Incorrect username or password. Please signup if you don't have an account";
                }
            }
            else
            {
                // Display an error message for non-existing accounts
                signInError.Text = "Account does not exist. Please sign up";
            }
        }

        private void DisplayActiveSessionCount()
        {
            // Display the count of active user sessions
            int activeSessions = 0;
            if (Application["TotalUserSessions"] != null)
            {
                activeSessions = (int)Application["TotalUserSessions"];
            }
            lblActiveSessions.Text = $"Current Active Sessions: {activeSessions}";
        }
    }
}
