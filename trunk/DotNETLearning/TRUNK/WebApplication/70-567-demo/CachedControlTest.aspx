<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CachedControlTest.aspx.cs" Inherits="_70_567_demo.CachedControlTest" %>
<%@ Register Assembly="70-567-demo" Namespace="_70_567_demo" TagPrefix="cc" %>
<%@ OutputCache Duration="60"  VaryByParam="txtTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal ID="lit" runat="server" />
<br />
<br />
    <asp:TextBox runat="server" ID="txtTest" />
<br />

<cc:CachedControl runat="server" ID="c1" />
<br />
<%--<cc2:Test ID="c3" runat="server" />--%>
    <asp:Button Text="text" runat="server" />
</asp:Content>
