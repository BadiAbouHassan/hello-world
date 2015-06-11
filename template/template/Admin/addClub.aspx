<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="addClub.aspx.cs" Inherits="template.Admin.addClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Hunting Clubs</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add New Club
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
                                <label>Club Name</label>
                                <input placeholder="Club Name" class="form-control" id="clubName" name="clubName" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Club Address</label>
                                <textarea class="form-control" rows="3" runat="server" required="required" id="clubAddress" name="clubAddress"></textarea>
                            </div>
                            <div class="form-group">
                                <label>Club Phone</label>
                                <input placeholder="Club Phone" class="form-control" id="clubPhone" name="clubPhone" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Email</label>
                                <input placeholder="Club Name" class="form-control" id="email" name="email" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>User</label>
                                <select runat="server" name="Users" id="Users" class="form-control" ></select>
                                <p class="help-block"></p>
                            </div>
                            <asp:Button id="btnSave" OnClick="btnSave_Click" class="btn btn-primary" runat="server" type="submit" Text="Save" value="Save"  />
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
