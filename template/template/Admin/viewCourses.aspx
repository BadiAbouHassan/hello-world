﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="viewCourses.aspx.cs" Inherits="template.Admin.viewCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Chapters</h1>
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
                            <asp:TableHeaderRow runat="server">
                                <asp:TableCell runat="server"><b>Chapter Title</b></asp:TableCell>
                                <asp:TableCell runat="server"><b>Chapter Description</b></asp:TableCell>
                                <asp:TableCell runat="server" ColumnSpan="2"></asp:TableCell>
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
