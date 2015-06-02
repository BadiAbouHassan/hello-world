<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="questionsWizard.aspx.cs" Inherits="template.Views.questionsWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap-3.3.2-dist-sandstone/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/bootstrap.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery.bootstrap.wizard.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
   <div id="rootwizard">
	<div class="navbar">
	  <div class="navbar-inner">
	    <div class="container">
	<ul>
	  	<li><a href="#tab1" data-toggle="tab">First</a></li>
		<li><a href="#tab2" data-toggle="tab">Second</a></li>
		<li><a href="#tab3" data-toggle="tab">Third</a></li>
		<li><a href="#tab4" data-toggle="tab">Forth</a></li>
		<li><a href="#tab5" data-toggle="tab">Fifth</a></li>
		<li><a href="#tab6" data-toggle="tab">Sixth</a></li>
		<li><a href="#tab7" data-toggle="tab">Seventh</a></li>
	</ul>
	 </div>
	  </div>
	</div>
	<div class="tab-content">
	    <div class="tab-pane" id="tab1">
	      1
	    </div>
	    <div class="tab-pane" id="tab2">
	      2
	    </div>
		<div class="tab-pane" id="tab3">
			3
	    </div>
		<div class="tab-pane" id="tab4">
			4
	    </div>
		<div class="tab-pane" id="tab5">
			5
	    </div>
		<div class="tab-pane" id="tab6">
			6
	    </div>
		<div class="tab-pane" id="tab7">
			7
	    </div>
		<ul class="pager wizard">
			<li class="previous first" style="display:none;"><a href="#">First</a></li>
			<li class="previous"><a href="#">Previous</a></li>
			<li class="next last" style="display:none;"><a href="#">Last</a></li>
		  	<li class="next"><a href="#">Next</a></li>
		</ul>
	</div>	
</div>
    <script type="text/ecmascript">
        $(document).ready(function () {
            $('#rootwizard').bootstrapWizard({
                onTabClick: function (tab, navigation, index) {
                    alert('on tab click disabled');
                    return false;
                }
            });
        });
    </script>
</asp:Content>
