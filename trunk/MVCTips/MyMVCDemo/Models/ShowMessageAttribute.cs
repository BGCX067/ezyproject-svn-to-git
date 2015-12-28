using System;
using System.Web.Mvc;

namespace MyMVCDemo.Models {
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple=true)]
    public class ShowMessageAttribute : ActionFilterAttribute {

        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            filterContext.HttpContext.Response.Write("[BeforeAction " + Message + "]");
            AppendNewLine(filterContext.HttpContext.Response);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            filterContext.HttpContext.Response.Write("[AfterAction " + Message + "]");
            AppendNewLine(filterContext.HttpContext.Response);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext) {
            filterContext.HttpContext.Response.Write("[BeforeResult " + Message + "]");
            AppendNewLine(filterContext.HttpContext.Response);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext) {
            AppendNewLine(filterContext.HttpContext.Response);
            filterContext.HttpContext.Response.Write("[AfterResult " + Message + "]");
            
        }

        internal void AppendNewLine(System.Web.HttpResponseBase respose) {
            respose.Write("<br/>");
        }
    }
}