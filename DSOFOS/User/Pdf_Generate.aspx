<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pdf_Generate.aspx.cs" Inherits="DSOFOS.Views.Pdf_Generate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Download Invoice" Font-Bold="True" Font-Size="Medium" Height="57px" Width="343px" OnClick="Button1_Click1" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="X-Large" NavigateUrl="~/User/Default.aspx">Go To Home Page</asp:HyperLink>
            <asp:Panel ID="Panel1" runat="server">
                <table border="1">
                    <tr>
                        <td style="text-align:center">
                            <h2 style="text-align:center">Food Invoice</h2>

                        </td>
                    </tr>
                    <tr>
                        <td>Order No:
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <br/><br/>
                            Order Date:
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>Buyer Address:<br/>
                                         <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>Seller Address:<br/><br/>
                                         344,DSOFOS,SURAT...
                                    </td>
                                </tr>
                               
                                    
                              
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1000px">
                                <Columns>
                                    <asp:BoundField DataField="sno" HeaderText="SNo">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="itemid" HeaderText="ItemId">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="itemname" HeaderText="Item Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="quantity" HeaderText="Quantity">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="amount" HeaderText="Amount">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Bill" HeaderText="Total Amount">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grand Total:
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="center"> This is  a Computer Generated Invoice And Does Not Required Signature.</td>
                    </tr>




                </table>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
