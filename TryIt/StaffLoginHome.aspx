<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLoginHome.aspx.cs" Inherits="TryIt.StaffLoginHome" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <div>
        <asp:Label ID="labelWelcomeName" runat="server" />
        <asp:Table ID="OrdersTable" runat="server" CssClass="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Order ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Customer Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Restaurant Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Customer Address</asp:TableHeaderCell>
            <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="AddCredentials" runat="server" Text="Add credentials of a user" OnClick="btnAddCredentials_Click" />
    </div>
</asp:Content>


