<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurants/Restaurants.Master" AutoEventWireup="true" CodeBehind="R_Dashboard.aspx.cs" Inherits="DSOFOS.Restaurants.R_Dashboard" %>
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
                        <a href="CategoryList.aspx">
                            <span class="text-c-blue f-w-600">Category List</span>
                        </a>
                       <%-- <h4>49/50GB</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                               <a href="CategoryList.aspx"> <i class="text-c-blue f-16 icofont icofont-warning m-r-10"></i>Get more Details</a>
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
                        
                            <a href="../UserMastersRest/Index"><span class="text-c-pink f-w-600">Customer</span></a>
                        
                        <%--<h4>$23,589</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../UserMastersRest/Index"><i class="text-c-pink f-16 icofont icofont-warning m-r-10"></i>Get More Info</a>
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
                        <a href="Menu.aspx">
                            <span class="text-c-green f-w-600">Menus</span>
                        </a>
                        <%--<h4>45</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="Menu.aspx"><i class="text-c-green f-16 icofont icofont-tag m-r-10"></i>Get Details </a>
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
                        <a href="../tbl_order/Index">
                            <span class="text-c-yellow f-w-600">Order Lists</span>
                        </a>
                       <%-- <h4>+562</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../tbl_order/Index"><i class="text-c-yellow f-16 icofont icofont-refresh m-r-10"></i>Just update</a>
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
                        <a href="../Payments/Index">
                            <span class="text-c-green f-w-600">Payment Lists</span>
                        </a>
                        <%--<h4>45</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../Payments/Index"><i class="text-c-green f-16 icofont icofont-tag m-r-10"></i>More Details </a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->

            <!-- card1 start -->
            <%--<div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-social-twitter bg-c-yellow card1-icon"></i>
                        <a href="../Feedbacks/Index">
                            <span class="text-c-yellow f-w-600">Feedbacks</span>
                        </a>
                        <h4>+562</h4><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../Feedbacks/Index"><i class="text-c-yellow f-16 icofont icofont-refresh m-r-10"></i>Get Details</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- card1 end -->
            
            <!-- card1 start -->
            <div class="col-md-6 col-xl-3">
                <div class="card widget-card-1">
                    <div class="card-block-small">
                        <i class="icofont icofont-pie-chart bg-c-blue card1-icon"></i>
                        <a href="../ReportDateWiseRestaurant/Index">
                            <span class="text-c-blue f-w-600">Selling Reports</span>
                        </a>
                       <%-- <h4>49/50GB</h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                               <a href="../ReportDateWiseRestaurant/Index"> <i class="text-c-blue f-16 icofont icofont-warning m-r-10"></i>Get more Details</a>
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
                        
                            <a href="../Reviews/Index"><span class="text-c-pink f-w-600">Reviews</span></a>
                        
                       <%-- <h4></h4>--%><br /><br /><br />
                        <div>
                            <span class="f-left m-t-10 text-muted">
                                <a href="../Reviews/Index"><i class="text-c-pink f-16 icofont icofont-warning m-r-10"></i>Get More Info</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <!-- card1 end -->
            
        </div>
    </div>

</asp:Content>
