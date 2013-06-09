<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PluginsSystem._Default" %>
<%@ Reference Control="~/PluginsTableControl.ascx" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <h2 runat="server" id="welcome">Welcome in Automated plugins system. Please Sing in or register to start work.</h2>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div runat="server" id="PluginsTableControlContainer"></div>
    <script src="Scripts/Global.js" type="text/javascript"></script>
</asp:Content>
