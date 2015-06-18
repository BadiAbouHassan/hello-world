<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="grantPermission.aspx.cs" Inherits="template.Admin.grantPermission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Grant Permission</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Grant Permission
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
                                <label> Users</label>
                                <select class="form-control" name="Users" id="Users" runat="server"></select>
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Permission Code</label>
                                <input placeholder="Permission Code" class="form-control" id="permissionCode" name="permissionCode" runat="server" required="required" />
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
