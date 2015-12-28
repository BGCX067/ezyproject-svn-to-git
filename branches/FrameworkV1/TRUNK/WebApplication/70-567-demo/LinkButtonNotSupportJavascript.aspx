<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkButtonNotSupportJavascript.aspx.cs" Inherits="_70_567_demo.LinkButtonNotSupportJavascript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal ID="litTxt" runat="server" />
    <asp:LinkButton Text="Link Button" runat="server" ID="lnkBtn" />
    <br />

    <asp:Button Text="Button" runat="server" ID="btn" />
</asp:Content>
