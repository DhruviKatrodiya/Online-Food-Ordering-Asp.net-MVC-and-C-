<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DSOFOS.UserSide.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height:450px">
            <table style="width:565px;height:421px;background-color:#5f98f3;margin:0 auto">

                <%-- Displays Login Logo Image --%>
                <tr>
                    <td colspan="2" align="center">
                        <img id="Img1" src="../Images/login1.jpg" alt="" runat="server" style="height:190px;width:199px" />
                    </td>
                </tr>

                <%-- Email Id with required field validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Email Id :</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" BackColor="Transparent" Height="29px" Width="166px" Font-Bold="true"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Enter Email Id" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Password with required field validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Password :</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" BackColor="Transparent" Height="29px" Width="166px" TextMode="Password" Font-Bold="true"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Button for Login & Redirect to Default page --%>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="46px" ImageUrl="~/Images/LoginButton.png"
                            Width="201px" OnClick="ImageButton1_Click" /><hr />
                    </td>
                </tr>

                <tr>

                    <%-- Label for displaying error message --%>
                    <td>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </td>

                    <%-- Link Button for redirecting to register page --%>
                    <td align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="true" ForeColor="Red"
                            OnClick="LinkButton1_Click" CausesValidation="false">Register Here...</asp:LinkButton>
                    </td>

                </tr>

            </table>
        </div>
    </form>
</body>
</html>
