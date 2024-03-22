<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddCredentials.aspx.cs" Inherits="TryIt.AddCredentials" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <div>
        Username:<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <br />
        <asp:Button ID="btnRegisterUser" runat="server" Text="Add credentials of a user" OnClick="btnRegisterUser_Click" />
    </div>
</asp:Content>

