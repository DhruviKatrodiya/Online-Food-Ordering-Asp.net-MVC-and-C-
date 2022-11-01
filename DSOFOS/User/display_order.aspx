<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="display_order.aspx.cs" Inherits="DSOFOS.User.display_order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Repeater Id="r1" runat="server">
        <HeaderTemplate>
                <table border="1">
                    <tr style ="background-color:gray; color:white">
                        <td>UserId</td>
                         <td>UserName</td>
                         <td>FirstName</td>
                         <td>LastName</td>
                         <td>EmailId</td>
                         <td>ContactNo</td>
                         <td>Address</td>
                         
                    </tr>
                     </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                           <td> <%#Eval("UserId") %></td>
                             <td> <%#Eval("UserName") %></td>
                             <td> <%#Eval("FirstName") %></td>
                             <td> <%#Eval("LastName") %></td>
                             <td> <%#Eval("EmailId") %></td>
                             <td> <%#Eval("ContactNo") %></td>
                             <td> <%#Eval("Address") %></td>
                            <td><a href ="view_full_order.aspx?id=<%#Eval ("UserId") %>">view full order</td>
                        </tr>
                </ItemTemplate>
        <FooterTemplate>
                </table>
            </FooterTemplate>

       
        </asp:Repeater>

</asp:Content>
