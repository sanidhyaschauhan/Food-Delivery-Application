<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="TryIt.MemberLogin" MasterPageFile="~/Site.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Member Login</title>
    <script type="text/javascript">
        function setButtonState(isEnabled) {
            document.getElementById('<%= btnEaterLogin.ClientID %>').disabled = !isEnabled;
        }
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h5>If you click the Member option: You have two options either to Log In or to Sign Up.
        There is an xml file that stores all the users and their encrypted passwords.
        If you sign up, your credentials will be added to that file and then you can login. You won’t be able to Login unless you Sign Up.
        In the Login page : the first thing you have to do is Generate Captcha. 
        When the Captcha is generated, unless you verify it, the options “Enter Login” and “Delivery Partner Login” remain disabled. 
        After it is verified, you can either click Enter Login to login as an eater or click Delivery Partner Login to login as a Delivery Partner. 
        Delivery Partner Login takes you to the Delivery Service 
        Enter Login takes you to another page which has 3 different buttons to take you to 3 services namely : Get Restaurants, Ordernow and Paynow.
    </h5>
    <br />
    <div>
        <asp:Button ID="btnGenerateCaptcha" runat="server" Text="Generate Captcha" OnClick="btnGenerateCaptcha_Click" /><br />
        <asp:Image ID="imgCaptcha" runat="server" /><br />
        Enter Captcha Text Here:<br />
        <asp:TextBox ID="txtCaptchaInput" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnVerifyCaptcha" runat="server" Text="Verify Captcha" OnClick="btnVerifyCaptcha_Click" />
        <br />
        <br />
        <asp:Label ID="captchaError" runat="server" />
        <br />
        Username:<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnEaterLogin" runat="server" Text="Eater Login" OnClick="btnEaterLogin_Click" Enabled="false" />
        <br />
        <br />
        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" Enabled="true" />
        <br />
        <asp:Label ID="signInError" runat="server" />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblActiveSessions" runat="server"></asp:Label>
    </div>
</asp:Content>
