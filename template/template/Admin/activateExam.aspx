<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="activateExam.aspx.cs" Inherits="template.Admin.activateExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-heading">
        Activate Exam
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-lg-6">
                <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
                    <p><asp:Label id="successMsg" runat="server" Text="" /></p>
                </div>
                <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
                    <p><asp:Label id="errMsg" runat="server" Text="" /></p>
                </div>
            </div>
        </div>
        <!-- /.row (nested) -->
    </div>
</asp:Content>
