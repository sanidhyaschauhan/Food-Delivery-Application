<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="TryIt.StaffLogin" MasterPageFile="~/Site.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Member Login</title>
    <script type="text/javascript">
        function setButtonState(isEnabled) {
            document.getElementById('<%= btnStaffLogin.ClientID %>').disabled = !isEnabled;
        }
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h5>
        You can login into the Staff page, only using the TA credentials given. Once you log in, you have the option to Add Credentials. Through this, you may add another user who can login the Staff Page after you Log Out. 
        These new credentials get stored in an XML file called “StaffUsers.xml”.
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
        Username:<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <br />
        <asp:Button ID="btnStaffLogin" runat="server" Text="Staff Login" OnClick="btnStaffLogin_Click" Enabled="false" />
        <br />
        <br />
        <asp:Label ID="signInError" runat="server" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblActiveSessions" runat="server"></asp:Label>
    </div>
</asp:Content>
