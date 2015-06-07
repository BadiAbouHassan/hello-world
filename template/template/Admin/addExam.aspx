<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="addExam.aspx.cs" Inherits="template.Admin.addExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Exams</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add New Exam
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
                            <div class="form-group">
                                <label>Exam Name</label>
                                <input placeholder="Exam Name" class="form-control" id="examName" name="examName" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Exam Description</label>
                                <textarea class="form-control" rows="3" runat="server" required="required" id="examDescription" name="examDescription"></textarea>
                            </div>
                            <div class="form-group">
                                <label>Exam Duration</label>
                                <input placeholder="Exam Description" class="form-control" id="examDuration" name="examDuration" runat="server" required="required" />
                                <p class="help-block">Please set the Exam duration in minutes</p>
                            </div>
                            <div class="form-group">
                                <label>Passing Mark</label>
                                <input placeholder="Passing Mark" class="form-control" id="passingMark" name="passingMark" runat="server" required="required" />
                                <p class="help-block">The minimum marks the Applicant should get to pass the Exam</p>
                            </div>
                            <div class="form-group">
                                <label>Number of Questions per Exam</label>
                                <input placeholder="questions total number" class="form-control" id="numberOfQuestions" name="numberOfQuestions" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Question Mark</label>
                                <input placeholder="Question Mark" class="form-control" id="questionMark" name="questionMark" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="table-responsive">
                                <asp:Table ID="Table1" runat="server" BorderColor="#DADDE1" CellPadding="5" CellSpacing="5" CssClass="table table-bordered table-striped">
                                    <asp:TableHeaderRow ID="TableHeaderRow1" runat="server">
                                        <asp:TableCell ID="TableCell1" runat="server"><b>Chapter Title</b></asp:TableCell>
                                        <asp:TableCell ID="TableCell2" runat="server"><b>Chapter Description</b></asp:TableCell>
                                        <asp:TableCell ID="TableCell3" runat="server"><b>Number of question from this chapter</b></asp:TableCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <asp:Button id="btnSave" class="btn btn-primary" runat="server" type="submit" Text="Save" value="Save" OnClick="btnSave_Click" />
                            <button class="btn btn-default" type="reset">Reset</button>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
