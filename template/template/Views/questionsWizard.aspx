<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="questionsWizard.aspx.cs" Inherits="template.Views.questionsWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap-3.3.2-dist-sandstone/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery-latest.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/bootstrap.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery.bootstrap.wizard.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server"> 
    <input type="hidden" name="no_questions" id="no_questions" value="<%= questionsToView.Count %>" />
    
  <div class="container" style="max-width:800px;margin-top: 50px;direction: rtl" id="rootwizard">
	<div class="navbar hidden" >
	  <div class="navbar-inner">
	    <div class="container">
	        <ul>
                <% 
                for(int j=0 ; j<questionsToView.Count ; j++) { %>
                    <li><a href="#tab<%= j+1 %>" data-toggle="tab"><%= j+1 %></a></li>
                <% } %>
	        </ul>
	    </div>
	  </div>
	</div>
	
	<div class="tab-content">
        
         <% 
                for(int i=0 ; i<questionsToView.Count ; i++) { %>
	    <div class="tab-pane" id="tab<%= i+1 %>">
            <div class="panel panel-primary">
                <div class="panel-heading"><%= questionsToView[i].title %></div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <% System.Collections.Generic.List<template.DBModel.Answer> answers = questionsToView[i].answers; %>
                            <% foreach (template.DBModel.Answer answer in answers){ %>
                            <div class="radio">
                                <label><input type="radio" name="optradio<%= i+1 %>" /><%= answer.title %></label>
                            </div>
                            <%} %>
                        </div>
                    </div>
                </div>
	        </div>
        </div>
        <%} %>
		<ul class="pager wizard">
			<li class="previous first" style="display:none;"><a href="#">First</a></li>
			<%--<li class="previous"><a href="#">Previous</a></li>--%>
			<%--<li class="next last" style="display:none;"><a href="#">Last</a></li>--%>
		  	<li class="next"><a href="#">Next</a></li>
            <li class="next finish" style="display:none;"><a href="javascript:;">Finish</a></li>
		</ul>
	</div>	
</div>
    <script type="text/javascript">
        $(document).ready(function () {
           
            $('#rootwizard').bootstrapWizard({
                onTabClick: function (tab, navigation, index) {
                    alert('on tab click disabled');
                    return false;
                },
                onNext: function (tab, navigation, index) {
                    <% 
                for(int j=0 ; j<questionsToView.Count ; j++) { %>
                    // Make sure we entered the name
                    incrementer = <%= j+1%> ;
                    if(index == incrementer ){
                        if (!$("input[name='optradio<%= j+1 %>']:checked").val()) {
                        alert('Must Select answer');
                        //$('#name').focus();
                        return false;
                        
                    }
                }
            <% } %>
                    //// Set the name for the next tab
                    //$('#tab3').html('Hello, ' + $('#name').val());

                },
                onTabShow: function (tab, navigation, index) {
                    var $total = navigation.find('li').length;
                    var $current = index + 1;
                    var $percent = ($current / $total) * 100;
                    $('#rootwizard').find('.bar').css({ width: $percent + '%' });

                    // If it's the last tab then hide the last button and show the finish instead
                    if ($current >= $total) {
                        $('#rootwizard').find('.pager .next').hide();
                        $('#rootwizard').find('.pager .finish').show();
                        $('#rootwizard').find('.pager .finish').removeClass('disabled');
                    } else {
                        $('#rootwizard').find('.pager .next').show();
                        $('#rootwizard').find('.pager .finish').hide();
                    }

                }
            });
            $('#rootwizard .finish').click(function () {
                alert('Finished!');
                //$( "#question_wizard_form" ).submit();
                //document.getElementById("aspnetForm").action="questionWizardResult.aspx"; 
                //document.getElementById("aspnetForm").submit();
                //window.location.assign("questionWizardResult.aspx")
                //$('#rootwizard').find("a[href*='tab1']").trigger('click');
            });
        });
    </script>
</asp:Content>
