<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="template.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="container">    
    <div id="loginbox" style="margin-top:50px;" class=" col-sm-8 col-sm-offset-2">                    
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


    <div id="signupbox" style="display:none; margin-top:50px" class="">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Sign Up</div>
                        <div style="float:right; font-size: 85%; position: relative; top:-10px"><a id="signinlink" href="#" style="color:white" onclick="$('#signupbox').slideToggle(); $('#loginbox').slideToggle()">Sign In</a></div>
                    </div>  
                    <div class="panel-body" >
                        <form id="signupform"  role="form" method="post" action="Controllers/registrationController.aspx">
                            <div class="row col-xs-12 col-md-12 col-sm-12" >
                                <!--this is the left division -->
                                <div class="col-md-6 col-xs-12" >
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="firstname" class="col-md-3 control-label">First Name</label>
                                            <div class="col-md-9">
                                                <input type="text" name="firstname" required="required" class="form-control" placeholder="First Name" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="firstname" class="col-md-3 control-label">Midle Name</label>
                                            <div class="col-md-9">
                                                <input type="text" name="midlename" required="required" class="form-control" placeholder="Midle Name" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="lastname" class="col-md-3 control-label">Last Name</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control" name="lastname" placeholder="Last Name"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="email" class="col-md-3 control-label" >Date Of Birth</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control"  name="date_of_birth" placeholder="Date Of Birth"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="NationalID" class="col-md-3 control-label" >Registration ID</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control" name="registratoin_id" placeholder="Registration ID"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="Nationaity" class="col-md-3 control-label" >Nationality</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control" name="nationality" placeholder="Nationality"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="mobile" class="col-md-3 control-label" >Phone </label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control" name="Phone" placeholder="Phone Number"/>
                                         </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="phone" class="col-md-3 control-label" >Cellular</label>
                                            <div class="col-md-9">
                                               <input type="text"  required="required" class="form-control"  name="cellular" placeholder="Cellular number"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="email" class="col-md-3 control-label" >Fax</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control"  name="Fax Number" placeholder="Fax"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="email" class="col-md-3 control-label" >Mail</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control"  name="Fax Number" placeholder="Mail Address"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="email" class="col-md-3 control-label" >Email</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control"  name="email" placeholder="Email Address"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="address" class="col-md-3 control-label" >Address</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required"  class="form-control"  name="address" placeholder="User Address"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="address" class="col-md-3 control-label" >Club</label>
                                            <div class="col-md-9">
                                                <select runat="server" class="form-control" id="club" name="club"></select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--this is the right division-->
                                <div class="col-md-6 col-xs-12" >
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="userbame" class="col-md-3 control-label" >Username</label>
                                            <div class="col-md-9">
                                                <input type="text" required="required" class="form-control"  name="username_txt" placeholder="UserName"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="password" class="col-md-3 control-label">Password</label>
                                            <div class="col-md-9">
                                               <input type="password"  required="required" class="form-control" name="password"  placeholder="Password"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Confirm Password</label>
                                            <div class="col-md-9">
                                                <input type="password"  required="required" class="form-control" name="confpasswd"   placeholder="Password"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Gender</label>
                                            <div class="col-md-9">
                                                <select name="gender" class="form-control">
                                                    <option value="male">Male</option>
                                                    <option value="female">Female</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Date Of Birth</label>
                                            <div class="col-md-9">
                                                <input type="password"  required="required" class="form-control" name="date_of_birth"   placeholder="Date Of Birth"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Blood Type</label>
                                            <div class="col-md-9">
                                                <input type="text"  required="required" class="form-control" name="blood_type"   placeholder="Blood Type"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Profession</label>
                                            <div class="col-md-9">
                                                <input type="text"  required="required" class="form-control" name="profession"   placeholder="Profession"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">email</label>
                                            <div class="col-md-9">
                                                <input type="text"  required="required" class="form-control" name="email"   placeholder="email"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">City</label>
                                            <div class="col-md-9">
                                                <input type="text"  required="required" class="form-control" name="city"   placeholder="City"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div> 
                            <div class="row">
                                <div class="form-horizontal">
                                    <div class="form-group">                                  
                                        <div class="col-md-offset-3 col-md-9">
                                            <input type="submit" id="btnSignup_reg"  class="btn btn-info" value="Sign Up" />
                                            <input type="reset" class="btn btn-warning" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                     </div>
                </div>
     </div> 
    </div>

</asp:Content>
