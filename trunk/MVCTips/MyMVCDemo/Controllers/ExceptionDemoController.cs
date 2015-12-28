using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCDemo.Controllers
{
    public class ExceptionDemoController : Controller
    {
        //
        // GET: /ExceptionDemo/

        public ActionResult Index()
        {
            TempData["message"] = "manually thrown exception";
            throw new ArgumentNullException("This is thrown exception test");
        }

    }
}
