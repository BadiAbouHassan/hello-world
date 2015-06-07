<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="template.Views.homePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap-3.3.2-dist-sandstone/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery-latest.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/bootstrap.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery.bootstrap.wizard.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="myCarousel" class="carousel slide" data-ride="carousel" style="margin-top:0px">
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
      </ol>

      <!-- Wrapper for slides -->
      <div class="carousel-inner" role="listbox">
        <div class="item active">
          <img src="../Images/image1.jpg" alt="Chania">
        </div>

        <div class="item">
          <img src="../Images/image2.jpg" alt="Chania">
        </div>

    
      </div>

      <!-- Left and right controls -->
      <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div>
</asp:Content>
