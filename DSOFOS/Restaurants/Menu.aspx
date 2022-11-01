<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurants/Restaurants.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="DSOFOS.Restaurants.Menu" %>
<%@ Import Namespace="DSOFOS" %>
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
                    $('#<%=imgMenu.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--<div class="pcoded-inner-content pt-0">
        <div class="align-align-self-end">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

        </div>
        <div class="main-body">
            <div class="page-wrapper">

                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 ">
                            <div class="card">
                                <div class="card-header">
                                </div>
                                <div class="card-block">
                                    <div class="row">

                                        <div class ="col-sm-6 col-md-4 col-lg-4">
                                            <h4 class="sub-title">Menu</h4>
                                            <div>
                                                <div class="form-group">
                                                    <label>MenuItem Name</label>
                                                    <div>
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="from-control"
                                                            placeholder="Enter the MenuItem name" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtName" ></asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hdnId" runat="server" Value="0"/>
                                                    </div>

                                                 </div>
                                                   <div class="form-group">
                                                    <label>MenuItem Description</label>
                                                    <div>
                                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="from-control"
                                                            placeholder="Enter the  MenuItem Description" TextMode="MultiLine" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtDescription" ></asp:RequiredFieldValidator>
                                                      
                                                    </div>

                                                 </div>
                                                 <div class="form-group">
                                                    <label>MenuItem Price(₹)</label>
                                                    <div>
                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="from-control"
                                                            placeholder="Enter the  Price" TextMode="MultiLine" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Price is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtPrice" ></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Price Must Be In Decimal" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtPrice" ValidationExpression="^\d{0,8}(\.\d{1,4})?$"></asp:RegularExpressionValidator>

                                                      
                                                    </div>

                                                 </div>
                                                  <div class="form-group">
                                                    <label>MenuItem Quantity</label>
                                                    <div>
                                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="from-control"
                                                            placeholder="Enter the Quantity" TextMode="MultiLine" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Price is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtQuantity" ></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Quanitiy Must Be Non Negative" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtQuantity" ValidationExpression="^([1-9]\d*|0)$"></asp:RegularExpressionValidator>

                                                      
                                                    </div>

                                                 </div>
                                                <div> 
                                                <div class="form-group">
                                                    <label>Menu Image</label>
                                                    <div>
                                                        <asp:FileUpload ID="fuMenuImage" runat="server" CssClass="from-control"
                                                           onchange="ImagePreview(this);"/>
                                                    
                                                    </div>
                                                 </div>
                                                   <div class="form-group">
                                                    <label>MenuItem Category</label>
                                                    <div>
                                                        
                                                        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="CategoryName"
                                                            DataValueField="CategoryId" AppendDataBoundItems="True"></asp:DropDownList>
                                                        <asp:ListItem Value="0">Select Category</asp:ListItem>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Category is requied..." ForeColor="Red" 
                                                            Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="ddlCategories" InitialValue="0" ></asp:RequiredFieldValidator>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DSOFOSDBConnectionString %>" 
                                                            SelectCommand="SELECT [CategoryId], [CategoryName] FROM [Category]" ></asp:SqlDataSource>
                                                      
                                                    </div>

                                                 </div>
                                                   <div class="form-check pl-4">
                                                        <asp:CheckBox ID="cbIsActive" runat="server" Text="&nbsp; IsActive"  CssClass="from-check-input" />
                                                            
                                    
                                                    </div>

                                                     <div class="pb-5">
                                                        <asp:Button ID="btnAddOrUpdate" runat="server" Text="Add"  CssClass="btn btn-primary" OnClick="btnAddOrUpdate_Click" />
                                                         
                                                         &nbsp;
                                                         <asp:Button ID="btnClear" runat="server" Text="Clear"  CssClass="btn btn-primary"
                                                             CausesValidation="false" OnClick="btnClear_Click" />
                                                      
                                                    </div>
                                                    </div> 
                                                </div>
                                                   
                                                <div>
                                                    <asp:Image ID="imgMenu" runat="server"  CssClass="image-thumbnail" />
                                                </div>          

                                    </div>
                                </div>

                                        <div class ="col-sm-6 col-md-8 col-lg-8 mobile-inputs">
                                            <h4 class="sub-title">Menu Lists</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rMenu" runat="server" OnItemCommand="rMenu_ItemCommand" OnItemDataBound="rMenu_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                <tr>
                                                                    <th class="table-plus">Category Name</th>
                                                                    <th>Image</th>
                                                                    <th>IsActive</th>
                                                                    <th>CreatedAt</th>
                                                                    <th class="datatable-nosort">Action</th>
                                                                </tr>
                                                                </thead>
                                                            <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                            <td class="table-plus"><%# Eval("CategoryName") %></td>
                                                            <td>
                                                                <img alt="" width="40" src="<%# Utils.GetImageUrl(Eval("MenuItemImage"))%>" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                            </td>
                                                            <td><%# Eval("CreatedAt") %></td>
                                                            <td>

                                                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CssClass="badge badge-primary" 
                                                                    CommandArgument='<%# Eval("CategoryId") %>' CommandName="edit">
                                                                    <i class="ti-pencil"></i></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="delete" CssClass="badge bg-danger"
                                                                    CommandArgument='<%# Eval("CategoryId") %>' OnClientClick="return confirm('Do you want to delete this category ??');">
                                                                    <i class="ti-trash"></i></asp:LinkButton>

                                                            </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>


    <div class="pcoded-inner-content pt-0">
        <div class="align-align-self-end">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

        </div>
        <div class="main-body">
            <div class="page-wrapper">

                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 ">
                            <div class="card">
                                <div class="card-header">
                                </div>
                                <div class="card-block">
                                    <div class="row">

                                        <div class ="col-sm-6 col-md-4 col-lg-4">
                                            <h4 class="sub-title">Menu</h4>
                                            <div>
                                                <div class="form-group">
                                                    <label>MenuItem Name</label>
                                                    <div>
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="from-control"
                                                            placeholder="Enter the MenuItem name" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtName" ></asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hdnId" runat="server" Value="0"/>
                                                    </div>

                                                 </div>

                                                <div class="form-group">
                                                    <label>MenuItem Description</label>
                                                    <div>
                                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="from-control"
                                                            placeholder="Enter the  MenuItem Description" TextMode="MultiLine" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtDescription" ></asp:RequiredFieldValidator>
                                                      
                                                    </div>

                                                 </div>

                                                <div class="form-group">
                                                    <label>MenuItem Price(₹)</label>
                                                    <div>
                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="from-control"
                                                            placeholder="Enter the  Price" TextMode="MultiLine" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Price is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtPrice" ></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Price Must Be In Decimal" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtPrice" ValidationExpression="^\d{0,8}(\.\d{1,4})?$"></asp:RegularExpressionValidator>

                                                      
                                                    </div>

                                                 </div>

                                                <div class="form-group">
                                                    <label>MenuItem Quantity</label>
                                                    <div>
                                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="from-control"
                                                            placeholder="Enter the Quantity" TextMode="MultiLine" >
                                                            </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Price is requied..." ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtQuantity" ></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Quanitiy Must Be Non Negative" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="txtQuantity" ValidationExpression="^([1-9]\d*|0)$"></asp:RegularExpressionValidator>

                                                      
                                                    </div>

                                                 </div>

                                                <div>
                                                <div class="form-group">
                                                    <label>MenuItem Image</label>
                                                    <div>
                                                        <asp:FileUpload ID="fuMenuImage" runat="server" CssClass="from-control"
                                                           onchange="ImagePreview(this);"/>
                                                            
                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="0"/>
                                                    </div>
                                                 </div>

                                                    <div class="form-group">
                                                    <label>MenuItem Category</label>
                                                    <div>
                                                        
                                                        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="CategoryName"
                                                            DataValueField="CategoryId" AppendDataBoundItems="True">
                                                            <asp:ListItem Value="0">Select Category</asp:ListItem>
                                                        </asp:DropDownList>
                                                        

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Category is requied..." ForeColor="Red" 
                                                            Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="ddlCategories" InitialValue="0" ></asp:RequiredFieldValidator>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DSOFOSDBConnectionString %>" 
                                                            SelectCommand="SELECT [CategoryId], [CategoryName] FROM [Category]" ></asp:SqlDataSource>
                                                      
                                                    </div>

                                                 </div>

                                                    <div class="form-check pl-4">
                                                        <asp:CheckBox ID="cbIsActive" runat="server" Text="&nbsp; IsActive"  CssClass="from-check-input" />
                                                            
                                                        <asp:HiddenField ID="HiddenField2" runat="server" Value="0"/>
                                                    </div>

                                                    <div class="form-check pl-4">
                                                        <asp:CheckBox ID="cbVegNonProfile" runat="server" Text="&nbsp; VegNonProfiles"  CssClass="from-check-input" />
                                                            
                                                        <asp:HiddenField ID="HiddenField3" runat="server" Value="0"/>
                                                    </div>

                                                     <div class="pb-5">
                                                        <asp:Button ID="btnAddOrUpdate" runat="server" Text="Add"  CssClass="btn btn-primary" 
                                                            OnClick="btnAddOrUpdate_Click"/>
                                                         &nbsp;
                                                         <asp:Button ID="btnClear" runat="server" Text="Clear"  CssClass="btn btn-primary"
                                                             CausesValidation="false" OnClick="btnClear_Click"/>
                                                      
                                                    </div>
                                                    </div>
    +                                            <div>
                                                    <asp:Image ID="imgMenu" runat="server"  CssClass="image-thumbnail" />
                                                </div>



                                    </div>
                                </div>

                                        <div class ="col-sm-6 col-md-8 col-lg-8 mobile-inputs">
                                            <h4 class="sub-title">Menu Lists</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rMenu" runat="server" OnItemCommand="rMenu_ItemCommand" OnItemDataBound="rMenu_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                <tr>
                                                                    <th class="table-plus">MenuItem Name</th>
                                                                    <th>MenuItem Image</th>
                                                                    <th>Price(₹)</th>
                                                                    <th>Qty</th>
                                                                    <th>Category</th>
                                                                    <th>IsActive</th>
                                                                    <th>Veg-NonVeg</th>
                                                                    <th>MenuItem Description</th>
                                                                    <th>CreatedAt</th>
                                                                    <th class="datatable-nosort">Action</th>
                                                                </tr>
                                                                </thead>
                                                            <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                            <td class="table-plus"><%# Eval("MenuItemName") %></td>

                                                            <td>
                                                                <img alt="" width="40" src="<%# Utils.GetImageUrl(Eval("MenuItemImage"))%>" />
                                                            </td>

                                                            <td><%# Eval("Amount") %></td>
                                                            
                                                            <td>
                                                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                            </td>
                                                            
                                                            <td><%# Eval("CategoryName") %></td>

                                                            <td>
                                                                <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="lblVegNonProfile" runat="server" Text='<%# Eval("VegNonProfile") %>'></asp:Label>
                                                            </td>

                                                            <td><%# Eval("MenuItemDescription") %></td>
                                                            
                                                            <td><%# Eval("CreatedAt") %></td>
                                                            
                                                            <td>

                                                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CssClass="badge badge-primary" 
                                                                    CommandArgument='<%# Eval("MenuItemId") %>' CommandName="edit" CausesValidation="false">
                                                                    <i class="ti-pencil"></i></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="delete" CssClass="badge bg-danger"
                                                                    CommandArgument='<%# Eval("MenuItemId") %>' OnClientClick="return confirm('Do you want to delete this MenuItem ??');" CausesValidation="false">
                                                                    <i class="ti-trash"></i></asp:LinkButton>

                                                            </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            </div>
</div>



</asp:Content>
