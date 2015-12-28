using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _70_567_demo {
    public partial class LinkButtonNotSupportJavascript : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected override void OnInit(EventArgs e) {
            lnkBtn.Click += new EventHandler(lnkBtn_Click);
            btn.Click += new EventHandler(btn_Click);
        }

        void btn_Click(object sender, EventArgs e) {
            litTxt.Text = DateTime.Today.ToShortDateString();
        }

        void lnkBtn_Click(object sender, EventArgs e) {
            litTxt.Text = DateTime.Today.ToShortDateString();
        }
    }
}