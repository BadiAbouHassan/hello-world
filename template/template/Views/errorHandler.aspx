﻿<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="errorHandler.aspx.cs" Inherits="template.Views.errorHandler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row col-xs-12 col-md-12" >
            <div class="panel  panel-danger">
                <div class="panel-heading">Error Message </div>
                <div class="panel-body">
                    <h2>Sorry Some Thing Wrong has been happened press
                        <a href="#" id="redirect_location" runat="server"> here </a>
                        to redirect you</h2>
                    <label name="lblValues" id="lblValues" runat="server" ></label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
