<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchRestaurant.aspx.cs" Inherits="TryIt.SearchRestaurant" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID ="MainContent" runat ="Server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <h2>Find Restaurants</h2>
    <p> Enter your address to find the restaurants around you</p>
    <asp:TextBox ID="TextBox1" runat="server" Width="300" Placeholder="Enter address or zipcode" AutoPostBack="false"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    <br />
    <asp:Literal ID="litResult" runat="server"></asp:Literal>
    <asp:Repeater ID="RepeaterRestaurants" runat="server">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLinkRestaurant" runat="server" 
            NavigateUrl='<%# "OrderNow.aspx?id=" + (Container.ItemIndex + 1) + "&name=" + Server.UrlEncode(DataBinder.Eval(Container.DataItem, "Name").ToString()) + "&address=" + Server.UrlEncode(DataBinder.Eval(Container.DataItem, "Address").ToString()) %>' 
            Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'>
        </asp:HyperLink>
        <br />
    </ItemTemplate>
    </asp:Repeater>


</asp:Content>