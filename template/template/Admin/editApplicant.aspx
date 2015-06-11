<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="editApplicant.aspx.cs" Inherits="template.Admin.editApplicant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Applicants</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                   Edit Applicant
                </div>
        
                    <div class="panel-body" >
                        <div class="row">
                         <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
                        <p><asp:Label id="successMsg" runat="server" Text="" /></p>
                    </div>
                    <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
                        <p><asp:Label id="errMsg" runat="server" Text="" /></p>
                    </div>
                 
                            <div class="row col-xs-12 col-md-12 col-sm-12" > 
                                  <!--this is the left division -->
                                <div class="col-md-6 col-xs-12" >
                                    <div class="form-horizontal">
                                        <div class="form-group" >
                                             <label for="firstname" class="col-md-3 control-label">first Name </label>
                                            <div class="col-md-9">
                                                <input type="text" id="firstname"  runat="server" name="firstname" required="required" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                           <label for="firstname" class="col-md-3 control-label"> Middle Name</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="middlename" name="middlename" required="required" class="form-control"/>
                                            </div>
                                             
                                        </div>
                                        <div class="form-group">
                                             <label for="lastname" class="col-md-3 control-label">Last Name</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="lastname" required="required" class="form-control" name="lastname" />
                                            </div>
                                           
                                        </div>
                                        <div class="form-group">
                                             <label for="email" class="col-md-3 control-label" >Date of birth</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server"  required="required" id="datepicker" class="form-control datepicker"  name="date_of_birth" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="NationalID" class="col-md-3 control-label" >Registration Number</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="registratoin_nb" required="required" class="form-control" name="registratoin_nb" />
                                            </div> 
                                        </div>
                                        <div class="form-group">
                                            <label for="Nationaity" class="col-md-3 control-label" >Nationality</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="nationality"  required="required" class="form-control" name="nationality" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                             <label for="mobile" class="col-md-3 control-label" >Phone </label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="phone" required="required" class="form-control" name="phone" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                             <label for="phone" class="col-md-3 control-label" >Cellular</label>
                                            <div class="col-md-9">
                                               <input type="text"   runat="server" required="required" id="cellular" class="form-control"  name="cellular" />
                                            </div> 
                                        </div>
                                        <div class="form-group">
                                             <label for="email" class="col-md-3 control-label" >FAX</label>
                                            <div class="col-md-9">
                                                <input type="text"   runat="server" class="form-control" id="fax_number" name="fax_number" />
                                            </div> 
                                        </div>
                                        <div class="form-group">
                                            <label for="email" class="col-md-3 control-label" > Mail Address</label>
                                             <div class="col-md-9">
                                                <input type="text"   runat="server" class="form-control" id="mail"  name="mail" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="club" class="col-md-3 control-label" >Hunting Club</label>
                                            <div class="col-md-9">
                                                <select class="form-control" id="club" name="club">
                                                    <%
                                                    foreach( template.DBModel.HuntingClub club in clubs )
                                                        { %>
                                                        <option value="<%= club.clubID %>"><%= club.clubName %></option>
                                                    <%  }; %>
                                                </select>
                                            </div>
                                        </div> 
                                    </div>
                                </div>
                                <!--this is the left division-->
                                <div class="col-md-6 col-xs-12" >
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                             <label for="userbame"  class="col-md-3 control-label" >Username</label>
                                            <div class="col-md-9">
                                                <input type="text"    runat="server" required="required" class="form-control" id="username"   name="username" />
                                            </div>
                                        </div>
                                        
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Gender</label>
                                            <div class="col-md-9" >
                                                <select name="gender" class="form-control">
                                                    <option id="male" runat="server" text-align="right" value="male">Male</option>
                                                    <option id="female" runat="server" text-align="right" value="female">Female</option>
                                                </select>
                                            </div>
                                            
                                            
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label"> Place Of Birth</label>
                                             <div class="col-md-9">
                                                <asp:TextBox  runat="server" id="place_ofBirth" class="form-control" Text="place_ofBirth"  />
                                            </div>
                                        </div>
                                       <div class="form-group">
                                           <label for="icode" class="col-md-3 control-label">City</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="city" required="required" class="form-control" name="city"  />
                                            </div>
                                            
                                        </div>
                                        <div class="form-group">
                                            <label for="address" class="col-md-3 control-label" >Address</label>
                                            <div class="col-md-9">
                                                <input type="text"   runat="server" id="address" required="required"  class="form-control"  name="address" />
                                            </div>
                                            
                                        </div>
                                    
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Blood Type</label>
                                             <div class="col-md-9">
                                                <input type="text"  runat="server" id="bloodType"  required="required" class="form-control" name="blood_type"   />
                                            </div>
                                            

                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Profession</label>
                                           <div class="col-md-9">
                                                <input type="text"  runat="server" id="profession" required="required" class="form-control" name="profession"  />
                                            </div>
                                            
                                        </div>
                                        <div class="form-group">
                                            <label for="icode" class="col-md-3 control-label">Email Address</label>
                                            <div class="col-md-9">
                                                <input type="text"  runat="server" id="email"  required="required" class="form-control" name="email"   />
                                            </div>
                                        </div>
                    
                                </div>
                            </div> 
                            <div class="row">
                                <div class="form-horizontal">
                                    <div class="form-group">                                  
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:Button runat="server" id="btnSignup_reg"  class="btn btn-info" value="Edit" Conent="Edit" OnClick="edit_click"/>
                                            <input type="reset" class="btn btn-warning" value="Clear" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                     </div>
                </div>
            </div>
            </div>
        
     </div> 
    <!--date picker components-->
    <link rel="stylesheet" href="http://localhost:50867/code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
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
