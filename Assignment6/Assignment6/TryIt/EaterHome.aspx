<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EaterHome.aspx.cs" Inherits="TryIt.EaterHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <asp:Label ID="labelWelcomeName" runat="server" />
    <hr />
    <div style="text-align: center;">
        <br />
        <br />
        <asp:Button ID="btnSearchRestaurant" runat="server" Text="Search Restaurant" OnClick="btnSearchRestaurant_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnTrackOrder" runat="server" Text="Track Order" OnClick="btnTrackOrder_Click" />
        <br />
    </div>
</asp:Content>

