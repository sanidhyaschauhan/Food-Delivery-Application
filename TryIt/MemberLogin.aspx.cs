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
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the "AuthCookie" exists in the user's request
            HttpCookie authCookie = Request.Cookies["AuthCookie"];

            // Check if a user with the "eaterLoggedIn" attribute is logged in, if yes, redirect to EaterHome.aspx
            if (authCookie != null && authCookie["eaterLoggedIn"] == "true")
            {
                Response.Redirect("EaterHome.aspx");
            }
            // Check if a user with the "deliveryLoggedIn" attribute is logged in, if yes, TODO: handle redirection
            else if (authCookie != null && authCookie["deliveryLoggedIn"] == "true")
            {
                // TODO: Handle redirection for delivery partners
                Response.Redirect("Deliver.aspx");
            }

            // Check if the page is not being loaded due to a postback (e.g., button click)
            if (!IsPostBack)
            {
                // Disable login buttons and display the count of active user sessions
                setButtonState(false);
                DisplayActiveSessionCount();
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
            // Verify the entered CAPTCHA text
            if (txtCaptchaInput.Text == (string)Session["CaptchaText"])
            {
                // Correct CAPTCHA, enable login buttons
                captchaError.Text = "";
                setButtonState(true);
            }
            else
            {
                // Incorrect CAPTCHA, display an error message and regenerate the CAPTCHA
                captchaError.Text = "Invalid Captcha. Please Try Again.";
                setButtonState(false);
                btnGenerateCaptcha_Click(sender, e); // Regenerate the CAPTCHA
            }
        }

        private void setButtonState(bool state)
        {
            // Enable or disable login buttons based on the provided state
            btnEaterLogin.Enabled = state;
        }

        protected void btnEaterLogin_Click(object sender, EventArgs e)
        {
            // Attempt to authenticate the user as an eater
            AuthenticateUser("eater", txtUsername.Text, txtPassword.Text);
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // Redirect to the sign-up page (SignUp.aspx)
            Response.Redirect("SignUp.aspx");
        }

        private void AuthenticateUser(string userType, string username, string password)
        {
            Project5dll.Authentication authentication = new Project5dll.Authentication();
            string encryptedPassword = authentication.Encrypt(password);
            string filePath = userType == "eater"
                ? Server.MapPath("~/App_Data/EaterUsers.xml")
                : Server.MapPath("~/App_Data/DeliveryPartnerUsers.xml");

            if (File.Exists(filePath))
            {
                XDocument xmlDoc = XDocument.Load(filePath);
                var user = xmlDoc.Root.Elements("User")
                    .FirstOrDefault(x =>
                        x.Element("Username").Value.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                        x.Element("Password").Value == encryptedPassword);

                if (user != null)
                {
                    // TODO: Redirect to a service, set session and authentication cookie
                    signInError.Text = "Authenticated successfully";
                    Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] + 1;
                    Session["LoggedInUserName"] = username;
                    HttpCookie authCookie = new HttpCookie("AuthCookie");

                    authCookie[userType + "LoggedIn"] = "true";
                    authCookie.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(authCookie);
                    authCookie["LoggedInUserName"] = username;
                    if (userType == "eater")
                    {
                        Response.Redirect("EaterHome.aspx");
                    }
                    else
                    {
                        Response.Redirect("Deliver.aspx");
                    }
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
            /*int activeSessions = 0;
            if (Application["TotalUserSessions"] != null)
            {
                activeSessions = (int)Application["TotalUserSessions"];
            }
            lblActiveSessions.Text = $"Current Active Sessions: {activeSessions}";
            */
        }

        protected string GetUserNameFromCookie()
        {
            // Get the username from the authentication cookie, if present
            if (Request.Cookies["AuthCookie"] != null)
            {
                HttpCookie authCookie = Request.Cookies["AuthCookie"];
                if (authCookie["UserName"] != null)
                {
                    return authCookie["UserName"];
                }
            }
            return null;
        }
    }
}
