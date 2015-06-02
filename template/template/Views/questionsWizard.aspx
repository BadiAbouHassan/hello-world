<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="questionsWizard.aspx.cs" Inherits="template.Views.questionsWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap-3.3.2-dist-sandstone/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery-latest.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/bootstrap.js"></script>
    <script src="../bootstrap-3.3.2-dist-sandstone/js/jquery.bootstrap.wizard.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="container" style="max-width:600px;" id="rootwizard" >
	<div class="navbar hidden" >
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
            <div class="panel panel-primary">
                <div class="panel-heading">Question one </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio1">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio1">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio1" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio1" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
        </div>
	    <div class="tab-pane" id="tab2">
	      <div class="panel panel-primary">
                <div class="panel-heading">Question Two </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
	    </div>
	<div class="tab-pane" id="tab3">
			<div class="panel panel-primary">
                <div class="panel-heading">Question three </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
	    </div>
		<div class="tab-pane" id="tab4">
			<div class="panel panel-primary">
                <div class="panel-heading">Question four </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
	    </div>
		<div class="tab-pane" id="tab5">
			<div class="panel panel-primary">
                <div class="panel-heading">Question five </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
	    </div>
		<div class="tab-pane" id="tab6">
			<div class="panel panel-primary">
                <div class="panel-heading">Question six </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
	    </div>
		<div class="tab-pane" id="tab7">
			<div class="panel panel-primary">
                <div class="panel-heading">Question seven </div>
                <div class="panel-body">
                    <div class="row"> 
                        <div class="col-md-12 col-xs-12" >
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 1</label>
                            </div>
                            <div class="radio">
                                <label><input type="radio" name="optradio">Option 2</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 3</label>
                            </div>
                            <div class="radio disabled">
                                <label><input type="radio" name="optradio" >Option 4</label>
                            </div>
                        </div>
                    </div>
                </div>
	        </div>
	    </div>
		<ul class="pager wizard">
			<li class="previous first" style="display:none;"><a href="#">First</a></li>
			<li class="previous"><a href="#">Previous</a></li>
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
                    if (index == 1) {
                        // Make sure we entered the name
                        if (!$("input[name='optradio1']:checked").val()) {
                            alert('Must Select answer');
                            //$('#name').focus();
                            return false;
                        }
                    }

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
                alert('Finished!, Starting over!');
                $('#rootwizard').find("a[href*='tab1']").trigger('click');
            });
        });
    </script>
</asp:Content>
