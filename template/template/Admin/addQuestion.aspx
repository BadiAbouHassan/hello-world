<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="addQuestion.aspx.cs" Inherits="template.Admin.addQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Courses</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add Question
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
                                <label>Question title</label>
                                <input placeholder="Question Title" class="form-control" id="questionTitle" name="questionTitle" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Question Description</label>
                                <textarea class="form-control" rows="3" runat="server" id="questionDesc" name="questionDesc"></textarea>
                            </div>
                            <div class="form-group">
                                <label>Course</label>
                                <select class="form-control" runat="server" required="required" id="courses" name="courses"></select>
                            </div>
                            <div class="form-group">
                                <label>Answer 1</label>
                                <input placeholder="Answer 1" class="form-control" id="answer1" name="answer1" runat="server" required="required" />
                            </div>
                            <div class="form-group">
                                <label>Answer 2</label>
                                <input placeholder="Answer 2" class="form-control" id="answer2" name="answer2" runat="server" required="required" />
                            </div>
                            <div class="form-group">
                                <label>Answer 3</label>
                                <input placeholder="Answer 3" class="form-control" id="answer3" name="answer3" runat="server" />
                            </div>
                            <div class="form-group">
                                <label>Answer 2</label>
                                <input placeholder="Answer 4" class="form-control" id="answer4" name="answer4" runat="server" />
                            </div>
                            <div class="form-group">
                                <label>Answer 2</label>
                                <input placeholder="Answer 5" class="form-control" id="answer5" name="answer5" runat="server" />
                            </div>
                            <div class="form-group">
                                <label>Answer 2</label>
                                <input placeholder="Answer 6" class="form-control" id="answer6" name="answer6" runat="server" />
                            </div>
                            <div class="form-group">
                                <label>Correct Answer</label>
                                <select placeholder="Correct Answer" class="form-control" id="correctAnswer" name="correctAnswer" runat="server" required="required">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                </select>
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
