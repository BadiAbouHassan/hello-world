<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="assignExamSchedule.aspx.cs" Inherits="template.Admin.assignExamSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-heading">
                    Add New Exam Schedule
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
                                <input class="form-control" id="applicantID" name="applicantID" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Scheduled Exams</label>
                                <asp:DropDownList ID="scheduledExam" runat="server" class="form-control"></asp:DropDownList>
                                <p class="help-block"></p>
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
