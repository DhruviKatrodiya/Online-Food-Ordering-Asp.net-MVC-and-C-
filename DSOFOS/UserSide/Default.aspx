<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DSOFOS.UserSide.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="width:1150px;height:30px">
    <tr style="background-color:#5f98f3">
        
        <%-- Login & Logout Button --%>
        <td colspan="2" style="text-align:right">
            <asp:Label ID="Label4" runat="server" style="text-align:left" Font-Bold="true" Font-Italic="true" Font-Names="Bahnschrift SemiBold" ></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" Font-Names="Arial Rounded MT Bold" NavigateUrl="~/UserSide/Login.aspx" >Click To Login</asp:HyperLink>
            <asp:Button ID="Button1" runat="server" Text="Log Out" BackColor="#FF5050" BorderColor="White" Font-Bold="true" Font-Names="Comic Sans MS" ForeColor="Aqua"
                Height="27px" Width="105px" OnClick="Button1_Click" />
        </td>

        <%-- Menu Category DropDownList & TextBox for Searching Menu by name as well as by category of Menu --%>
        <td style="text-align:right">
            <asp:DropDownList ID="MenuCategories" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MenuCategories_SelectedIndexChanged" 
                 BackColor="#5F98F3" Font-Bold="true" Font-Size="Medium" ForeColor="White" ></asp:DropDownList>&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="174px" ></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/Images/SearchingIcon.jpg" Width="25px" OnClick="ImageButton2_Click" />
        </td>

    </tr>
</table>

<%-- Displaying Products Starts Here --%>

    <asp:DataList ID="DataList1" runat="server" DataKeyField="MenuItemId" DataSourceID="SqlDataSource1" 
        Height="293px" Width="310px" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" >

        <ItemTemplate>
            <table>
                
                <%-- Menu Name --%>
                <tr>
                    <td style="text-align:center;background-color:#5f98f3">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MenuItemName") %>' Font-Bold="true" Font-Names="Open Sans Extrabold" ForeColor="White"></asp:Label>
                    </td>
                </tr>

                <%-- Menu Image & Stock Of Menu --%>
                <tr>
                    <td style="text-align:center">
                        <asp:Image CssClass="All" ID="Image1" runat="server" BorderColor="#5F98F3" BorderWidth="1px"
                            Height="279px" Width="278px" ImageUrl='<%# Eval("MenuItemImage") %>' />
                        <div class="all">
                            &nbsp;Stock:&nbsp;
                            <asp:Label CssClass="txtStock" ID="Label5" runat="server" Text='<%# Eval("Quantity") %>' 
                                BackColor='<%# (int)Eval("Quantity") <= 10 ? System.Drawing.Color.Red : System.Drawing.Color.Green %>'>
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("MenuItemId") %>' Visible="false"></asp:Label>
                    </td>
                </tr>

                <%-- Menu Price --%>
                <tr>
                    <td style="text-align:center;background-color:#5f98f3">
                        <asp:Label ID="Label2" runat="server" Text="Price: ₹" Font-Bold="true" Font-Names="Arial"
                            ForeColor="White" Style="text-align:center"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Amount") %>' Font-Bold="true"
                            Font-Names="Arial" ForeColor="White" Style="text-align:center"></asp:Label>
                    </td>
                </tr>

                <%-- Menu Quantity to Buy --%>
                <tr>
                    <td align="center">
                        Quantity
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <%-- Button To add Menu into Cart --%>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/Images/AddCart.jpg" Width="160px" 
                            CommandArgument='<%# Eval("MenuItemId") %>' CommandName="AddToCart" />
                    </td>
                </tr>

            </table>
            <br />
            <br />
        </ItemTemplate>

    </asp:DataList>

<%-- Displaying Products Ends Here --%>

<%-- Data to Display Menu --%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DSOFOSDBConnectionString2%>"
        SelectCommand="SELECT [MenuItemId], [MenuItemName], [MenuItemImage], [Amount], [Quantity] FROM [MenuItem]">

    </asp:SqlDataSource>

</asp:Content>
