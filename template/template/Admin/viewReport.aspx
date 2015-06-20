<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="viewReport.aspx.cs" Inherits="template.Admin.viewReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header" dir="rtl">تقارير نتائج الامتحانات والنسب</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading"  dir="rtl">
                    تقارير نتائج الامتحانات والنسب
                </div>
                <div class="panel-body">
                    <div class="row col-xs-12 col-md-12">      
                        <div class="col-md-6 col-xs-12" >
                             <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
                                    <p><asp:Label id="successMsg" runat="server" Text="" /></p>
                                </div>
                             <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
                                    <p><asp:Label id="errMsg" runat="server" Text="" /></p>
                                </div>
                            <div class="form-horizontal">
                                <div class="form-group">                                  
                                  <div class="col-md-9">
                                      <input type="text" dir="rtl" required="required" id="toDate_txt" class="form-control datepicker"  name="date_of_birth" placeholder="yyyy-MM-dd"/>
                                   </div>
                                      <label for="toDate" class="col-md-3 control-label" > الى تاريخ</label>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">   
                                    <div class="col-md-9">
                                        <select name="result" class="form-control">
                                            <option dir="rtl"  value="all">الجميع</option>
                                            <option dir="rtl"  value="passed">ناجح</option>
                                            <option dir="rtl"  value="failed">راسب</option>
                                        </select>
                                    </div>
                                    <label for="result" class="col-md-3 control-label" >النتيجة</label>
                                </div>
                             </div>
                            <div class="form-horizontal">
                                <div class="form-group">   
                                <div class="col-md-9">  
                                 <input type="submit" id="btnSort"  class="btn btn-info" value="sort" onclick="sort" runat="server" />
                                </div>
                               </div>
                             </div>
                         </div>
                   
                        <div class="col-md-6 col-xs-12" >    
                            <div class="form-horizontal">   
                                <div class="form-group">
                                        <div class="col-md-9">
                                          <input type="text" dir="rtl" required="required" id="fromDate_txt" class="form-control datepicker"  name="date_of_birth" placeholder="yyyy-MM-dd"/>
                                       </div>
                                       <label  class="col-md-3 control-label" > من تاريخ</label>
                                   </div>
                                </div>
                         
                        <div class="form-horizontal">
                               <div class="form-group">
                                    <div class="col-md-9 ">
                                        <select class="form-control" id="club" name="club">
                                            <%
                                            foreach( template.DBModel.HuntingClub club in clubs )
                                                { %>
                                                <option value="<%= club.clubID %>"><%= club.clubName %></option>
                                            <%  }; %>
                                        </select>
                                    </div>
                                    <label for="address" class="col-md-3 control-label" >النادي</label>
                                </div>
                            </div>
                        <div class="form-horizontal"> 
                           <div class="form-group">
                                <div class="col-md-9">
                                        <select name="nationality" class="form-control">
                                            <option dir="rtl"  value="lebanese">لبناني</option>
                                            <option dir="rtl"  value="noLebanese">غير لبناني</option>
                                        </select>
                                    </div>
                                 <label for="nationality" class="col-md-3 control-label" >الجنسيةٍ</label>
                             </div>
                        </div>
                    </div>
                    </div>
                 </div>   
                  <div class="table-responsive" dir='rtl'>
                     <asp:Table ID="Table1" runat="server" BorderColor="#DADDE1" CellPadding="5" CellSpacing="5" CssClass="table table-bordered table-striped" >
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="9" BackColor="White" style="border-top:none; border-left:none" ></asp:TableCell>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center"><b>علامات الامتحانات</b></asp:TableCell>
                            <asp:TableCell ColumnSpan="1"  BackColor="White" style="border-top:none; border-right:none"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                         <asp:TableHeaderCell ID="TableHeaderRow1" runat="server"  >
                            <asp:TableCell ID="TableCell1" runat="server"><b>الرقم</b></asp:TableCell>
                            <asp:TableCell ID="TableCell2" runat="server"><b>الاسم</b></asp:TableCell>
                            <asp:TableCell ID="TableCell4" runat="server"><b>الجنس</b></asp:TableCell>
                            <asp:TableCell ID="TableCell5" runat="server"><b>العمر</b></asp:TableCell>
                            <asp:TableCell ID="TableCell6" runat="server"><b>الجنسية</b></asp:TableCell>
                            <asp:TableCell ID="TableCell7" runat="server"><b>النادي</b></asp:TableCell>
                            <asp:TableCell ID="TableCell8" runat="server"><b>البلدة</b></asp:TableCell>
                            <asp:TableCell ID="TableDateCell" runat="server"><b>تاريخ التقديم</b></asp:TableCell>
                            <asp:TableCell ID="TableCell10" runat="server"><b>النظري</b></asp:TableCell>
                            <asp:TableCell ID="TableCell11" runat="server"><b>الميداني</b></asp:TableCell>
                            <asp:TableCell ID="TableCell12" runat="server"><b>المجموع</b></asp:TableCell>
                            <asp:TableCell ID="TableCell13" runat="server"><b>النتيجة</b></asp:TableCell>
                        </asp:TableHeaderCell>
                       </asp:TableRow>
                             <asp:TableRow>
                                <asp:TableCell ColumnSpan="8" BackColor="White"></asp:TableCell>
                                <asp:TableCell ><b>المعدل</b></asp:TableCell>
                                <asp:TableCell ID="average_theory" runat="server">0.0</asp:TableCell> 
                                <asp:TableCell ID="average_experimental" runat="server">0.0</asp:TableCell> 
                                <asp:TableCell ID="average_total" runat="server" >0.0</asp:TableCell>  
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="8" BackColor="White"></asp:TableCell>
                                <asp:TableCell ><b>العدد</b></asp:TableCell>
                                <asp:TableCell ID="numberCell" runat="server">0</asp:TableCell>  
                            </asp:TableRow>
                     </asp:Table>
                 </div>
               
                 <div class="report-responsive" >
                     <div class="form-horizontal">
                            <div class="form-group">                                 
                              <div class="col-md-offset-3 col-md-9">
                                 <label for="toDate" class="col-md-3 control-label" id="passed_percentage" runat="server">0.0%</label>
                                  <label for="toDate" class="col-md-3 control-label" >:(%) الناجحون </label>
                             </div>
                        </div>
                      </div>
                     <div class="form-horizontal">
                            <div class="form-group">                                  
                              <div class="col-md-offset-3 col-md-9">
                                <label for="toDate" class="col-md-3 control-label" id="failed_percentage" runat="server">0.0%</label>  
                                <label for="toDate" class="col-md-3 control-label" >:(%) الراسبون </label>
                               </div>
                             </div>
                        </div>
                     <div class="form-horizontal">
                          <div class="form-group">                                  
                              <div class="col-md-offset-3 col-md-9">
                                    <label for="toDate" class="col-md-3 control-label" id="lebanese_percentage" runat="server">0.0%</label>
                                    <label for="toDate" class="col-md-3 control-label" >:(%) اللبنانيون  </label>
                                  </div>
                           </div>
                     </div>
                     <div class="form-horizontal">
                         <div class="form-group"> 
                            <div class="col-md-offset-3 col-md-9">
                                <label for="toDate" class="col-md-3 control-label" id="notLeb_percentage" runat="server">0.0%</label>
                                <label for="toDate" class="col-md-3 control-label" >:(%) الاجانب  </label>
                            </div>
                         </div>
                      </div>
                </div>
            </div>
        </div>
    </div>
    <!--date picker components-->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#toDate_txt").datepicker({
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
            $("#fromDate_txt").datepicker({
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
