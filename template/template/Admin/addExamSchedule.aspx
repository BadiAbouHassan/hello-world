<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="addExamSchedule.aspx.cs" Inherits="template.Admin.addExamSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Exams</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add New Exam Schedule
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="alert alert-success" style="display:none;" id="successMsgDiv" runat="server">
                                <p><asp:Label id="successMsg" runat="server" Text="" /></p>
                            </div>
                            <div class="alert alert-danger" style="display:none;" id="errMsgDiv" runat="server">
                                <p><asp:Label id="errMsg" runat="server" Text="" /></p>
                            </div>
                            <div class="form-group">
                                <label>Exam Name</label>
                                <asp:DropDownList ID="examDDL" runat="server" class="form-control"></asp:DropDownList>
                                <p class="help-block"></p>
                            </div>
                            <div class="form-group">
                                <label>Club Name</label>
                                <asp:DropDownList ID="clubDDL" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <table style="width: 400px;"  border="0">
                                    <tr>
                                        <td style="width:26px; vertical-align:top;">
                                            <label>Date</label>
                                            <asp:Calendar ID="scheduleDateTime" runat="server" FirstDayOfWeek="Monday"></asp:Calendar>
                                        </td>
                                        <td style="width: 70px; vertical-align:top;">
                                            <label>Hour</label>
                                            <select id="hour" name="hour" class="form-control" runat="server">
                                                <option value="08">08</option>
                                                <option value="08">09</option>
                                                <option value="08">10</option>
                                                <option value="08">11</option>
                                                <option value="08">12</option>
                                                <option value="08">13</option>
                                                <option value="08">14</option>
                                                <option value="08">15</option>
                                                <option value="08">16</option>
                                                <option value="08">17</option>
                                                <option value="08">18</option>
                                                <option value="08">19</option>
                                                <option value="08">20</option>
                                                <option value="08">21</option>
                                                <option value="08">22</option>
                                                <option value="08">23</option>
                                            </select>
                                        </td>
                                        <td style="width:70px; vertical-align:top;">
                                            <label>Minutes</label>
                                            <select id="minutes" name="minutes" class="form-control" runat="server">
                                                <option value="00">00</option>
                                                <option value="15">15</option>
                                                <option value="30">30</option>
                                                <option value="45">45</option>
                                            </select>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <label>Number of Seats</label>
                                <input placeholder="Number of seats" class="form-control" id="numberOfSeats" name="numberOfSeats" runat="server" required="required" />
                                <p class="help-block"></p>
                            </div>
                            <asp:Button id="btnSave" class="btn btn-primary" runat="server" type="submit" Text="Save" value="Save" OnClick="btnSave_Click" />
                            <button class="btn btn-default" type="reset">Reset</button>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
