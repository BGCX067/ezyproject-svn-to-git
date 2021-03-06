﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G4.Web.WebControls
{       
    /// <summary>
    /// Emits Google Analytics JavaScript. Be sure to include this control on your site's MasterPage or a base page
    /// that will ensure this JavaScript gets emitted inside the HEAD element on every rendered page. 
    /// http://www.coding4streetcred.com/blog/post/Add-Google-Analytics-to-your-ASPNET-WebForms-Application.aspx
    /// https://github.com/kbeckman/C4SC
    /// </summary>
    [DefaultProperty("AccountId")]
    [ToolboxData("<{0}:GoogleAnalytics runat=server></{0}:GoogleAnalytics>")]
    [ToolboxBitmap(typeof(GoogleAnalytics), @"GoogleAnalytics.bmp")]
    public class GoogleAnalytics : WebControl
    {
        private static string _googleAnalyticsJavaScript = String.Empty;
        private static readonly object _lockObject = new object();
        private const char Quote = '"';

        /// <summary>
        /// Google Analytics Account Id.
        /// </summary>
        public string AccountId
        {
            get { return ((string)ViewState["GoogleAnalyticsAccountId"]); }
            set { ViewState["GoogleAnalyticsAccountId"] = value; }
        }

        /// <summary>
        /// Renders control's begin HTML tag.
        /// </summary>
        /// <remarks>
        /// Pass-through call to ignore the default SPAN tag rendered by WebControl base class. 
        /// </remarks>
        /// <param name="writer"><see cref="HtmlTextWriter"/></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Renders control's end HTML tag.
        /// </summary>
        /// <remarks>
        /// Pass-through call to ignore the default SPAN tag rendered by WebControl base class.
        /// </remarks>
        /// <param name="writer"><see cref="HtmlTextWriter"/></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Renders control's contents.
        /// </summary>
        /// <param name="output"><see cref="HtmlTextWriter"/></param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(GetGoogleAnalyticsJavaScript());
        }

        /// <summary>
        /// Builds the Google Analytics JavaScript block.
        /// </summary>
        /// <returns>Google Analytics JavaScript block.</returns>
        protected string GetGoogleAnalyticsJavaScript()
        {
            if (_googleAnalyticsJavaScript.Length == 0)
            {
                StringBuilder bldr = new StringBuilder();

                bldr.AppendLine(@"<script type=" + Quote + "text/javascript" + Quote + ">");
                bldr.AppendLine(@"    var _gaq = _gaq || [];");
                bldr.AppendLine(@"    _gaq.push(['_setAccount', '" + AccountId + "']);");
                bldr.AppendLine(@"    _gaq.push(['_trackPageview']);");
                bldr.AppendLine(@"    (function() {");
                bldr.AppendLine(@"        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;");
                bldr.AppendLine(@"        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';");
                bldr.AppendLine(@"        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);");
                bldr.AppendLine(@"    })();");
                bldr.AppendLine(@"</script>");

                lock (_lockObject) { _googleAnalyticsJavaScript = bldr.ToString(); }
            }

            return _googleAnalyticsJavaScript;
        }
    }
}