<%@ Page Title="Order Now" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderNow.aspx.cs" Inherits="TryIt.OrderNow" validateRequest="false" Async="true" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server"> 
    <style type="text/css"> 
        .menuGrid {
            border-collapse: collapse; 
            width: 100%; 
        } 
        .menuGrid th, .menuGrid td { 
            border: 1px solid #ddd; 
            padding: 8px; 
            text-align: left; 
        } 
        .menuGrid th { 
            background-color: #f2f2f2; 
        } 
    </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" style="position: fixed; top: 10px; right: 10px; z-index: 1000;" />
    <h1><asp:Label ID="lblName" runat="server" />: Order Here</h1>
    <h6>This is an elective WSDL service. It is responsible for handling the orders. User can click on View Menu to see menu items. From the menu, user can choose the item and add it to cart by adding the item name, price and quantity and click on add to cart button. User can click on View Cart button to see the content of the cart and click on Get Total Amount to get the total amount of the order. I have also implemented a coupon service which takes a coupon and give discount on the total amount.
        For testing purpose you can use code "asu" to get 10% discount. At last an email will be sent by clicking on Place Order to the restaurant with order details by the smtp server. I am reading Menu items from a txt file and I am also maintaining the cart using a txt file. All the files are stored in page6 of our server.</h6>
    <h6>URL of the Serivce: http://webstrar43.fulton.asu.edu/Page8/WsdlServices.svc</h6>
    <h6>Operation Name: AddToCart</h6>
    <p>Input Parameter: itemName (string), price (double), quantity (int)</p>
    <p>Return Type: void</p>
    <h6>Operation Name: ViewCart</h6>
    <p>Input Parameter: None</p>
    <p>Return Type: List of CartItem object</p>
    <h6>Operation Name: GetTotalAmount</h6>
    <p>Input Parameter: None</p>
    <p>Return Type: totalAmount (double)</p>
    <h6>Operation Name: PlaceOrder</h6>
    <p>Input Parameter: emailAddress (string)</p>
    <p>Return Type: void</p>
    <br />
    <h5>Menu Items</h5> 
    <asp:Button ID="btnViewMenu" runat="server" Text="View Menu" OnClick="btnViewMenu_Click" /> 
    <br /> 
    <br /> 
    <asp:GridView ID="grdMenu" runat="server" AutoGenerateColumns="False" CssClass="menuGrid"> 
        <Columns> 
            <asp:BoundField DataField="Key" HeaderText="Item" /> 
            <asp:BoundField DataField="Value" HeaderText="Price" DataFormatString="{0:C}" /> 
        </Columns> 
    </asp:GridView> 
    <br />
    <h5>Add to Cart</h5>
    
    <asp:Label ID="lblItemName" runat="server" Text="Item Name:"></asp:Label>
    <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
    <br />
    
    <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <br />
    
    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    <br />
    
    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
    <br />
    <br />
    <asp:Button ID="btnViewCart" runat="server" Text="View Cart" OnClick="btnViewCart_Click" />
    <br />
    <br />
    <asp:GridView ID="CartGridView" runat="server" CssClass="menuGrid"></asp:GridView>
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="GetTotalAmountButton" runat="server" Text="Get Total Amount" OnClick="GetTotalAmountButton_Click" />
    <br />
    <asp:Label ID="TotalAmountLabel" runat="server" Text="" />
    <br />
    <p>Use coupon code "asu" to get 10% discount</p>
    <asp:TextBox ID="CouponCodeTextBox" runat="server" />
    <asp:Button ID="ApplyCouponButton" runat="server" Text="Apply Coupon" OnClick="ApplyCouponButton_Click" />
    <br />
    <asp:Label ID="CouponAmountLabel" runat="server" Text="" />
    <br />
    <br />
    <asp:Button ID="PlaceOrderButton" runat="server" Text="Pay Now" OnClick="PlaceOrderButton_Click" />
    <br />
    <asp:Literal ID="ResultLiteral1" runat="server" />
    <hr />
    <br /> <br />

</asp:Content>
