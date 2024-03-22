<%@ Page Title="CSE 445" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deliver.aspx.cs" Inherits="TryIt.Deliver" validateRequest="false" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <h1>Delivery Service</h1>
    <asp:Label ID="Restaurant_Address" runat="server" Text="Restaurant Address :"></asp:Label>
    <br />
    <asp:TextBox ID="txtRestaurantAddress" runat="server"></asp:TextBox>
    <br /> <br />
    <asp:Label ID="User_Address" runat="server" Text="User Address :"></asp:Label>
    <br />
    <asp:TextBox ID="txtUserAddress" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetDeliveryDetails" runat="server" Text="Get Delivery Details" OnClick="btnGetDeliveryDetails_Click" />
    <br /> <br />
    <asp:Literal ID="ltlDeliveryDetails" runat="server"></asp:Literal>
    <hr />
    <asp:Label ID="lblDeliverydetails" runat="server" Text=""></asp:Label>
    <br /> <br />
</asp:Content>
