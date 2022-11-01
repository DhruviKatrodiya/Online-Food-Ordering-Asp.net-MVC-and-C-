<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DSOFOS.User.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script>
        /*For disappearing alert message*/
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
        </script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgUser.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </div>
                <asp:Label ID="lblHeaderMsg" runat="server" Text="<h2>User Registration</h2>"></asp:Label>
            </div>
            <div class="row">

                <div class="col-md-6">
                    <div class="form_container">

                        <div>
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"
                                ToolTip="Username"></asp:TextBox>
                        </div>

                        <div>
                            
                            <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtFName"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revFName" runat="server" ErrorMessage="Name must be in a character only"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFName"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtFName" runat="server" CssClass="form-control" placeholder="Enter First Name"
                                ToolTip="FName"></asp:TextBox>
                        </div>

                        <div>
                            
                            <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="Last Name is required" ControlToValidate="txtLName"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revLName" runat="server" ErrorMessage="Last Name must be in a character only"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtLName"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtLName" runat="server" CssClass="form-control" placeholder="Enter Last Name"
                                ToolTip="LName"></asp:TextBox>
                        </div>

                        <div>
                            
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email is required" ControlToValidate="txtEmail"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Last Name must be in a character only"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtLName"></asp:RegularExpressionValidator>--%>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Id"
                                ToolTip="Email" TextMode="Email"></asp:TextBox>
                        </div>

                        
                        <div class="form-group">
                           <%-- <label>Select Role</label>--%>
                            <div>

                                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="RoleName"
                                    DataValueField="RoleId" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">Select Role</asp:ListItem>
                                </asp:DropDownList>


                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Role is requied..." ForeColor="Red"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ControlToValidate="ddlRoles" InitialValue="0"></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DSOFOSDBConnectionString %>"
                                    SelectCommand="SELECT [RoleId], [RoleName] FROM [Roles]"></asp:SqlDataSource>

                            </div>

                        </div>
                         
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form_container">

                        <div>
                           
                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage=" Mobile Number is required" ControlToValidate="txtMobile"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="mobile number  must have 10 Digits"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
                             <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"
                                ToolTip="LName" TextMode="Number"></asp:TextBox>
                        </div>

                        <div>
                            
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage=" Address  is required" ControlToValidate="txtAddress"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"
                                ToolTip="Address" TextMode="MultiLine" ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <%--<label>Select City</label>--%>
                            <div>

                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="CityName"
                                    DataValueField="CityId" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">Select City</asp:ListItem>
                                </asp:DropDownList>


                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="City is requied..." ForeColor="Red"
                                    Display="Dynamic" SetFocusOnError="true"
                                    ControlToValidate="ddlCity" InitialValue="0"></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DSOFOSDBConnectionString %>"
                                    SelectCommand="SELECT [CityId], [CityName] FROM [City]"></asp:SqlDataSource>

                            </div>

                        </div>

                        <div>
                            <asp:FileUpload ID="fuUserImage" runat ="server" CssClass="form-control" ToolTip="UserImage" onchange="ImagePreview(this);"/>   
                        </div>


                        <div>
                            
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password"
                                ToolTip="Password" TextMode="Password"></asp:TextBox>
                        </div>


                    </div>
                </div>

                <div class="row pl-4">
                    <div class="btn_box">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white " 
                            OnClick="btnRegister_Click"/>
                        
                        <asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100"
                            Text="Already registered? <a href='Login.aspx' class='badge badge-info'>Login Here...</a>" >
                        </asp:Label>
                    </div>
                </div>

                <div class="row p-5">
                      <div style="align-items:center">
                          <asp:Image ID="imgUser" runat="server" CssClass="img-thumbnail"/>
                       </div>
                </div>


            </div>
        </div>
    </section>













</asp:Content>
