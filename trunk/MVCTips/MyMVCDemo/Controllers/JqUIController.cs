using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCDemo.Controllers
{
    public class JqUIController : Controller
    {
        //
        // GET: /JqUI/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmDialogDemo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
