<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddtoCart.aspx.cs" Inherits="DSOFOS.UserSide.AddtoCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #Button1
        {
            border-radius:25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="margin:0 auto">
            <h2 style="text-decoration:underline overline blink;color:#5f98f3">You have following Menu in Your Cart</h2>
            <br />

            <%-- Redirect you to Default page --%>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" Font-Names="Colonna MT" Font-Size="X-Large"
                NavigateUrl="~/UserSide/Default.aspx">Countinue Shopping</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <%-- Clear All menu present in your cart --%>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Clear Cart</asp:LinkButton>
            <br /><br />

            <%-- Display menu present in your cart --%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="#FF6699" BorderColor="#333333"
                BorderWidth="5px" EmptyDataText="No MenuItem Available in DSOFOS" Font-Bold="true"
                Height="257px" ShowFooter="true" Width="1100px" OnRowDeleting="GridView1_RowDeleting">

                <Columns>
                    
                    <asp:BoundField DataField="sno" HeaderText="SrNo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mid" HeaderText="MenuItem Id">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mimage" HeaderText="Item Image">
                        <ControlStyle Height="300px" Width="340px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mname" HeaderText="MenuItem Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mdesc" HeaderText="Description">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mprice" HeaderText="Amount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mquantity" HeaderText="Quantity">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="mtotalprice" HeaderText="Total Amount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="true"/>

                </Columns>

                <FooterStyle BackColor="#6666FF" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="DarkOrchid" ForeColor="White" />

            </asp:GridView>

            <br />

            <%-- Button to place an Order which redirects you to Payment page --%>
            <asp:Button CssClass="btnPlaceOrder" ID="Button1" runat="server" Text="Place Order" BackColor="#FF6699" BorderColor="#0A2C2A"
                BorderStyle="Ridge" Font-Bold="true" Font-Size="Large" Height="46px" Width="135px" OnClick="Button1_Click"/>

        </div>
    </form>
</body>
</html>
