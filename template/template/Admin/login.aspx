<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="template.Admin.Login" %>

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

    <div class="container" style="max-width:600px;">
        <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
            <p><asp:Label id="successMsg" runat="server" Text="" /></p>
        </div>
        <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
            <p><asp:Label id="errMsg" runat="server" Text="" /></p>
        </div>
        <form class="form-signin" runat="server" >
            <h2 class="form-signin-heading">Please sign in</h2>
            <label for="inputEmail" class="sr-only">User Name</label>
            <input type="text" id="user_name" name="user_name" runat="server" class="form-control" placeholder="username" required autofocus>
            <label for="inputPassword" class="sr-only">Password</label>
            <input type="password" id="password" runat="server" class="form-control" placeholder="Password" required>
            <%--<div class="checkbox">
                <label>
                    <input type="checkbox" value="remember-me">
                    Remember me
                </label>
            </div>--%>
            <asp:Button id="btnSave" class="btn btn-lg btn-primary btn-block" runat="server" type="submit" OnClick="btnSave_Click" Text="Save" value="Sign In"  />
            
        </form>

    </div>
    <!-- /container -->


    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
</body>
</html>
