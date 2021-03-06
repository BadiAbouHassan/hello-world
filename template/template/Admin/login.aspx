﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="template.Admin.Login" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <title>Admin control</title>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap Core CSS -->
    <link href="/Content/themes/sb-admin/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css">

    <!-- MetisMenu CSS -->
    <link href="/Content/themes/sb-admin/metisMenu/dist/metisMenu.min.css" rel="stylesheet">

    <!-- Timeline CSS -->
    <link href="/Content/themes/sb-admin/css/timeline.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="/Content/themes/sb-admin/css/sb-admin-2.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="/Content/themes/sb-admin/morrisjs/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="/Content/themes/sb-admin/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- jQuery -->
    <script src="/Content/themes/sb-admin/jquery/dist/jquery.min.js"></script>

</head>

<body>

     <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <form id="Form1" class="form-signin" runat="server">
                            <div class="alert alert-success" style="display: none;" id="successMsgDiv" runat="server">
                                <p>
                                    <asp:Label ID="successMsg" runat="server" Text="" /></p>
                            </div>
                            <div class="alert alert-danger" style="display: none;" id="errMsgDiv" runat="server">
                                <p>
                                    <asp:Label ID="errMsg" runat="server" Text="" /></p>
                            </div>
                        
                            <fieldset>
                                <div class="form-group">
                                    <input class="form-control" placeholder="Username" id="user_name" name="user_name" runat="server" autofocus />
                                </div>
                                <div class="form-group">
                                    <input class="form-control" placeholder="Password" name="password" id="password" type="password" runat="server" value=""/>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" value="Remember Me" runat="server"/>Remember Me
                                    </label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <asp:Button ID="btnSave" class="btn btn-lg btn-success btn-block" runat="server" type="submit" OnClick="btnSave_Click" Text="Login" value="Sign In" />
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
</body>
</html>
