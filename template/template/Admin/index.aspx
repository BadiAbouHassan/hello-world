﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="template.Admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Dashboard</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-user fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label id="applicant_nb" runat="server" Text="" />
                            </div>
                            <div>New Applicants!</div>
                        </div>
                    </div>
                </div>
                <a href="#" id="appRef" runat="server">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-users fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label id="clubs_nb" runat="server" Text="" />
                            </div>
                            <div>New Club!</div>
                        </div>
                    </div>
                </div>
                <a href="#" id="clubRef" runat="server">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-user fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label id="users_nb" runat="server" Text="" />
                            </div>
                            <div>New Users!</div>
                        </div>
                    </div>
                </div>
                
                <a href="#" id="usrRef" runat="server">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-edit fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label id="exams_nb" runat="server" Text="" />
                            </div>
                            <div>Upcomming Exams!</div>
                        </div>
                    </div>
                </div>
                <a href="#" id="examRef" runat="server">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="fa fa-bar-chart-o fa-fw"></i> Area Chart Example
                    <div class="pull-right">
                        <div class="btn-group">
                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                Actions
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu pull-right" role="menu">
                                <li><a href="#">Action</a>
                                </li>
                                <li><a href="#">Another action</a>
                                </li>
                                <li><a href="#">Something else here</a>
                                </li>
                                <li class="divider"></li>
                                <li><a href="#">Separated link</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div id="morris-area-chart"></div>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-8 -->
        <div class="col-lg-4">
            <div class="panel panel-default" style="display:none;">
                <div class="panel-heading">
                    <i class="fa fa-bell fa-fw"></i> Notifications Panel
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="list-group">
                        <a href="#" class="list-group-item">
                            <i class="fa fa-user fa-fw"></i> New Applicanttt
                            <span class="pull-right text-muted small"><em>4 minutes ago</em>
                            </span>
                        </a>
                        <a href="#" class="list-group-item">
                            <i class="fa fa-users fa-fw"></i> 3 New Club
                            <span class="pull-right text-muted small"><em>12 minutes ago</em>
                            </span>
                        </a>
                        <a href="#" class="list-group-item">
                            <i class="fa fa-user fa-fw"></i> New User
                            <span class="pull-right text-muted small"><em>27 minutes ago</em>
                            </span>
                        </a>
                        <a href="#" class="list-group-item">
                            <i class="fa fa-edit fa-fw"></i> Upcomming Exam
                            <span class="pull-right text-muted small"><em>43 minutes ago</em>
                            </span>
                        </a>
                        <a href="#" class="list-group-item">
                            <i class="fa fa-edit fa-fw"></i> 22 Running Exam
                        </a>
                        <a href="#" class="list-group-item">
                            <i class="fa fa-certificate fa-fw"></i> 3 Expired Certificates
                        </a>
                    </div>
                    <!-- /.list-group -->
                    <a href="#" class="btn btn-default btn-block">View All Alerts</a>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-4 -->
    </div>
    <!-- /.row -->
</asp:Content>
