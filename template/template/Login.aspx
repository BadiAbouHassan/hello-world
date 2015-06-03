<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="template.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="container">    
    <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
        <div class="panel panel-info" >
            <div class="panel-heading">
                <div class="panel-title">Sign In</div>
                <%--<div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="index.php?action=forgetPassword" class="btn btn-default">Forgot password?</a></div>--%>
            </div>     
            <div style="padding-top:30px" class="panel-body" >
                <p><asp:Label id="lbl1" runat="server" Text="" /></p>
                <form id="loginform" class="form-horizontal" role="form"  method="post" >
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input required id="login_username" type="text" class="form-control" name="username" value="" runat="server" placeholder="username or email">                                        
                        </div>
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input required id="login_password" type="password" class="form-control" name="password" runat="server" placeholder="password">
                        </div>
                        <div class="input-group">
                            <div class="checkbox">
                                <label>
                                    <input id="login-remember" type="checkbox" name="remember" value="1"> Remember me
                                </label>
                            </div>
                        </div>
                        <div style="margin-top:10px" class="form-group">
                            <!-- Button -->
                            <div class="col-sm-12 controls">
                                <asp:Button id="btnLogin" runat="server" Text="Log in" class="btn btn-success" value="Login" OnClick="signIn" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 control">
                                <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                    Don't have an account! 
                                    <a href="#" onclick="$('#loginbox').slideToggle(); $('#signupbox').slideToggle()">
                                    Sign Up Here
                                </a>
                                </div>
                            </div>
                        </div>    
                    </form>    
                </div>                     
            </div>  
        </div>
    <div id="signupbox" style="display:none; margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Sign Up</div>
                        <div style="float:right; font-size: 85%; position: relative; top:-10px"><a id="signinlink" href="#" style="color:white" onclick="$('#signupbox').slideToggle(); $('#loginbox').slideToggle()">Sign In</a></div>
                    </div>  
                    <div class="panel-body" >
                        <form id="signupform" class="form-horizontal" role="form" action="Login.aspx">

                            <div id="signupalert" style="display:none" class="alert alert-danger">
                                <p>Error:</p>
                                <span></span>
                            </div>
                            
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">First Name</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" name="firstname"  id="firstname_txt" runat="server" placeholder="First Name">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="lastname" class="col-md-3 control-label">Last Name</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" name="lastname" id="lastname_txt" runat="server" placeholder="Last Name">
                                </div>
                            </div>
                            <!-- added marwa -->
                            <div class="form-group">
                                <label for="email" class="col-md-3 control-label" >Email</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="email_txt" runat="server" name="email" placeholder="Email Address">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="address" class="col-md-3 control-label" >Address</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="address_txt" runat="server" name="address" placeholder="User Address">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="mobile" class="col-md-3 control-label" >Mobile</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="mobile_txt" runat="server" name="mobile" placeholder="Mobile number">
                             </div>
                            </div>
                            <div class="form-group">
                                <label for="phone" class="col-md-3 control-label" >Phone</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="phone_txt" runat="server" name="phone" placeholder="Phone number">
                                </div>
                            </div>
                             <div class="form-group">
                                <label for="Nationaity" class="col-md-3 control-label" >Nationality</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="nationality_txt" runat="server" name="nationality" placeholder="Nationality">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="NationalID" class="col-md-3 control-label" >National ID</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="nationalID_txt" runat="server" name="nationalID" placeholder="National ID">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="userbame" class="col-md-3 control-label" >Username</label>
                                <div class="col-md-9">
                                    <input type="text" required class="form-control" id="username_txt" runat="server" name="username" placeholder="UserName">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="password" class="col-md-3 control-label">Password</label>
                                <div class="col-md-9">
                                    <input type="password" class="form-control" name="passwd" id="passwrd_txt" runat="server" placeholder="Password">
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="icode" class="col-md-3 control-label">Confirm Password</label>
                                <div class="col-md-9">
                                      <input type="password" class="form-control" name="confpasswd" id="confirm_pass_txt" runat="server" placeholder="Password">
                                </div>
                            </div>

                            <div class="form-group">
                                <!-- Button -->                                        
                                <div class="col-md-offset-3 col-md-9">
                                     <asp:Button id="btn_signup_reg" runat="server" Text="Sign Up" class="btn btn-info" value="Sign Up" OnClick="signUp" />
                                    <input type="reset" class="btn btn-warning" />
                                </div>
                            </div>

                        </form>
                     </div>
                </div>
     </div> 
    </div>

</asp:Content>
