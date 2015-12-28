<%@ Page Language="C#" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

	protected void Button1_Click(object sender, EventArgs e)
	{
		System.Threading.Thread.Sleep(2000);
	}
	
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>RadAjaxLoadingPanel for ASP.NET AJAX</title>
<style type="text/css">

/*the following CSS rules take care of expanding the html, body and form elements
in case the page content is shorter than the browser window viewport.*/

html,
body,
form
{
	min-height:100%; /*all except IE6*/
	margin:0;
	padding:0;
}

* html html,
* html body,
* html form
{
	height:100%; /*IE6 only*/
}

/*the following CSS rule takes care of expanding the RadAjaxLoadingPanel to occupy the
full width and height of the browser viewport*/

.MyModalPanel
{
	position:absolute;
	top:0;
	left:0;
	width:100%;
	height:100%;
	margin:0;
	padding:0;
	/* background:#ffa url(loading.gif) center center no-repeat; */

}

/*custom styles not relevant to the example*/

h1,p,div div,input{margin:20px 20px 0;padding:0}

</style>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />

<telerik:RadAjaxManager
	ID="RadAjaxManager1"
	runat="server"
	DefaultLoadingPanelID="RadAjaxLoadingPanel1">
	<ClientEvents OnRequestStart="RequestStart" />
	<AjaxSettings>
		<telerik:AjaxSetting AjaxControlID="Button1">
			<UpdatedControls>
				<telerik:AjaxUpdatedControl ControlID="Panel1" />
			</UpdatedControls>
		</telerik:AjaxSetting>
	</AjaxSettings>
</telerik:RadAjaxManager>

<%-- The Modal RadAjaxLoadingPanel must be placed inside the form tag or
it must not have relatively positioned parents in the DOM tree! --%>
<telerik:RadAjaxLoadingPanel
	ID="RadAjaxLoadingPanel1"
	runat="server"
	IsSticky="true"
	CssClass="MyModalPanel"
	Transparency="50" />

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script type="text/javascript">

function RequestStart(sender, args)
{
	// the following Javascript code takes care of expanding the RadAjaxLoadingPanel
	// to the full height of the page, if it is more than the browser window viewport
	
	var loadingPanel = $get("<%= RadAjaxLoadingPanel1.ClientID %>");
	var pageHeight = document.documentElement.scrollHeight;
	var viewportHeight = document.documentElement.clientHeight;
	
	if (pageHeight > viewportHeight)
	{
		loadingPanel.style.height = pageHeight + "px";
	}
	
	// the following Javascript code takes care of centering the RadAjaxLoadingPanel
	// background image, taking into consideration the scroll offset of the page content
	
	var scrollTopOffset = document.documentElement.scrollTop;
	var loadingImageHeight = 55;

	loadingPanel.style.backgroundPosition = "center " + (parseInt(scrollTopOffset) +  parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2))+ "px";
}

</script>
</telerik:RadCodeBlock>

<h1>RadAjaxLoadingPanel for ASP.NET AJAX</h1>

<p>This page demonstrates how to expand a RadAjaxLoadingPanel to occupy the whole screen and how
to center a background image in the loading panel, no matter how much the page is scrolled.</p>

<asp:Panel
	ID="Panel1"
	runat="server"
	Width="600px"
	Height="400px"
	BackColor="#dddddd">
	This is an ajaxified asp:Panel.
</asp:Panel>

<asp:Button
	ID="Button1"
	runat="server"
	Text="Trigger an Ajax request"
	OnClick="Button1_Click" />

<p>You can scroll randomly up or down before making the AJAX request to see that the modal
background covers the whole page and the background image is always centered
in the currently visible portion of the loading panel.<br />
This is achieved by the <strong>RequestStart()</strong> Javascript function.</p>

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

</form>
</body>
</html>
