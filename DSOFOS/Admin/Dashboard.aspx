<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DSOFOS.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    
    <div class="page-body">
        <div class="row">
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-pie-chart bg-c-blue card1-icon"></i>
                        <a href="Category.aspx">
                            <span class="text-c-blue f-w-600">Category</span>
                        </a>
                        <%--<h4>49/50GB</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                               <a href="Category.aspx"> <i class="text-c-blue f-16 icofont icofont-warning m-r-10"></i>Get more Details</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-ui-home bg-c-pink card1-icon"></i>
                        
                            <a href="../UserMasters/Index"><span class="text-c-pink f-w-600">Customer</span></a>
                        
                       <%-- <h4>$23,589</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../UserMasters/Index"><i class="text-c-pink f-16 icofont icofont-warning m-r-10"></i>Get More Info</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-warning-alt bg-c-green card1-icon"></i>
                        <a href="../RestaurantsList/Index">
                            <span class="text-c-green f-w-600">Restaurants</span>
                        </a>
                        <%--<h4>45</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../RestaurantsList/Index"><i class="text-c-green f-16 icofont icofont-tag m-r-10"></i>Get Details </a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-social-twitter bg-c-yellow card1-icon"></i>
                        <a href="../States/Index">
                            <span class="text-c-yellow f-w-600">States</span>
                        </a>
                        <%--<h4>+562</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../States/Index"><i class="text-c-yellow f-16 icofont icofont-refresh m-r-10"></i>Just update</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-warning-alt bg-c-green card1-icon"></i>
                        <a href="../Cities/Index">
                            <span class="text-c-green f-w-600">Cities</span>
                        </a>
                        <%--<h4>45</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../Cities/Index"><i class="text-c-green f-16 icofont icofont-tag m-r-10"></i>More Cities </a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->

            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-pie-chart bg-c-blue card1-icon"></i>
                        <a href="../ReportDateWise/Index">
                            <span class="text-c-blue f-w-600">Selling Reports</span>
                        </a>
                       <%-- <h4>49/50GB</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                               <a href="../ReportDateWise/Index"> <i class="text-c-blue f-16 icofont icofont-warning m-r-10"></i>Get more Details</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-social-twitter bg-c-yellow card1-icon"></i>
                        <a href="../Feedbacks/Index">
                            <span class="text-c-yellow f-w-600">Feedbacks</span>
                        </a>
                        <%--<h4>+562</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../Feedbacks/Index"><i class="text-c-yellow f-16 icofont icofont-refresh m-r-10"></i>Get Details</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            
        </div>
    </div>

     

</asp:Content>
