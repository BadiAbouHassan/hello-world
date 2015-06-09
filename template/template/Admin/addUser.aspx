<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="template.Admin.addUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<div class="container-page">				
			<div class="col-md-6">
				<h3 class="dark-grey">Registration</h3>
				
				<div class="form-group col-lg-12">
					<label>Username</label>
					<input type="" name="" class="form-control" id="" value="">
				</div>
				
				<div class="form-group col-lg-6">
					<label>Password</label>
					<input type="password" name="" class="form-control" id="Password1" value="">
				</div>
				
				<div class="form-group col-lg-6">
					<label>Repeat Password</label>
					<input type="password" name="" class="form-control" id="Password2" value="">
				</div>
								
				<div class="form-group col-lg-6">
					<label>Role</label>
					<select runat="server" class="form-control">
					</select>
				</div>
				
			
			</div>
			<div class="col-md-6">
				<button type="submit" class="btn btn-primary">Register</button>
			</div>
		</div>
</asp:Content>
