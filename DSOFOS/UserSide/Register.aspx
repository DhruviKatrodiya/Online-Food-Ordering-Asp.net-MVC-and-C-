<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DSOFOS.UserSide.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height:830px">
            <table style="width:700px;height:702px;background-color:#5f98f3" align="center">

                <%-- Register Logo Image --%>
                <tr>
                    <td colspan="2" align="center">
                        <img id="Img1" src="../Images/register.png" runat="server" alt="" style="height:210px;width:235px" />
                    </td>
                </tr>

                <%-- First name with required & regular expression validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>First Name :</b>
                    </td>
                    <td style="vertical-align:top">
                        <asp:TextBox ID="TextBox1" runat="server" BackColor="Transparent" Height="29px" Width="166px" Font-Bold="true"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" 
                            ErrorMessage="First Name is empty" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1" 
                            ErrorMessage="First name should be in Characters" ForeColor="Red" ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <%-- Last name with required & regular expression validation  --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Last Name :</b>
                    </td>
                    <td style="vertical-align:top">
                        <asp:TextBox ID="TextBox2" runat="server" BackColor="Transparent" Height="29px" Width="166px" Font-Bold="true" TabIndex="1"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" 
                            ErrorMessage="Last Name is empty" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox2" 
                            ErrorMessage="Last name should be in Characters" ForeColor="Red" ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <%-- EmailId with required field validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Email Id :</b>
                    </td>
                    <td style="vertical-align:top">
                        <asp:TextBox ID="TextBox3" runat="server" BackColor="Transparent" Height="29px" Width="166px" 
                            TextMode="Email" Font-Bold="true" TabIndex="2"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox3" 
                            ErrorMessage="Email Id is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Gender with Required field validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Gender :</b>
                    </td>
                    <td style="vertical-align: top">
                        <asp:DropDownList ID="DropDownList1" runat="server" BackColor="Transparent" Height="31px" Width="167px" 
                            Font-Bold="true" TabIndex="3">
                            <asp:ListItem Value="Select Gender">Select Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1" 
                            ErrorMessage="Select Gender" ForeColor="Red" InitialValue="Select Gender">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Address with required field validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Address :</b>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="TextBox5" runat="server" BackColor="Transparent" Height="32px" Width="166px" 
                            TextMode="MultiLine" Font-Bold="true" TabIndex="4"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" 
                            ErrorMessage="Address is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Phone No with required field & regular expression validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Mobile No :</b>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="TextBox6" runat="server" BackColor="Transparent" Height="29px" Width="166px" 
                            TextMode="Number" Font-Bold="true" TabIndex="5"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" 
                            ErrorMessage="Mobile Number is empty" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox6" 
                            ErrorMessage="Invalid Mobile Number" ForeColor="Red" ValidationExpression="[0-9]{10}">*</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <%-- Password with required field validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Password :</b>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="TextBox7" runat="server" BackColor="Transparent" Height="29px" Width="166px" 
                            TextMode="Password" Font-Bold="true" TabIndex="6"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" 
                            ErrorMessage="Password is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Confirm password with required field & compare validation --%>
                <tr>
                    <td align="center" style="width:50%">
                        <b>Confirm Password :</b>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="TextBox8" runat="server" BackColor="Transparent" Height="29px" Width="166px"
                            TextMode="Password" Font-Bold="true" TabIndex="7"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox8"
                            ErrorMessage="Confirm Password is empty" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox7" 
                            ControlToValidate="TextBox8" ErrorMessage="Password not Matched" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                </tr>

                <%-- Register Button --%>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="49px" 
                            ImageUrl="~/Images/Register-Button.png" Width="199px" OnClick="ImageButton1_Click" TabIndex="8"/><hr />
                    </td>
                </tr>

                <%-- Validation summary for displaying all validations error message --%>
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"
                            HeaderText="Fix the following errors" Font-Bold="true"/>
                    </td>
                </tr>

                <tr>
                    
                    <%-- label for displaying register error message --%>
                    <td>
                        <asp:Label ID="Label1" runat="server" ForeColor="#66FF66" Font-Bold="true"></asp:Label>
                    </td>

                    <%-- Redirects to default page if you are already registered --%>
                    <td align="right">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true"
                            Font-Italic="true" NavigateUrl="~/UserSide/Default.aspx">Already Registered. Click Here...</asp:HyperLink>
                    </td>

                </tr>

            </table>
        </div>
    </form>
</body>
</html>
