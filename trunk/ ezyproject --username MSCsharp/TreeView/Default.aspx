<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TreeView_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function conetxtMenuClicked(sender, args) {
            var menuItem = args.get_menuItem();

            var treeNode = args.get_node();
            alert(treeNode.get_value());
            //alert(treeNode.get_value() + menuItem.get_text());
            
            menuItem.get_menu().hide();
            
            if (menuItem.get_value() == 'SetKeyWords') {

                //menuItem.close();


                args.set_cancel(true);
                var window = radopen('/app/Pages/Admin/EditKeyWords.aspx?mpage=empty&nodeId=' + treeNode.get_value(), 'WVGA')
                window.setSize(800, 200);

            }



        } 
</script>
    </telerik:RadCodeBlock>
 
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
	
		<telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
	</telerik:RadSkinManager>    
    <div>
    
        <telerik:RadTreeView ID="RadTreeView1" Runat="server" EnableDragAndDrop="True" 
            EnableDragAndDropBetweenNodes="True" OnClientContextMenuItemClicked="conetxtMenuClicked">
        </telerik:RadTreeView>
    
    </div>
    </form>
</body>
</html>
