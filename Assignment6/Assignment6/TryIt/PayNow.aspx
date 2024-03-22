<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayNow.aspx.cs" Inherits="TryIt.PayNow" validateRequest="false" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <asp:Label ID="Label7" runat="server" BackColor="#FFCCCC" BorderStyle="Solid" Height="60px" Text="Payment. Provide your credit card number, expiry date and CVV. This service validates your card and if it is, then your transaction is successful. Output Type : String" Width="1031px"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="CardNumber (Provide a real card number, expiry and cvv can be fake)"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox8" runat="server" Height="46px" Width="505px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Text="Expiry (Format : MM/YYYY)"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox9" runat="server" Height="46px" Width="304px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label10" runat="server" Text="CVV or Security Code (3 digit)"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox10" runat="server" Height="42px" Width="190px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Submit" />
    <br />
    <br />
    <br />
    <asp:Label ID="Label11" runat="server" Text=""></asp:Label>

    <asp:Label ID="lblDeliverydetails" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <br />
    <br />
</asp:Content>
