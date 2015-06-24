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
                    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
                        <p><asp:Label id="successMsg" runat="server" Text="" /></p>
                    </div>
                    <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
                        <p><asp:Label id="errMsg" runat="server" Text="" /></p>
                    </div>
                    <div class="table-responsive">
                        <asp:Table ID="Table1" runat="server" BorderColor="#DADDE1" CellPadding="5" CellSpacing="5" CssClass="table table-bordered table-striped">
                            <asp:TableHeaderRow ID="TableHeaderRow1" runat="server">
                                <asp:TableCell ID="TableCell1" runat="server"><b>Question</b></asp:TableCell>
                                <asp:TableCell ID="TableCell2" runat="server"><b>Your Answer</b></asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col-lg-12 -->
    </div>
                    <div class="form-group col-xs-12 col-md-12" >
                        <label class="col-xs-6 col-md-6" >
                            Correct answers are : <%= no_correct_answer %>
                        </label>
                        <label class="col-xs-6 col-md-6" >
                            Wrong answers are : <%= no_worong_answer %>
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
