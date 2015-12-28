<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JQueryWebFormDemo._Default" ClientIDMode="Static" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
    <h2>
        Welcome to ASP.NET!
    </h2>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <p>
                <asp:Label ID="lblFirstName" Text="First name" runat="server"  />
                <asp:TextBox runat="server" ID="txtFirstName"  />
            </p>
            <p>
                <asp:Label ID="lblLastName" Text="Last name" runat="server"  />
                <asp:TextBox runat="server" ID="txtLastName" />
            </p>
            <p>
                <asp:Button Text="Submit" runat="server" ID="btnSubmit" />
            </p>
            <asp:Button Text="Change Config value" runat="server" ID="btnSaveConfig" />
        </fieldset>
    </div>


</asp:Content>
