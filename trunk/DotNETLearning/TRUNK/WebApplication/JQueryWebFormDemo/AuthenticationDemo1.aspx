<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthenticationDemo1.aspx.cs" Inherits="JQueryWebFormDemo.AuthenticationDemo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset><legend>普通登录</legend><form action="<%= Request.RawUrl %>" method="post">
    登录名：<input type="text" name="loginName" style="width: 200px" value="Fish" />
    <input type="submit" name="NormalLogin" value="登录" />
</form></fieldset>
    
    <fieldset><legend>用户状态</legend><form action="<%= Request.RawUrl %>" method="post">
    <% if( Request.IsAuthenticated ) { %>
        当前用户已登录，登录名：<%= Context.User.Identity.Name %> <br />            
        <input type="submit" name="Logon" value="退出" />
    <% } else { %>
        <b>当前用户还未登录。</b>
    <% } %>            
</form></fieldset>
</asp:Content>
