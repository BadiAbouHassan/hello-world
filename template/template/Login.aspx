<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="template.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="container">    
        <div id="loginbox" style="margin-top:50px;" class=" col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info" >
                <div class="panel-heading">
                    <div class="panel-title" align="right">تسجيل الدخول</div>
                    <%--<div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="index.php?action=forgetPassword" class="btn btn-default">Forgot password?</a></div>--%>
                </div>     
                <div style="padding-top:30px" class="panel-body"  align="right">
               
                    <form id="loginform" class="form-horizontal" role="form"  method="post"  >
                         <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
                            <p><asp:Label id="successMsg" runat="server" Text="" /></p>
                    </div>
                    <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
                                    <p><asp:Label id="errMsg" runat="server" Text="" /></p>
                     </div>
                            <div style="margin-bottom: 25px" class="input-group" align="right"  >
                                 <input required="required" id="login_username" text-align="right" dir="rtl"  type="text" class="form-control" name="username" value="" runat="server" placeholder="اسم المستخدم أو البريد الإلكتروني"/>                                        
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            </div>
                            <div style="margin-bottom: 25px" class="input-group" >
                                 <input required="required" id="login_password" text-align="right" dir="rtl"  type="password" class="form-control" name="password" runat="server" placeholder="كلمة السر"/>
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            </div>
                            <div class="input-group" >
                                <div class="checkbox" >
                                    <label>
                                        <input id="login-remember" dir="rtl"   type="checkbox" name="remember" value="1"/>تحفيظ الدخول
                                    </label>
                                </div>
                            </div>
                            <div style="margin-top:10px" class="form-group">
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <asp:Button id="btnLogin" runat="server" Text="تسجيل الدخول" class="btn btn-success" value="Log in " OnClick="signIn" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12 control">
                                    <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                      ليس لديك حساب!
                                        <a href="#" onclick="$('#loginbox').fadeToggle(); $('#signupbox').fadeToggle()">
                                        اشترك هنا
                                    </a>
                                    </div>
                                </div>
                            </div>    
                        </form>    
                    </div>                     
                </div>  
        </div>


        <div id="signupbox" style="display:none; margin-top:50px" class="" align="right">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title" align="right" >تسجيل الاشتراك</div>
                        <div style="float:left; font-size: 85%; position: relative; top:-10px"><a id="signinlink" href="#" style="color:white" onclick="$('#signupbox').fadeToggle(); $('#loginbox').fadeToggle()">تسجيل الدخول</a></div>
                    </div>  
                    <div class="panel-body" >
                        <form id="signupform"  role="form" method="post" action="Controllers/registrationController.aspx" align="right">
                            <div class="row col-xs-12 col-md-12 col-sm-12" >
                              
                                <!--this is the left division-->
                                <div class="col-md-6 col-xs-12" >
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text"  value dir="rtl" required="required" class="form-control"   name="username" placeholder="اسم المستخدم"/>
                                            </div>
                                            <label for="userbame" align="right" class="col-md-3 control-label" >اسم المستخدم</label>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                               <input type="password"   dir="rtl"   required="required" class="form-control" name="password"  placeholder="كلمة السر"/>
                                            </div>
                                            <label for="password" align="right"  class="col-md-3 control-label">كلمة السر</label>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="password"  dir="rtl" required="required" class="form-control" name="confpasswd"   placeholder=" كلمة السر"/>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">تأكيد كلمة السر</label>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9" >
                                                <select name="gender" class="form-control" dir="rtl">
                                                    <option dir="rtl"  value="male">ذكر</option>
                                                    <option dir="rtl"  value="female">انثى</option>
                                                </select>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">الجنس</label>
                                            
                                        </div>
                                        <div class="form-group">
                                             <div class="col-md-9">
                                                <input type="text" dir="rtl"  required="required" class="form-control" name="place_of_birth"   placeholder="مكان الميلاد"/>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">مكان الميلاد</label>
   
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl" required="required" class="form-control" name="city"   placeholder="المدينة"/>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">المدينة</label>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text"  dir="rtl" required="required"  class="form-control"  name="address" placeholder="العنوان"/>
                                            </div>
                                            <label for="address" class="col-md-3 control-label" >العنوان</label>
                                        </div>
                                    
                                        <div class="form-group">
                                             <div class="col-md-9">
                                                <input type="text" dir="rtl"  required="required" class="form-control" name="blood_type"   placeholder="فئة الدم"/>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">فئة الدم</label>

                                        </div>
                                        <div class="form-group">
                                           <div class="col-md-9">
                                                <input type="text" dir="rtl" required="required" class="form-control" name="profession"   placeholder="نوع العمل"/>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">نوع العمل</label>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl"  required="required" class="form-control" name="email"   placeholder="البريد الاكتروني"/>
                                            </div>
                                            <label for="icode" class="col-md-3 control-label">البريد الاكتروني</label>

                                        </div>
                    
                                    </div>
                                </div>
                                  <!--this is the left division -->
                                <div class="col-md-6 col-xs-12" >
                                    <div class="form-horizontal">
                                        <div class="form-group" >
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl" name="firstname" required="required" class="form-control" placeholder="الاسم " />
                                            </div>
                                            <label for="firstname" class="col-md-3 control-label">الاسم </label>
                                            
                                        </div>
                                        <div class="form-group">
                                           
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl"  name="middlename" required="required" class="form-control" placeholder="اسم الاب" />
                                            </div>
                                             <label for="firstname" class="col-md-3 control-label">اسم الاب</label>
                                        </div>
                                        <div class="form-group">
                                            
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl" required="required" class="form-control" name="lastname" placeholder="اسم العائلة"/>
                                            </div>
                                            <label for="lastname" class="col-md-3 control-label">اسم العائلة</label>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl" required="required" id="datepicker" class="form-control datepicker"  name="date_of_birth" placeholder="yyyy-MM-dd"/>
                                            </div>
                                            <label for="email" class="col-md-3 control-label" >تاريخ الميلاد</label>

                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl" required="required" class="form-control" name="registratoin_nb" placeholder="رقم السجل"/>
                                            </div>
                                            <label for="NationalID" class="col-md-3 control-label" >رقم السجل</label>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <select class="form-control" id="Select1" name="nationality" dir="rtl">
                                                    <%
                                                    foreach( template.DBModel.Country country in countries )
                                                        { %>
                                                        <option dir="rtl" value="<%= country.countryCode %>"><%= country.countryNameAr %></option>
                                                    <%  }; %>
                                                </select>
                                            </div>
                                            <label for="Nationaity" class="col-md-3 control-label" >الجنسية</label>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text" dir="rtl" required="required" class="form-control" name="phone" placeholder="الهاتف"/>
                                            </div>
                                            <label for="mobile" class="col-md-3 control-label" >الهاتف </label>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                               <input type="text"  dir="rtl" required="required" class="form-control"  name="cellular" placeholder="الخلوي"/>
                                            </div>
                                            <label for="phone" class="col-md-3 control-label" >الخلوي</label>
                                            
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <input type="text"  dir="rtl" class="form-control"  name="fax_number" placeholder="الفاكس"/>
                                            </div>
                                            <label for="email" class="col-md-3 control-label" >الفاكس</label>
                                            
                                        </div>
                                        <div class="form-group">
                                             <div class="col-md-9">
                                                <input type="text"  dir="rtl" class="form-control"  name="mail" placeholder="العنوان البريدي"/>
                                            </div>
                                            <label for="email" class="col-md-3 control-label" >العنوان البريدي</label>
                                           
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-9">
                                                <select class="form-control" id="club" name="club" dir="rtl">
                                                    <%
                                                    foreach( template.DBModel.HuntingClub club in clubs )
                                                        { %>
                                                        <option dir="rtl" value="<%= club.clubID %>"><%= club.clubName %></option>
                                                    <%  }; %>
                                                </select>
                                            </div>
                                            <label for="address" class="col-md-3 control-label" >النادي</label>
                             
                                        </div> 
                                    </div>
                                </div>
                             
                                <div class="row" align="left">
                                <div class="form-horizontal">
                                    <div class="form-group">                                  
                                        <div class="col-md-offset-3 col-md-9" align="left">
                                            <input type="reset" class="btn btn-warning" value="مسح المجالات" />
                                            <input type="submit" id="btnSignup_reg"  class="btn btn-info" value="الاشتراك" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                             </div>
                        </form>
                     </div>
                </div>
        </div> 
    </div>
 <!--date picker components-->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script >
          $(function () {
              $("#datepicker").datepicker({
                  buttonText: "Select date",
                  showButtonPanel: true,
                  yearRange: "1930:2012",
                  changeMonth: true,
                  changeYear: true,
                  dateFormat: "yy-mm-dd",
                  numberOfMonths: 1,
                  onSelect: function () {
                      this.focus();
                  }
              });
          });
    </script>
</asp:Content>
