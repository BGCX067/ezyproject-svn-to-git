using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace _70_567_demo {
    public class CachedControl:WebControl {
        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            writer.Write(DateTime.Now);
        }
    }
}