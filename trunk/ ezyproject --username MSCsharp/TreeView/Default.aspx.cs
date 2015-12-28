using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class TreeView_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BuildTreeView();

            RadTreeViewContextMenu mnu1 = new RadTreeViewContextMenu();
            mnu1.ID = "top";
            RadMenuItem mnuRename = new RadMenuItem("Rename");
            RadMenuItem mnuDelete = new RadMenuItem("Delete");
            mnu1.Items.Add(mnuRename);
            mnu1.Items.Add(mnuDelete);


            RadTreeViewContextMenu mnu2 = new RadTreeViewContextMenu();
            mnu2.ID = "leaf";
            RadMenuItem mnuOpen = new RadMenuItem("Open");
            RadMenuItem mnuDeleteEmail = new RadMenuItem("Delete");
            mnu2.Items.Add(mnuOpen);
            mnu2.Items.Add(mnuDeleteEmail);

            RadTreeView1.ContextMenus.Add(mnu1);
            RadTreeView1.ContextMenus.Add(mnu2);


        }
    }

    private void BuildTreeView()
    {
        RadTreeView1.Nodes.Add(new RadTreeNode("top 1","1t"));
        RadTreeView1.Nodes.Add(new RadTreeNode("top 2","2t"));
        RadTreeView1.Nodes.Add(new RadTreeNode("top 3","3t"));

        for (int i = 0; i < 3; i++)
        {
            RadTreeView1.Nodes[1].Nodes.Add(new RadTreeNode("leaf " + i,i.ToString()));
            RadTreeView1.Nodes[1].Nodes[i].ContextMenuID = "leaf";
        }

        RadTreeView1.Nodes[0].ContextMenuID = "top";
        //RadTreeView1.Nodes[0].ContextMenuID = "leaf";
        
    }
}
