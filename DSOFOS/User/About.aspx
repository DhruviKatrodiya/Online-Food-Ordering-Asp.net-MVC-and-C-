<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="DSOFOS.User.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- about section -->

  <section class="about_section layout_padding">
    <div class="container  ">

      <div class="row">
        <div class="col-md-6 ">
          <div class="img-box">
            <img src="../TemplateFiles/images/about-img.png" alt="">
          </div>
        </div>
        <div class="col-md-6">
          <div class="detail-box">
            <div class="heading_container">
              <h2>
                We Are DSOFOS
              </h2>
            </div>
            <p>
              What's an online ordering system? Online ordering systems allow restaurants and food businesses to serve their customers through a mobile app or a website. 
                Businesses can accept orders, offer discounts, accept payments, manage menu items, and take care of a whole bunch of other operations using these interfaces.
                Online ordering platforms should include both a browser-based system so customers can order from their homes or offices, and an app that lets them buy on the move.
                This gives customers complete ordering flexibility.
            </p>
            <a href="">
              Read More
            </a>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end about section -->


</asp:Content>
