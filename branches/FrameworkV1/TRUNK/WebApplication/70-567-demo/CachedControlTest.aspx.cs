using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace _70_567_demo {
    public partial class CachedControlTest : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            lit.Text = DateTime.Now.ToString();
        }
    }    
}