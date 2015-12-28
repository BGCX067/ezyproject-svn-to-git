namespace G4.Mvc.HtmlHelpers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Insert GA with an Urchin and domain name
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="urchin"></param>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public static HtmlString Analytics(this HtmlHelper htmlHelper, string urchin, string domainName)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<script type='text/javascript'>");
            sb.Append("  var _gaq = _gaq || [];");
            sb.Append(" _gaq.push(['_setAccount', '" + urchin + "']);");
            sb.Append(" _gaq.push(['_setDomainName', '" + domainName + "']);");
            sb.Append(" _gaq.push(['_trackPageview']);");
            sb.Append("  (function() {");
            sb.Append("   var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;");
            sb.Append("    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';");
            sb.Append("   var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);");
            sb.Append("  })();");
            sb.Append("</script>");

            return new HtmlString(sb.ToString());
        }

        /// <summary>
        /// Pull the urchin and domain name from Web.Config
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static HtmlString Analytics(this HtmlHelper htmlHelper)
        {
            //pull values from Config
            string urchin = ConfigurationManager.AppSettings["ga-urchin"];
            string domainName = ConfigurationManager.AppSettings["ga-domainName"];
            return Analytics(htmlHelper, urchin, domainName);
        }

        /// <summary>
        /// Customs the message summary.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>An instance of <see cref="MvcHtmlString"/></returns>
        public static MvcHtmlString CustomMessageSummary<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            if (htmlHelper.ViewContext.TempData["message"] != null)
            {
                var currentMessages = (List<ViewMessage>)htmlHelper.ViewContext.TempData["message"];
                StringBuilder sb = new StringBuilder();
                TagBuilder divContainer = new TagBuilder("div");
                divContainer.AddCssClass("custom-message-summary");
                foreach (var currentMessage in currentMessages)
                    sb.AppendFormat("<span class='{0}'>{1}</span>", currentMessage.MessageType.ToString().ToLower(), HttpContext.Current.Server.HtmlEncode(currentMessage.Message));
                divContainer.InnerHtml = sb.ToString();
                return MvcHtmlString.Create(divContainer.ToString(TagRenderMode.Normal));
            }
            return MvcHtmlString.Create(string.Empty);
        }

        /// <summary>
        /// Customs message summary.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="summary">The summary.</param>
        /// <returns>An instance of <see cref="MvcHtmlString"/></returns>
        public static MvcHtmlString CustomMessageSummary<TModel>(this HtmlHelper<TModel> htmlHelper, string summary)
        {
            if (htmlHelper.ViewContext.TempData["message"] != null)
            {
                var currentMessages = (List<ViewMessage>)htmlHelper.ViewContext.TempData["message"];
                StringBuilder sb = new StringBuilder();
                TagBuilder divContainer = new TagBuilder("div");
                divContainer.AddCssClass("custom-message-summary");
                if (!string.IsNullOrWhiteSpace(summary))
                    sb.AppendFormat("<div class='summary-title'>{0}</div>", summary);
                foreach (var currentMessage in currentMessages)
                    sb.AppendFormat("<span class='{0}'>{1}</span>", currentMessage.MessageType.ToString().ToLower(), HttpContext.Current.Server.HtmlEncode(currentMessage.Message));
                divContainer.InnerHtml = sb.ToString();
                return MvcHtmlString.Create(divContainer.ToString(TagRenderMode.Normal));
            }
            return MvcHtmlString.Create(string.Empty);
        }
    }
}