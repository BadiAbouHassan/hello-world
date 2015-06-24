<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="addFieldExamResult.aspx.cs" Inherits="template.Admin.addFieldExamResult" %>
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
                    Add Field Exam Result
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
                                <label>Applicant Name</label><br />
                                <asp:Label ID="applicantName" runat="server" Text="Label"></asp:Label>
                                <input id="applicantID" name="applicantID" runat="server" type="hidden" />
                                <input id="examInstanceID" name="examInstanceID" runat="server" type="hidden" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Result</label>
                                <input placeholder="Exam Result" class="form-control" id="fieldExamResult" name="fieldExamResult" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>notes</label>
                                <textarea class="form-control" rows="3" runat="server" id="fieldExamNotes" name="fieldExamNotes"></textarea>
                            </div>
                            <asp:Button id="btnSave" class="btn btn-primary" runat="server" type="submit" Text="Save" value="Save" OnClick="btnSave_Click" />
                            <button class="btn btn-default" type="reset">Reset</button>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
