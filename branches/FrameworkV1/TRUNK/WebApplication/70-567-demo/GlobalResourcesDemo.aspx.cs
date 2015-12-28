using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _70_567_demo {
    public partial class GlobalResourcesDemo : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string loginImageUrl = (string)GetGlobalResourceObject("ImageResources", "LoginImageUrl");            
            Response.Write(loginImageUrl);
        }
    }
}