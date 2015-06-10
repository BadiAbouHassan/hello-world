<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="viewApplicants.aspx.cs" Inherits="template.Admin.viewApplicants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Courses</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
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
                                <asp:TableCell ID="TableCell1" runat="server"><b>ID</b></asp:TableCell>
                                <asp:TableCell ID="TableCell2" runat="server"><b>UserName</b></asp:TableCell>
                                <asp:TableCell ID="TableCell4" runat="server"><b>Name</b></asp:TableCell>
                                <asp:TableCell ID="TableCell5" runat="server"><b>Gender</b></asp:TableCell>
                                <asp:TableCell ID="TableCell6" runat="server"><b>Date of Birth</b></asp:TableCell>
                                <asp:TableCell ID="TableCell7" runat="server"><b>Place of Birth</b></asp:TableCell>
                                <asp:TableCell ID="TableCell8" runat="server"><b>Registration Nb</b></asp:TableCell>
                                <asp:TableCell ID="TableCell9" runat="server"><b>Nationality</b></asp:TableCell>
                                <asp:TableCell ID="TableCell10" runat="server"><b>Blood Type</b></asp:TableCell>
                                <asp:TableCell ID="TableCell11" runat="server"><b>Profession</b></asp:TableCell>
                                <asp:TableCell ID="TableCell12" runat="server"><b>Email</b></asp:TableCell>
                                <asp:TableCell ID="TableCell13" runat="server"><b>Mail Address</b></asp:TableCell>
                                <asp:TableCell ID="TableCell14" runat="server"><b>FAX</b></asp:TableCell>
                                <asp:TableCell ID="TableCell15" runat="server"><b>City</b></asp:TableCell>
                                <asp:TableCell ID="TableCell16" runat="server"><b>Address</b></asp:TableCell>
                                <asp:TableCell ID="TableCell17" runat="server"><b>Cellular</b></asp:TableCell>
                                <asp:TableCell ID="TableCell18" runat="server"><b>Phone</b></asp:TableCell>
                                <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="2">Delete</asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
</asp:Content>
