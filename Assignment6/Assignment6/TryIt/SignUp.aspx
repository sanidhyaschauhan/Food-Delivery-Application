<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SignUp.aspx.cs" Inherits="TryIt.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        Username:<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        Email:<br />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox><br />
        Address:<br />
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSignUpEater" runat="server" Text="Sign Up as Eater" OnClick="btnSignUpEater_Click" />
        <asp:Button ID="btnSignUpDeliveryPartner" runat="server" Text="Sign Up as Delivery Partner" OnClick="btnSignUpDeliveryPartner_Click" />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
