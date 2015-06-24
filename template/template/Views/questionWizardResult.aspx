<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="questionWizardResult.aspx.cs" Inherits="template.Views.questionWizardResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container" style="direction:rtl">
        <!-- Introduction Row -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Result Page
                    <small>Your Answers</small>
                </h1>
                <div class="container">
                    <% for(int i = 0 ; i< int.Parse( Request.Form["no_questions"].ToString());i++){ %>
                        <div class="form-group col-xs-12 col-md-12" style="margin-bottom: 20px;" >
                            <label class="col-md-8 col-xs-12"><%= Request.Form["question"+(i+1)].ToString() %></label>
                            <label class="col-md-4 col-xs-12" ><%= Request.Form["optradio"+(i+1)].ToString()  %></label>
                        </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
