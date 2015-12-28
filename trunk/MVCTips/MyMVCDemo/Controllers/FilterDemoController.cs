using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCDemo.Models;

namespace MyMVCDemo.Controllers {
    public class FilterDemoController : Controller {

        public ActionResult Index() {
            return View();
        }

        [ShowMessage(Message="A")]
        [ShowMessage(Message = "B")]
        [Authorize(Roles="Admin")]
        public ActionResult SomeAction() {            
            Response.Write("Action is running");
            Response.Write("<br/>");

            return Content("Result is running");
        }
    }
}