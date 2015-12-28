<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Button1_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(20000);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
	<style type="text/css">
	
.MyModalPanel
{
	position:absolute;
	top:0;
	left:0;
	width:100%;
	height:100%;
	margin:0;
	padding:0;
	background:#ffa url(ajax-loader.gif) center center no-repeat; 

}
	
	</style>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="adjustLoadingPanelHeight();">
        <AjaxSettings>
        
            <telerik:AjaxSetting AjaxControlID="Button1">
            
                <UpdatedControls>
                
                    <telerik:AjaxUpdatedControl ControlID="Button1" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	    
	</telerik:RadAjaxManager>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
<script type="text/javascript">
function adjustLoadingPanelHeight()
{
    $get("<%= RadAjaxLoadingPanel1.ClientID %>").style.height = document.documentElement.scrollHeight + "px";
}
</script>
</telerik:RadScriptBlock> 
	<telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
	</telerik:RadSkinManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" 
        Transparency="30" BackColor="#F0F0F0" EnableEmbeddedSkins="false"  
        IsSticky="true"  CssClass="MyModalPanel" >

</telerik:RadAjaxLoadingPanel>
	<div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
	</div>
	</form>
</body>
</html>