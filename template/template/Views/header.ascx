<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="template.Views.header1" %>
<nav class="navbar navbar-default" style="margin-bottom:0px;border-radius:0px;" >
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header navbar-right" style="margin:0px 10px 10px 10px">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand " href="../Views/homePage.aspx">Hunting</a>
    </div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav navbar-right" style="font-size: 25px;">
        <% if (Session["logged_applicant"] != null)
           { 
               if(((template.DBModel.Applicant)Session["logged_applicant"]).userActivation==1)
               {          %>
           <li><a href="../Views/questionsWizard.aspx">الامتحان</a></li>
                <%}
          } %>
        <li><a href="../Views/aboutUs.aspx">عن الموقع</a></li>
        <% if (Session["logged_applicant"] == null)
           { %>
            <li><a href="../Login.aspx">تسجيل الدخول</a></li>
        <%} %>
      </ul>
        <ul class="nav navbar-nav navbar-right" style="font-size: 25px;">
           <%  if (Session["logged_applicant"] != null)
            {
                template.DBModel.Applicant app=(template.DBModel.Applicant)Session["logged_applicant"];%>
                <li><a href="#"><%=(new template.DBService.RegistrationRequestService()).getRequestByApplicant(app.applicantID).referenceNo.ToString();%> : الرقم الطلب الخاص بك هو</a></li>

            <% }%>
        </ul>
      <ul class="nav navbar-nav navbar-left" style="font-size: 25px;">
          <% if(Session["logged_applicant"] != null){ %>
          <% template.DBModel.Applicant client = (template.DBModel.Applicant)Session["logged_applicant"]; %>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"> <%= client.firstname +" "+client.lastname  %> <span class="caret"></span></a>
          <ul class="dropdown-menu" role="menu">
<%--            <li><a href="#">Action</a></li>
            <li><a href="#">Another action</a></li>
            <li><a href="#">Something else here</a></li>--%>
            <li class="divider"></li>
            <li><a href="../Views/LogoutClient.aspx">تسجيل الخروج</a></li>
          </ul>
        </li>
          <% } %>
      </ul>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
